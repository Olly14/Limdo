#pragma checksum "C:\Users\Olayinka.Ayoola\source\repos\OllyProjectsSolution\Limdo.Web.App\Views\CustomerRelationshipMgms\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4f6c6073b44574f98df3b6b61c87ccd3fb29d29c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_CustomerRelationshipMgms_Index), @"mvc.1.0.view", @"/Views/CustomerRelationshipMgms/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4f6c6073b44574f98df3b6b61c87ccd3fb29d29c", @"/Views/CustomerRelationshipMgms/Index.cshtml")]
    public class Views_CustomerRelationshipMgms_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Limdo.Web.App.Models.AppUserViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Olayinka.Ayoola\source\repos\OllyProjectsSolution\Limdo.Web.App\Views\CustomerRelationshipMgms\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 7 "C:\Users\Olayinka.Ayoola\source\repos\OllyProjectsSolution\Limdo.Web.App\Views\CustomerRelationshipMgms\Index.cshtml"
   
    foreach (var item in Model)
    {
        Html.Hidden("UriKey");
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<h1>Index</h1>\r\n\r\n<p>\r\n    <a asp-action=\"Create\">Create New</a>\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n\r\n            <th>\r\n                ");
#nullable restore
#line 25 "C:\Users\Olayinka.Ayoola\source\repos\OllyProjectsSolution\Limdo.Web.App\Views\CustomerRelationshipMgms\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 28 "C:\Users\Olayinka.Ayoola\source\repos\OllyProjectsSolution\Limdo.Web.App\Views\CustomerRelationshipMgms\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n\r\n            <th>\r\n                ");
#nullable restore
#line 32 "C:\Users\Olayinka.Ayoola\source\repos\OllyProjectsSolution\Limdo.Web.App\Views\CustomerRelationshipMgms\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.FirstLineOfAddress));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 35 "C:\Users\Olayinka.Ayoola\source\repos\OllyProjectsSolution\Limdo.Web.App\Views\CustomerRelationshipMgms\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.SecondLineOfAddress));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 38 "C:\Users\Olayinka.Ayoola\source\repos\OllyProjectsSolution\Limdo.Web.App\Views\CustomerRelationshipMgms\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Town));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 41 "C:\Users\Olayinka.Ayoola\source\repos\OllyProjectsSolution\Limdo.Web.App\Views\CustomerRelationshipMgms\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Postcode));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 44 "C:\Users\Olayinka.Ayoola\source\repos\OllyProjectsSolution\Limdo.Web.App\Views\CustomerRelationshipMgms\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.DateOfBirth));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 47 "C:\Users\Olayinka.Ayoola\source\repos\OllyProjectsSolution\Limdo.Web.App\Views\CustomerRelationshipMgms\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.CreatedDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 50 "C:\Users\Olayinka.Ayoola\source\repos\OllyProjectsSolution\Limdo.Web.App\Views\CustomerRelationshipMgms\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.CountryId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 53 "C:\Users\Olayinka.Ayoola\source\repos\OllyProjectsSolution\Limdo.Web.App\Views\CustomerRelationshipMgms\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.GenderId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 56 "C:\Users\Olayinka.Ayoola\source\repos\OllyProjectsSolution\Limdo.Web.App\Views\CustomerRelationshipMgms\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.IsDeleted));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 59 "C:\Users\Olayinka.Ayoola\source\repos\OllyProjectsSolution\Limdo.Web.App\Views\CustomerRelationshipMgms\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.IsBlocked));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 62 "C:\Users\Olayinka.Ayoola\source\repos\OllyProjectsSolution\Limdo.Web.App\Views\CustomerRelationshipMgms\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.ModifierAppUserId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 65 "C:\Users\Olayinka.Ayoola\source\repos\OllyProjectsSolution\Limdo.Web.App\Views\CustomerRelationshipMgms\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.ModifiedDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n            <th></th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 73 "C:\Users\Olayinka.Ayoola\source\repos\OllyProjectsSolution\Limdo.Web.App\Views\CustomerRelationshipMgms\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n\r\n            <td>\r\n                ");
#nullable restore
#line 77 "C:\Users\Olayinka.Ayoola\source\repos\OllyProjectsSolution\Limdo.Web.App\Views\CustomerRelationshipMgms\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 80 "C:\Users\Olayinka.Ayoola\source\repos\OllyProjectsSolution\Limdo.Web.App\Views\CustomerRelationshipMgms\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n\r\n            <td>\r\n                ");
#nullable restore
#line 84 "C:\Users\Olayinka.Ayoola\source\repos\OllyProjectsSolution\Limdo.Web.App\Views\CustomerRelationshipMgms\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.FirstLineOfAddress));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 87 "C:\Users\Olayinka.Ayoola\source\repos\OllyProjectsSolution\Limdo.Web.App\Views\CustomerRelationshipMgms\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.SecondLineOfAddress));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 90 "C:\Users\Olayinka.Ayoola\source\repos\OllyProjectsSolution\Limdo.Web.App\Views\CustomerRelationshipMgms\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Town));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 93 "C:\Users\Olayinka.Ayoola\source\repos\OllyProjectsSolution\Limdo.Web.App\Views\CustomerRelationshipMgms\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Postcode));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 96 "C:\Users\Olayinka.Ayoola\source\repos\OllyProjectsSolution\Limdo.Web.App\Views\CustomerRelationshipMgms\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.DateOfBirth));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 99 "C:\Users\Olayinka.Ayoola\source\repos\OllyProjectsSolution\Limdo.Web.App\Views\CustomerRelationshipMgms\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.CreatedDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 102 "C:\Users\Olayinka.Ayoola\source\repos\OllyProjectsSolution\Limdo.Web.App\Views\CustomerRelationshipMgms\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.CountryId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 105 "C:\Users\Olayinka.Ayoola\source\repos\OllyProjectsSolution\Limdo.Web.App\Views\CustomerRelationshipMgms\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.GenderId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 108 "C:\Users\Olayinka.Ayoola\source\repos\OllyProjectsSolution\Limdo.Web.App\Views\CustomerRelationshipMgms\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.IsDeleted));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 111 "C:\Users\Olayinka.Ayoola\source\repos\OllyProjectsSolution\Limdo.Web.App\Views\CustomerRelationshipMgms\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.IsBlocked));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 114 "C:\Users\Olayinka.Ayoola\source\repos\OllyProjectsSolution\Limdo.Web.App\Views\CustomerRelationshipMgms\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.ModifierAppUserId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 117 "C:\Users\Olayinka.Ayoola\source\repos\OllyProjectsSolution\Limdo.Web.App\Views\CustomerRelationshipMgms\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.ModifiedDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 120 "C:\Users\Olayinka.Ayoola\source\repos\OllyProjectsSolution\Limdo.Web.App\Views\CustomerRelationshipMgms\Index.cshtml"
           Write(Html.ActionLink("Edit", "Edit", new {id=item.UriKey}, new {@class="btm btn-primary"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 123 "C:\Users\Olayinka.Ayoola\source\repos\OllyProjectsSolution\Limdo.Web.App\Views\CustomerRelationshipMgms\Index.cshtml"
           Write(Html.ActionLink("Details", "Details", new {id=item.UriKey}, new { @class = "btm btn-primary" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 126 "C:\Users\Olayinka.Ayoola\source\repos\OllyProjectsSolution\Limdo.Web.App\Views\CustomerRelationshipMgms\Index.cshtml"
           Write(Html.ActionLink("Delete", "Delete", new {id=item.UriKey}, new { @class = "btm btn-primary" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 129 "C:\Users\Olayinka.Ayoola\source\repos\OllyProjectsSolution\Limdo.Web.App\Views\CustomerRelationshipMgms\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Limdo.Web.App.Models.AppUserViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
