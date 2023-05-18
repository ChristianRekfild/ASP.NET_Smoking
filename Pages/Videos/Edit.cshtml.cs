using ASP_Test.Core;
using ASP_Test.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASP_Test.Pages.Videos
{
    public class EditModel : PageModel
    {
        private readonly IVideoData _videoData;
        private readonly IHtmlHelper _helper;
        public IEnumerable<SelectListItem> Genres { get; set; }
        [BindProperty]
        public Video Video { get; set; }

        public EditModel(IVideoData videoData, IHtmlHelper helper) 
        {
            _videoData = videoData;
            _helper = helper;
        }

        public IActionResult OnGet(int? videoId)
        {
            Genres = _helper.GetEnumSelectList<MovieGenre>();
            //Video = _videoData.GetVideo(videoId);
            Video = videoId.HasValue ? _videoData.GetVideo(videoId.Value)
                : new Video
                {
                    ReleaseDate = DateTime.Now
            };

            return Video == null ? RedirectToPage("./VideoError", new { message = "Видео не существует!" }) :
                (IActionResult) Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _ = Video.Id > 0 ? _videoData.UpdateVideo(Video)
                    : _videoData.AddVideo(Video);
                //_ = _videoData.UpdateVideo(Video);
                _ = _videoData.Save();
                return RedirectToPage("./Detail", new {videoId = Video.Id});
            }
            Genres = _helper.GetEnumSelectList<MovieGenre>();

            return Page();
        }
    }
}
