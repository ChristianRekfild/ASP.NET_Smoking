using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ASP_Test.Pages.TagHelpers
{
    [HtmlTargetElement("rating")]
    public class RatingTegHelper : TagHelper
    {
        public int Rating { get; set; }
        public string Label { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string rating = $"{Label}{Rating}";
            _ = output.Content.SetContent(rating);
        }

    }
}
