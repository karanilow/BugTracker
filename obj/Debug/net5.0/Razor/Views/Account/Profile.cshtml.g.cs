#pragma checksum "c:\Users\nilst\Projects\BugTracker\Views\Account\Profile.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "85f24d048b14acb719f7f9de5665ea7d30b0b87e826acc362e6f3b824856fe10"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_Profile), @"mvc.1.0.view", @"/Views/Account/Profile.cshtml")]
namespace AspNetCore
{
    #line hidden
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Mvc;
    using global::Microsoft.AspNetCore.Mvc.Rendering;
    using global::Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "c:\Users\nilst\Projects\BugTracker\Views\_ViewImports.cshtml"
using bugtracker;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "c:\Users\nilst\Projects\BugTracker\Views\_ViewImports.cshtml"
using bugtracker.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"85f24d048b14acb719f7f9de5665ea7d30b0b87e826acc362e6f3b824856fe10", @"/Views/Account/Profile.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"fa21afb8cd4e8a23e0a9b6536adf7dce76b95e9533391fae05abd663ec39e3de", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Account_Profile : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<bugtracker.Models.UserProfileViewModel>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<!-- Views/Account/Profile.cshtml -->\r\n\r\n");
#nullable restore
#line 4 "c:\Users\nilst\Projects\BugTracker\Views\Account\Profile.cshtml"
  
    ViewData["Title"] = "User Profile";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"col-md-12\">\r\n        <div class=\"row\">\r\n            <h2>");
#nullable restore
#line 11 "c:\Users\nilst\Projects\BugTracker\Views\Account\Profile.cshtml"
           Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(".</h2>\r\n\r\n            <div class=\"col-md-2\">\r\n                <img");
            BeginWriteAttribute("src", " src=\"", 313, "\"", 338, 1);
#nullable restore
#line 14 "c:\Users\nilst\Projects\BugTracker\Views\Account\Profile.cshtml"
WriteAttributeValue("", 319, Model.ProfileImage, 319, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 339, "\"", 345, 0);
            EndWriteAttribute();
            WriteLiteral(" class=\"img-rounded img-responsive\" />\r\n            </div>\r\n            <div class=\"col-md-4\">\r\n                <h3>");
#nullable restore
#line 17 "c:\Users\nilst\Projects\BugTracker\Views\Account\Profile.cshtml"
               Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                <p>\r\n                    <i class=\"glyphicon glyphicon-envelope\"></i> ");
#nullable restore
#line 19 "c:\Users\nilst\Projects\BugTracker\Views\Account\Profile.cshtml"
                                                            Write(Model.EmailAddress);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </p>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<bugtracker.Models.UserProfileViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
