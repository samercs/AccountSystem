using Microsoft.AccountSystem.Razor.TagHelpers;

namespace AccountSystem.Web.Core.TagHelpers
{
    [HtmlTargetElement("form-buttons")]
    public class FormButtons : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.Add("class", "mdl-card__actions mdl-card--border");
        }
    }
}