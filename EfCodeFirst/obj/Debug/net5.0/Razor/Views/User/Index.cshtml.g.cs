#pragma checksum "C:\Users\Calal\source\repos\EfCodeFirst\EfCodeFirst\Views\User\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "02090da154cd98fe3d26b39748e0e26015ee4d3c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_Index), @"mvc.1.0.view", @"/Views/User/Index.cshtml")]
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
#line 1 "C:\Users\Calal\source\repos\EfCodeFirst\EfCodeFirst\Views\_ViewImports.cshtml"
using EfCodeFirst;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Calal\source\repos\EfCodeFirst\EfCodeFirst\Views\_ViewImports.cshtml"
using EfCodeFirst.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\Calal\source\repos\EfCodeFirst\EfCodeFirst\Views\User\Index.cshtml"
using EfCodeFirst.Models.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"02090da154cd98fe3d26b39748e0e26015ee4d3c", @"/Views/User/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6e76184102deb19503701ff1acdacb52f141e238", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_User_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<UsersViewModel>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n<h1>Users</h1>\r\n\r\n");
#nullable restore
#line 7 "C:\Users\Calal\source\repos\EfCodeFirst\EfCodeFirst\Views\User\Index.cshtml"
 foreach(var item in Model)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <tr>");
#nullable restore
#line 9 "C:\Users\Calal\source\repos\EfCodeFirst\EfCodeFirst\Views\User\Index.cshtml"
   Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</tr>\r\n    <tr>");
#nullable restore
#line 10 "C:\Users\Calal\source\repos\EfCodeFirst\EfCodeFirst\Views\User\Index.cshtml"
   Write(item.username);

#line default
#line hidden
#nullable disable
            WriteLiteral("</tr>\r\n    <tr>");
#nullable restore
#line 11 "C:\Users\Calal\source\repos\EfCodeFirst\EfCodeFirst\Views\User\Index.cshtml"
   Write(item.active);

#line default
#line hidden
#nullable disable
            WriteLiteral("</tr>\r\n");
#nullable restore
#line 12 "C:\Users\Calal\source\repos\EfCodeFirst\EfCodeFirst\Views\User\Index.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<UsersViewModel>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
