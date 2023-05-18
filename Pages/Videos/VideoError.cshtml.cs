using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASP_Test.Pages.Videos
{
    public class VideoErrorModel : PageModel
    {
        [BindProperty(SupportsGet = true)] // сообщает, что данные свойство должно быть во всех Get запросах
        public string Message { get; set; }

        public void OnGet()
        {
        }
    }
}
