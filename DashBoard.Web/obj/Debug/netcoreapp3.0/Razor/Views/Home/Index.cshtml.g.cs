#pragma checksum "C:\Users\RoyCatayas\source\repos\APMonitor2\DashBoard.Web\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3379dd51ed9fbbba0223da35f1544a0fb5e2b537"
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
#line 1 "C:\Users\RoyCatayas\source\repos\APMonitor2\DashBoard.Web\Views\_ViewImports.cshtml"
using DashBoard.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\RoyCatayas\source\repos\APMonitor2\DashBoard.Web\Views\_ViewImports.cshtml"
using DashBoard.Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3379dd51ed9fbbba0223da35f1544a0fb5e2b537", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"25d373626befdd3c895dc3c3ffc1501e030a739f", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Transaction>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral(@"
<div class=""col-lg-12"">
    <div class=""card"">
        <div class=""card-header"">
            <div class=""utils__title"">Data List</div>
            <div class=""utils__titleDescription"">
                Access and Payment transactions information
            </div>
        </div>
        <div class=""card-body"">
            <div class=""table-responsive"">
                <table class=""table table-hover nowrap"" id=""transaction-table"" style=""width: 100% !important"">
                    <thead class=""thead-default"">
                        <tr>
                            <th>Transaction No</th>
                            <th>UserID</th>
                            <th>User Name</th>
                            <th>RFID Card number</th>
                            <th>Controller ID</th>
                            <th>Door Number</th>
                            <th>Event Alarm Code</th>
                            <th>Transaction type</th>
                            <th>Card Reader Name</th");
            WriteLiteral(@">
                            <th>Transaction type</th>
                            <th>Date</th>
                        </tr>
                    </thead>
                    <tbody>
                        
                    </tbody>
                    <tfoot>
                        <tr>
                            <th>Transaction No</th>
                            <th>UserID</th>
                            <th>User Name</th>
                            <th>RFID Card number</th>
                            <th>Controller ID</th>
                            <th>Door Number</th>
                            <th>Event Alarm Code</th>
                            <th>Transaction type</th>
                            <th>Card Reader Name</th>
                            <th>Transaction type</th>
                            <th>Date</th>
                        </tr>
                    </tfoot>
                </table>
            </div>
        </div>
    </div>
</div>

");
            WriteLiteral("\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
                WriteLiteral("    \r\n    \r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Transaction>> Html { get; private set; }
    }
}
#pragma warning restore 1591
