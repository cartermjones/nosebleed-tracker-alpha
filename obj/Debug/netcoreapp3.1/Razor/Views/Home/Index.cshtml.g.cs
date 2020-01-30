#pragma checksum "C:\Users\Carter Jones\source\repos\NosebleedTracker\NosebleedTrackerAlpha\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7229d7e80434d3c8322b4146e881a2d7abaae5d6"
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
#line 1 "C:\Users\Carter Jones\source\repos\NosebleedTracker\NosebleedTrackerAlpha\Views\_ViewImports.cshtml"
using NosebleedTrackerAlpha;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Carter Jones\source\repos\NosebleedTracker\NosebleedTrackerAlpha\Views\_ViewImports.cshtml"
using NosebleedTrackerAlpha.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7229d7e80434d3c8322b4146e881a2d7abaae5d6", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"79c1fe60eb139abee33c980951166ca391eaee58", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Carter Jones\source\repos\NosebleedTracker\NosebleedTrackerAlpha\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div class=\"row\">\r\n    <!-- List of Bleeds -->\r\n    <h2>Bleed Events</h2>\r\n    <table>\r\n        <tr class=\"card-header\">\r\n            <td class=\"empty\"></td>\r\n            <td class=\"empty\"></td>\r\n            <td>Description</td>\r\n        </tr>\r\n");
#nullable restore
#line 15 "C:\Users\Carter Jones\source\repos\NosebleedTracker\NosebleedTrackerAlpha\Views\Home\Index.cshtml"
         if  (Model != null)
        {
            var added = false;
            foreach(var t in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr");
            BeginWriteAttribute("id", " id=\"", 438, "\"", 456, 2);
            WriteAttributeValue("", 443, "tr_", 443, 3, true);
#nullable restore
#line 20 "C:\Users\Carter Jones\source\repos\NosebleedTracker\NosebleedTrackerAlpha\Views\Home\Index.cshtml"
WriteAttributeValue("", 446, t.BleedId, 446, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                    <td>");
#nullable restore
#line 21 "C:\Users\Carter Jones\source\repos\NosebleedTracker\NosebleedTrackerAlpha\Views\Home\Index.cshtml"
                   Write(t.Severity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 22 "C:\Users\Carter Jones\source\repos\NosebleedTracker\NosebleedTrackerAlpha\Views\Home\Index.cshtml"
                   Write(t.Comment);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 23 "C:\Users\Carter Jones\source\repos\NosebleedTracker\NosebleedTrackerAlpha\Views\Home\Index.cshtml"
                   Write(t.Date);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n");
#nullable restore
#line 25 "C:\Users\Carter Jones\source\repos\NosebleedTracker\NosebleedTrackerAlpha\Views\Home\Index.cshtml"
                added = true;
            }

            if(!added)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td></td>\r\n                    <td></td>\r\n                    <td style=\"display:none;\"></td>\r\n                    <td>No bleeds found.</td>\r\n                </tr>\r\n");
#nullable restore
#line 36 "C:\Users\Carter Jones\source\repos\NosebleedTracker\NosebleedTrackerAlpha\Views\Home\Index.cshtml"
            }
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </table>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
