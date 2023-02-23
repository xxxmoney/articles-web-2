using AutoMapper;
using Web.Business.Dtos;
using Web.Business.Exceptions;
using Web.Data.Repositories;
using Web.Ioc;
using Web.Logger;

namespace Web.Business.Operations
{
    /// <summary>
    /// Used for user operations - login, register, etc.
    /// </summary>
    public interface IUserOperation
    {
        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <returns></returns>
        Task<List<User>> GetUsersAsync();

        /// <summary>
        /// Gets user by specified id.
        /// </summary>
        /// <returns></returns>
        Task<User> GetUserByIdAsync(int id);

        /// <summary>
        /// Registers a new user.
        /// </summary>
        /// <param name="register"></param>
        /// <returns></returns>
        Task<User> RegisterAsync(Register register);
        /// <summary>
        /// Authenticates user.
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        Task<LoginResult> LoginAsync(Login login);
    }

    public class UserOperation : IUserOperation
    {
        private readonly ILogger logger;
        private readonly IMapper mapper;
        private readonly IUnitOfWorkFactory unitOfWorkFactory;
        private readonly IUserRepository userRepository;
        private readonly IPasswordHashOperation hashOperation;
        private readonly ITokenOperation tokenOperation;
        private readonly Configuration configuration;

        public UserOperation(
            ILogger logger,
            IMapper mapper,
            IUnitOfWorkFactory unitOfWorkFactory,
            IUserRepository userRepository,
            IPasswordHashOperation hashOperation,
            ITokenOperation tokenOperation,
            Configuration configuration)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.unitOfWorkFactory = unitOfWorkFactory;
            this.userRepository = userRepository;
            this.hashOperation = hashOperation;
            this.tokenOperation = tokenOperation;
            this.configuration = configuration;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            var users = await userRepository.GetAllAsync();
            return mapper.Map<List<User>>(users);
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var model = await this.userRepository.GetByIdAsync(id);

            return this.mapper.Map<User>(model);
        }

        public async Task<LoginResult> LoginAsync(Login login)
        {
            var user = await this.userRepository.GetByEmailAsync(login.Email);

            // Check if username exists.
            if (user == null)
            {
                throw new NotFoundException("User with email: " + login.Email + " does not exist.");
            }

            // Checks if password is correct.
            if (!this.hashOperation.VerifyPasswordHash(login.Password, user.PasswordHash, user.PasswordSalt))
            {
                throw new BadRequestException("Incorrect password.");
            }

            // Authentication successful.
            return new LoginResult
            {
                Id = user.Id,
                Token = this.tokenOperation.CreateToken(user.Id.ToString(), this.configuration.Secret),
                Email = user.Email,
                Name = user.Name,
                Surname = user.Surname
            };
        }

        public async Task<User> RegisterAsync(Register register)
        {
            // Email is taken.
            if (await this.userRepository.EmailExistsAsync(register.Email))
            {
                throw new BadRequestException("Email \"" + register.Email + "\" is already taken.");
            }

            var user = new Data.Models.User
            {
                Email = register.Email,
                Name = register.Name,
                Surname = register.Surname
            };

            // Generate password hash and salt.
            byte[] passwordHash, passwordSalt;
            this.hashOperation.CreatePasswordHash(register.Password, out passwordHash, out passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            // Add user.
            using (var unitOfWork = this.unitOfWorkFactory.Create())
            {
                try
                {
                    await this.userRepository.AddAsync(user);

                    await unitOfWork.CommitAsync();
                }
                catch
                {
                    unitOfWork.Rollback();
                    throw;
                }
            }

            this.logger.Info("User Id: \"" + user.Id + "\" registered.");

            return this.mapper.Map<User>(user);
        }
    }
}
