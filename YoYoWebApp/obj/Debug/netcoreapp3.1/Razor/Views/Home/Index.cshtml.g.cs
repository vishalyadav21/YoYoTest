#pragma checksum "E:\02020\Digital mind\YoYo-Web-App\YoYoTest\YoYoWebApp\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1a23604e978d40d64e297e7f18e44bad71381e1d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#nullable restore
#line 1 "E:\02020\Digital mind\YoYo-Web-App\YoYoTest\YoYoWebApp\Views\_ViewImports.cshtml"
using YoYoWebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\02020\Digital mind\YoYo-Web-App\YoYoTest\YoYoWebApp\Views\_ViewImports.cshtml"
using YoYoWebApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1a23604e978d40d64e297e7f18e44bad71381e1d", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4ca0b91d6083437b5bb996288885bc9bc090d8b3", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<YoYoWebApp.Models.FitnessRatingViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "TrackDetails", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "E:\02020\Digital mind\YoYo-Web-App\YoYoTest\YoYoWebApp\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("<style>\r\n    .circle {\r\n        border-radius: 50%;\r\n        border: 1px solid;\r\n        width: 200px;\r\n        height: 200px;\r\n    }\r\n</style>\r\n<div>\r\n    <h4>YoYo Test</h4>\r\n</div>\r\n<div> \r\n");
#nullable restore
#line 18 "E:\02020\Digital mind\YoYo-Web-App\YoYoTest\YoYoWebApp\Views\Home\Index.cshtml"
     if (String.IsNullOrEmpty(Model.ShuttleNo))
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\" col-md-3 row circle text-center\">\r\n        ");
#nullable restore
#line 21 "E:\02020\Digital mind\YoYo-Web-App\YoYoTest\YoYoWebApp\Views\Home\Index.cshtml"
   Write(Html.ActionLink("Play", "Play", "Home"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n");
#nullable restore
#line 23 "E:\02020\Digital mind\YoYo-Web-App\YoYoTest\YoYoWebApp\Views\Home\Index.cshtml"
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"col-md-3 row circle text-center\">\r\n        <div class=\"col-sm-12\">\r\n            ");
#nullable restore
#line 28 "E:\02020\Digital mind\YoYo-Web-App\YoYoTest\YoYoWebApp\Views\Home\Index.cshtml"
       Write(Html.DisplayNameFor(model => model.SpeedLevel));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 29 "E:\02020\Digital mind\YoYo-Web-App\YoYoTest\YoYoWebApp\Views\Home\Index.cshtml"
       Write(Html.DisplayFor(model => model.SpeedLevel));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"col-sm-12\">\r\n            ");
#nullable restore
#line 32 "E:\02020\Digital mind\YoYo-Web-App\YoYoTest\YoYoWebApp\Views\Home\Index.cshtml"
       Write(Html.DisplayNameFor(model => model.ShuttleNo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 33 "E:\02020\Digital mind\YoYo-Web-App\YoYoTest\YoYoWebApp\Views\Home\Index.cshtml"
       Write(Html.DisplayFor(model => model.ShuttleNo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"col-sm-12\">\r\n            ");
#nullable restore
#line 36 "E:\02020\Digital mind\YoYo-Web-App\YoYoTest\YoYoWebApp\Views\Home\Index.cshtml"
       Write(Html.DisplayNameFor(model => model.Speed));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 37 "E:\02020\Digital mind\YoYo-Web-App\YoYoTest\YoYoWebApp\Views\Home\Index.cshtml"
       Write(Html.DisplayFor(model => model.Speed));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>  \r\n");
#nullable restore
#line 40 "E:\02020\Digital mind\YoYo-Web-App\YoYoTest\YoYoWebApp\Views\Home\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <div class=\"col-md-12 row text-center\"> \r\n        <div class=\"col-sm-4\">\r\n            ");
#nullable restore
#line 44 "E:\02020\Digital mind\YoYo-Web-App\YoYoTest\YoYoWebApp\Views\Home\Index.cshtml"
       Write(Html.DisplayNameFor(model => model.NextShuttle));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <span id=\"NextShuttle\">");
#nullable restore
#line 45 "E:\02020\Digital mind\YoYo-Web-App\YoYoTest\YoYoWebApp\Views\Home\Index.cshtml"
                              Write(Model.NextShuttle);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n        </div>\r\n        <div class=\"col-sm-4\">\r\n            ");
#nullable restore
#line 48 "E:\02020\Digital mind\YoYo-Web-App\YoYoTest\YoYoWebApp\Views\Home\Index.cshtml"
       Write(Html.DisplayNameFor(model => model.LevelTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 49 "E:\02020\Digital mind\YoYo-Web-App\YoYoTest\YoYoWebApp\Views\Home\Index.cshtml"
       Write(Html.DisplayFor(model => model.LevelTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"col-sm-4\">\r\n            ");
#nullable restore
#line 52 "E:\02020\Digital mind\YoYo-Web-App\YoYoTest\YoYoWebApp\Views\Home\Index.cshtml"
       Write(Html.DisplayNameFor(model => model.AccumulatedShuttleDistance));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 53 "E:\02020\Digital mind\YoYo-Web-App\YoYoTest\YoYoWebApp\Views\Home\Index.cshtml"
       Write(Html.DisplayFor(model => model.AccumulatedShuttleDistance));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>  \r\n</div>\r\n\r\n<div>\r\n    <span>Track</span>\r\n</div>  \r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "1a23604e978d40d64e297e7f18e44bad71381e1d8623", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 61 "E:\02020\Digital mind\YoYo-Web-App\YoYoTest\YoYoWebApp\Views\Home\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = Model.TrackDetails;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

    <script src=""https://code.jquery.com/jquery-3.2.1.min.js""
            integrity=""sha256-hwg4gsxgFZhOsEEamdOYGBf13FyQuiTwlAQgxVSNgt4=""
            crossorigin=""anonymous""></script>
    <script>
        $(document).ready(function () {
            debugger; 
            var x = setInterval(function () {
                var nextShuttle = $(""#NextShuttle"").html();
                $(""#NextShuttle"").html(Math.floor((nextShuttle % (1000 * 60)) / 1000)); 
              //  $(""#NextShuttle"").html(Math.floor((nextShuttle % (1000 * 60)) / 1000));
            },1000); 
        });
    </script>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<YoYoWebApp.Models.FitnessRatingViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
