#pragma checksum "C:\Users\Olayinka.Ayoola\source\repos\OllyProjectsSolution\Limdo.Web.App\Views\PcoLicencesDetails\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6364595b027e80650b3a9f1f9b79eb17ceba106d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_PcoLicencesDetails_Edit), @"mvc.1.0.view", @"/Views/PcoLicencesDetails/Edit.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6364595b027e80650b3a9f1f9b79eb17ceba106d", @"/Views/PcoLicencesDetails/Edit.cshtml")]
    public class Views_PcoLicencesDetails_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Limdo.Web.App.Models.PcoLicenceDetailViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Olayinka.Ayoola\source\repos\OllyProjectsSolution\Limdo.Web.App\Views\PcoLicencesDetails\Edit.cshtml"
  
    ViewData["Title"] = "Edit";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Edit</h1>\r\n\r\n<h4>Pco Licence Details</h4>\r\n<hr />\r\n<div class=\"row\">\r\n    <div class=\"col-md-4\">\r\n        <form asp-action=\"Edit\">\r\n\r\n            ");
#nullable restore
#line 15 "C:\Users\Olayinka.Ayoola\source\repos\OllyProjectsSolution\Limdo.Web.App\Views\PcoLicencesDetails\Edit.cshtml"
       Write(Html.Hidden("UriKey"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

            <div asp-validation-summary=""ModelOnly"" class=""text-danger""></div>
            <div class=""form-group"">
                <label asp-for=""PcoId"" class=""control-label""></label>
                <input asp-for=""PcoId"" class=""form-control"" />
                <span asp-validation-for=""PcoId"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <label asp-for=""ExprireDate"" class=""control-label""></label>
                <input asp-for=""ExprireDate"" class=""form-control"" />
                <span asp-validation-for=""ExprireDate"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <label asp-for=""IssueDate"" class=""control-label""></label>
                <input asp-for=""IssueDate"" class=""form-control"" />
                <span asp-validation-for=""IssueDate"" class=""text-danger""></span>
            </div>
");
            WriteLiteral("            <div class=\"form-group\">\r\n                <input type=\"submit\" value=\"Save\" class=\"btn btn-primary\" />\r\n            </div>\r\n        </form>\r\n    </div>\r\n</div>\r\n\r\n<div>\r\n    <a asp-action=\"Index\">Back to List</a>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Limdo.Web.App.Models.PcoLicenceDetailViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
