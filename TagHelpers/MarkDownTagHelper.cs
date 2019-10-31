using HeyRed.MarkdownSharp;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace KompaniInfo.TagHelpers
{
  [HtmlTargetElement("markdown", Attributes = MarkdownAttributeName)]
  public class MarkDownTagHelper : TagHelper
  {
    private const string MarkdownAttributeName = "asp-markdown-for";

    [HtmlAttributeName("asp-markdown-for")]
    public string MarkDown { get; set; }
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
      output.Content.SetHtmlContent(new Markdown().Transform(MarkDown));
    }
  }
}
