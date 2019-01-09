using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet.TagHelpers
{
    
    [HtmlTargetElement("author-link")]
    public class AuthorLinkTagHelper : TagHelper
    {
        private const string action = "Index";
        private const string controller = "Authors";

        public string Name { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";   
            var path = controller + "/" + action + "?searchstring=" + Name;
            output.Attributes.SetAttribute("href", path);
            output.Content.SetContent(Name);
        }
    }
}
