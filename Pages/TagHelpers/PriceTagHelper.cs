

using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Globalization;

namespace ASP_Test.Pages.TagHelpers
{
    [HtmlTargetElement("videoPrice")]
    public class PriceTagHelper : TagHelper
    {
        public double VideoPrice { get; set; }
        public string CultureName { get; set; }
        public string label { get; set; }

        public override void Process (TagHelperContext context, TagHelperOutput output)
        {
            var vi = new RegionInfo(CultureName);
            var currencySymbol = vi.CurrencySymbol;

            output.TagName = "div";
            var price = $"{label}{VideoPrice}{currencySymbol}";
            _ = output.Content.SetContent(price) ;
        }
    }
}
