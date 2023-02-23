namespace Web.Business.Operations
{
    public interface IImageSaver
    {
        /// <summary>
        /// Saves the image to the disk and returns the name of the image.
        /// </summary>
        /// <param name="base64Image"></param>
        /// <returns></returns>
        Task<string> SaveImageAsync(byte[] image);

        /// <summary>
        /// Deletes the image by given name.
        /// </summary>
        /// <param name="name"></param>
        void DeleteImage(string name);
    }

    public class ImageSaver : IImageSaver
    {
        private const string EXTENSION = ".jpg";
        private readonly static string imagesPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");

        public void DeleteImage(string name)
        {
            string fullName = Path.Combine(imagesPath, name);

            if (File.Exists(fullName))
            {
                File.Delete(fullName);
            }
        }

        public async Task<string> SaveImageAsync(byte[] image)
        {
            string name = Guid.NewGuid().ToString("N") + EXTENSION;
            string fullName = Path.Combine(imagesPath, name);

            // Save image.
            await File.WriteAllBytesAsync(fullName, image);

            return name;
        }
    }
}
