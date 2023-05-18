using ASP_Test.Core;
using ASP_Test.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASP_Test.Pages.Videos
{
    public class DetailModel : PageModel
    {
        private readonly IVideoData _videoData;
        public Video Video { get; set; }

        [TempData]
        public string CommitMessage { get; set; }

        public DetailModel(IVideoData videoData)
        {
            _videoData = videoData;
        }

        public IActionResult OnGet(int videoID)
        {
            Video = _videoData.GetVideo(videoID);

            return Video == null ? RedirectToPage("./VideoError", new { message = "Видео не существует, хакер блин! Дуй отсейдова!" })
                : (IActionResult) Page();
        }
    }
}
