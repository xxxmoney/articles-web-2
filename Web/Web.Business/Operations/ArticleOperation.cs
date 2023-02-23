using AutoMapper;
using Web.Business.Dtos;
using Web.Business.Exceptions;
using Web.Data.Repositories;

namespace Web.Business.Operations
{
    public interface IArticleOperation
    {
        /// <summary>
        /// Gets articles by filter.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<List<Article>> GetArticlesAsync(ArticleFilter filter);

        /// <summary>
        /// Gets article by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Article> GetByIdAsync(int id);

        /// <summary>
        /// Inserts or updates article.
        /// </summary>
        /// <param name="article"></param>
        /// <returns></returns>
        Task<Article> UpsertArticleAsync(ArticleUpsert upsert, int userId);

        /// <summary>
        /// Updates article's picture.
        /// </summary>
        /// <param name="articleId"></param>
        /// <param name="userId"></param>
        /// <param name="picture"></param>
        /// <returns></returns>
        Task<Article> UpdateArticlePictureAsync(int articleId, int userId, byte[] picture);

        /// <summary>
        /// Delets article by id.
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns></returns>
        Task DeleteArticleAsync(int articleId, int userId);
    }

    public class ArticleOperation : IArticleOperation
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWorkFactory unitOfWorkFactory;
        private readonly IArticleRepository articleRepository;
        private readonly IImageSaver imageSaver;

        public ArticleOperation(
            IMapper mapper,
            IUnitOfWorkFactory unitOfWork,
            IArticleRepository articleRepository,
            IImageSaver imageSaver)
        {
            this.mapper = mapper;
            this.unitOfWorkFactory = unitOfWork;
            this.articleRepository = articleRepository;
            this.imageSaver = imageSaver;
        }

        /// <summary>
        /// Checks if user id from article corresponds with provided.
        /// If does not correspond - throws exception.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="model"></param>
        /// <exception cref="BadRequestException"></exception>
        private static void CheckUserId(int userId, Data.Models.Article model)
        {
            if (model.UserId != userId)
            {
                throw new BadRequestException($"Provided user Id: {userId} is not same as article user Id: {model.UserId}.");
            }
        }

        public async Task<List<Article>> GetArticlesAsync(ArticleFilter filter)
        {
            // Filter articles based on filter.
            var articles = await this.articleRepository.GetAllAsync(article =>
                filter.UserId == null || filter.UserId == article.UserId);

            return this.mapper.Map<List<Article>>(articles);
        }

        public async Task<Article> GetByIdAsync(int id)
        {
            var model = await this.articleRepository.GetByIdAsync(id);

            return this.mapper.Map<Article>(model);
        }

        public async Task<Article> UpsertArticleAsync(ArticleUpsert upsert, int userId)
        {
            Data.Models.Article model;

            // Save changes.
            using (var unitOfWork = this.unitOfWorkFactory.Create())
            {
                try
                {
                    // Id is null - insert.
                    if (!upsert.Id.HasValue)
                    {
                        model = new Data.Models.Article() { UserId = userId };
                        await this.articleRepository.AddAsync(model);
                        model.CreatedAt = DateTime.UtcNow;
                        model.UpdatedAt = DateTime.UtcNow;
                    }
                    // Id is not null - update.
                    else
                    {
                        model = await this.articleRepository.GetByIdAsync(upsert.Id.Value);
                        model.UpdatedAt = DateTime.UtcNow;
                    }

                    CheckUserId(userId, model);

                    // Map changes.
                    this.mapper.Map(upsert, model);

                    await unitOfWork.CommitAsync();
                }
                catch
                {
                    unitOfWork.Rollback();
                    throw;
                }
            }

            return this.mapper.Map<Article>(model);
        }

        public async Task<Article> UpdateArticlePictureAsync(int articleId, int userId, byte[] picture)
        {
            using (var unitOfWork = this.unitOfWorkFactory.Create())
            {
                var model = await this.articleRepository.GetByIdAsync(articleId);

                CheckUserId(userId, model);

                // Check if old picture exists.
                if (!string.IsNullOrWhiteSpace(model.PictureName))
                {
                    this.imageSaver.DeleteImage(model.PictureName);
                }

                // Save new picture and set its name.
                model.PictureName = await this.imageSaver.SaveImageAsync(picture);

                try
                {
                    await unitOfWork.CommitAsync();
                }
                catch
                {
                    unitOfWork.Rollback();
                    throw;
                }

                return this.mapper.Map<Article>(model);
            }
        }

        public async Task DeleteArticleAsync(int articleId, int userId)
        {
            var model = await this.articleRepository.GetByIdAsync(articleId);

            CheckUserId(userId, model);

            using (var unitOfWork = this.unitOfWorkFactory.Create())
            {
                try
                {
                    this.articleRepository.Remove(model);

                    await unitOfWork.CommitAsync();
                }
                catch
                {
                    unitOfWork.Rollback();
                    throw;
                }

            }
        }

    }
}
