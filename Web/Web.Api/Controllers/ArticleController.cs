using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Business.Dtos;
using Web.Business.Operations;

namespace Web.Api.Controllers
{
    public class ArticleController : BaseController
    {
        private readonly IArticleOperation articleOperation;

        public ArticleController(IArticleOperation articleOperation)
        {
            this.articleOperation = articleOperation;
        }

        [HttpGet(nameof(GetAll))]
        public async Task<IActionResult> GetAll([FromQuery] ArticleFilter filter)
        {
            var result = await articleOperation.GetArticlesAsync(filter);
            return Ok(result);
        }

        [HttpGet(nameof(GetById))]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var result = await articleOperation.GetByIdAsync(id);
            return Ok(result);
        }

        [Authorize]
        [HttpPost(nameof(Upsert))]
        public async Task<IActionResult> Upsert([FromBody] ArticleUpsert upsert)
        {
            var result = await articleOperation.UpsertArticleAsync(upsert, this.UserId.Value);
            return Ok(result);
        }

        [Authorize]
        [HttpPost(nameof(UploadPicture))]
        public async Task<IActionResult> UploadPicture([FromBody] ArticlePictureUpload upload)
        {
            var result = await articleOperation.UpdateArticlePictureAsync(upload.ArticleId, this.UserId.Value, Convert.FromBase64String(upload.PictureBase64));
            return Ok(result);
        }

        [Authorize]
        [HttpDelete(nameof(Delete))]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            await articleOperation.DeleteArticleAsync(id, this.UserId.Value);
            return Ok();
        }
    }
}
