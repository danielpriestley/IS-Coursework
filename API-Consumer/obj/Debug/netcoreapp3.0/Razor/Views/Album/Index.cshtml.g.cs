#pragma checksum "/Users/danielpriestley/Development/Uni/internet-scripting/EXAM2/CourseworkTwo/CourseworkTwo/API-Consumer/Views/Album/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7908dda9df58f1a6dc88f75eace4f0e5c7087af4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Album_Index), @"mvc.1.0.view", @"/Views/Album/Index.cshtml")]
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
#line 1 "/Users/danielpriestley/Development/Uni/internet-scripting/EXAM2/CourseworkTwo/CourseworkTwo/API-Consumer/Views/_ViewImports.cshtml"
using API_Consumer;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/danielpriestley/Development/Uni/internet-scripting/EXAM2/CourseworkTwo/CourseworkTwo/API-Consumer/Views/_ViewImports.cshtml"
using API_Consumer.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7908dda9df58f1a6dc88f75eace4f0e5c7087af4", @"/Views/Album/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"239bf421ccd34caa16e44bba40faa2d6ad1cfc50", @"/Views/_ViewImports.cshtml")]
    public class Views_Album_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "/Users/danielpriestley/Development/Uni/internet-scripting/EXAM2/CourseworkTwo/CourseworkTwo/API-Consumer/Views/Album/Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""text-center"">
    <h1 class=""display-4"">Welcome</h1>
    <p>Learn about <a href=""https://docs.microsoft.com/aspnet/core"">building Web apps with ASP.NET Core</a>.</p>
    <h2>Albums</h2>
    <table>
    <th>Album ID</th>
    <th>Album Name</th>
    <th>Artist ID</th>
");
#nullable restore
#line 13 "/Users/danielpriestley/Development/Uni/internet-scripting/EXAM2/CourseworkTwo/CourseworkTwo/API-Consumer/Views/Album/Index.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\n        <td>");
#nullable restore
#line 16 "/Users/danielpriestley/Development/Uni/internet-scripting/EXAM2/CourseworkTwo/CourseworkTwo/API-Consumer/Views/Album/Index.cshtml"
       Write(item.AlbumId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n        <td>");
#nullable restore
#line 17 "/Users/danielpriestley/Development/Uni/internet-scripting/EXAM2/CourseworkTwo/CourseworkTwo/API-Consumer/Views/Album/Index.cshtml"
       Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n        <td>");
#nullable restore
#line 18 "/Users/danielpriestley/Development/Uni/internet-scripting/EXAM2/CourseworkTwo/CourseworkTwo/API-Consumer/Views/Album/Index.cshtml"
       Write(item.ArtistId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n        </tr>\n");
#nullable restore
#line 20 "/Users/danielpriestley/Development/Uni/internet-scripting/EXAM2/CourseworkTwo/CourseworkTwo/API-Consumer/Views/Album/Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </table>\n</div>\n");
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
