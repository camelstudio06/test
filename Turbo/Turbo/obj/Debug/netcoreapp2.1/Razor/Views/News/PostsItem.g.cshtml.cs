#pragma checksum "D:\Programming\Other\ASP.NET Core\06.08.2019(FINAL PROJECT)\Turbo\Turbo\Views\News\PostsItem.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f37125bf43f3d5b73d8783b58d3b38d18df2e451"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_News_PostsItem), @"mvc.1.0.view", @"/Views/News/PostsItem.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/News/PostsItem.cshtml", typeof(AspNetCore.Views_News_PostsItem))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "D:\Programming\Other\ASP.NET Core\06.08.2019(FINAL PROJECT)\Turbo\Turbo\Views\_ViewImports.cshtml"
using Turbo;

#line default
#line hidden
#line 2 "D:\Programming\Other\ASP.NET Core\06.08.2019(FINAL PROJECT)\Turbo\Turbo\Views\_ViewImports.cshtml"
using Turbo.Models;

#line default
#line hidden
#line 3 "D:\Programming\Other\ASP.NET Core\06.08.2019(FINAL PROJECT)\Turbo\Turbo\Views\_ViewImports.cshtml"
using Turbo.ViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f37125bf43f3d5b73d8783b58d3b38d18df2e451", @"/Views/News/PostsItem.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c383af6eaf3265923f4cd03e23ffb2457c273d81", @"/Views/_ViewImports.cshtml")]
    public class Views_News_PostsItem : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<NewsPost>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(18, 224, true);
            WriteLiteral("\r\n<section>\r\n    <div class=\"wrapper\">\r\n        <div class=\"products\">\r\n            <div class=\"row\">\r\n                <div class=\"col-12 mb-3\">\r\n                    <div class=\"s-title-holder\">\r\n                        <h3>");
            EndContext();
            BeginContext(243, 11, false);
#line 9 "D:\Programming\Other\ASP.NET Core\06.08.2019(FINAL PROJECT)\Turbo\Turbo\Views\News\PostsItem.cshtml"
                       Write(Model.Title);

#line default
#line hidden
            EndContext();
            BeginContext(254, 171, true);
            WriteLiteral("</h3>\r\n                    </div>\r\n                </div>\r\n                <div class=\"col-12\">\r\n                    <div class=\"s-photo-holder\">\r\n                        ");
            EndContext();
            BeginContext(425, 40, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "e747edb23beb489c9b3aa616fe689256", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 435, "~/img/", 435, 6, true);
#line 14 "D:\Programming\Other\ASP.NET Core\06.08.2019(FINAL PROJECT)\Turbo\Turbo\Views\News\PostsItem.cshtml"
AddHtmlAttributeValue("", 441, Model.PhotoURL, 441, 15, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(465, 174, true);
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n                <div class=\"col-12 mt-3\">\r\n                    <div class=\"s-info-holder\">\r\n                        <h6>");
            EndContext();
            BeginContext(640, 17, false);
#line 19 "D:\Programming\Other\ASP.NET Core\06.08.2019(FINAL PROJECT)\Turbo\Turbo\Views\News\PostsItem.cshtml"
                       Write(Model.MainArticle);

#line default
#line hidden
            EndContext();
            BeginContext(657, 114, true);
            WriteLiteral("</h6>\r\n                    </div>\r\n                    <div class=\"s-date-holder\">\r\n                        <span>");
            EndContext();
            BeginContext(772, 37, false);
#line 22 "D:\Programming\Other\ASP.NET Core\06.08.2019(FINAL PROJECT)\Turbo\Turbo\Views\News\PostsItem.cshtml"
                         Write(Model.PublishDate.ToShortDateString());

#line default
#line hidden
            EndContext();
            BeginContext(809, 158, true);
            WriteLiteral("</span>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n        <div class=\"clear\"></div>\r\n    </div>\r\n</section>\r\n\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<NewsPost> Html { get; private set; }
    }
}
#pragma warning restore 1591
