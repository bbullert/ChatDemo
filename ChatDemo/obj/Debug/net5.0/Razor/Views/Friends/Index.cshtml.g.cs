#pragma checksum "C:\Users\bartek\source\repos\ChatDemo\ChatDemo\Views\Friends\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "52537cdf4798f7ac8ecd2515924e58e4c4211638"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Friends_Index), @"mvc.1.0.view", @"/Views/Friends/Index.cshtml")]
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
#line 1 "C:\Users\bartek\source\repos\ChatDemo\ChatDemo\Views\_ViewImports.cshtml"
using ChatDemo;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\bartek\source\repos\ChatDemo\ChatDemo\Views\_ViewImports.cshtml"
using ChatDemo.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\bartek\source\repos\ChatDemo\ChatDemo\Views\Friends\Index.cshtml"
using ChatDemo.Entities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"52537cdf4798f7ac8ecd2515924e58e4c4211638", @"/Views/Friends/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6440cbfa83b34c497f41773a2de43fecaf8817b2", @"/Views/_ViewImports.cshtml")]
    public class Views_Friends_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ICollection<AppUser>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "RemoveFriend", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onsubmit", new global::Microsoft.AspNetCore.Html.HtmlString("onFriendAction(event)"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 6 "C:\Users\bartek\source\repos\ChatDemo\ChatDemo\Views\Friends\Index.cshtml"
  
    ViewData["Title"] = "Friends";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"container\">\r\n    <div class=\"row g-3 mt-3\">\r\n        <div class=\"col px-0\">\r\n            ");
#nullable restore
#line 13 "C:\Users\bartek\source\repos\ChatDemo\ChatDemo\Views\Friends\Index.cshtml"
       Write(await Html.PartialAsync("_FriendsNavPartial", new { ActiveIndex = 0 }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
        </div>
    </div>
</div>
<hr style=""width: 100%; margin-bottom: 0;"" />
<div id=""friends-container-wrapper"" style=""overflow-y: auto; height: 100%;"">
    <div class=""container"" style=""height: 100%;"">
        <div class=""row"" style=""margin-top: auto; height: 100%;"">
            <div class=""col d-flex px-0 py-3"">
                <div id=""friends-container"" class=""d-flex flex-fill flex-column"">
");
#nullable restore
#line 23 "C:\Users\bartek\source\repos\ChatDemo\ChatDemo\Views\Friends\Index.cshtml"
                     if (Model.Count == 0)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"text-center\">\r\n                            <p>You have no friends :C</p>\r\n                        </div>\r\n");
#nullable restore
#line 28 "C:\Users\bartek\source\repos\ChatDemo\ChatDemo\Views\Friends\Index.cshtml"
                    }
                    else
                    {
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 31 "C:\Users\bartek\source\repos\ChatDemo\ChatDemo\Views\Friends\Index.cshtml"
                         foreach (var friend in Model)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "52537cdf4798f7ac8ecd2515924e58e4c42116386431", async() => {
                WriteLiteral("\r\n                                <div class=\"row my-2\">\r\n                                    <input type=\"hidden\" name=\"userId\"");
                BeginWriteAttribute("value", " value=\"", 1290, "\"", 1308, 1);
#nullable restore
#line 35 "C:\Users\bartek\source\repos\ChatDemo\ChatDemo\Views\Friends\Index.cshtml"
WriteAttributeValue("", 1298, friend.Id, 1298, 10, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                                    <label class=\"col col-form-label\">\r\n                                        <b>");
#nullable restore
#line 37 "C:\Users\bartek\source\repos\ChatDemo\ChatDemo\Views\Friends\Index.cshtml"
                                      Write(friend.UserName);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</b>
                                    </label>
                                    <div id=""user-single-result"" class=""col-auto"">
                                        <button type=""submit"" class=""btn btn-danger"">Remove</button>
                                    </div>
                                </div>
                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 44 "C:\Users\bartek\source\repos\ChatDemo\ChatDemo\Views\Friends\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 44 "C:\Users\bartek\source\repos\ChatDemo\ChatDemo\Views\Friends\Index.cshtml"
                         
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ICollection<AppUser>> Html { get; private set; }
    }
}
#pragma warning restore 1591