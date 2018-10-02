#pragma checksum "/Users/Preshen/Desktop/COMS3002/PGASystem/PGASystem/Views/Application/PendingApplications.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "98fbe919da5bae1ac0f617254c66be47d489106b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Application_PendingApplications), @"mvc.1.0.view", @"/Views/Application/PendingApplications.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Application/PendingApplications.cshtml", typeof(AspNetCore.Views_Application_PendingApplications))]
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
#line 1 "/Users/Preshen/Desktop/COMS3002/PGASystem/PGASystem/Views/_ViewImports.cshtml"
using PGASystem;

#line default
#line hidden
#line 2 "/Users/Preshen/Desktop/COMS3002/PGASystem/PGASystem/Views/_ViewImports.cshtml"
using PGASystem.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"98fbe919da5bae1ac0f617254c66be47d489106b", @"/Views/Application/PendingApplications.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c88f98961700d698e8377b759d0c87927fdfec4b", @"/Views/_ViewImports.cshtml")]
    public class Views_Application_PendingApplications : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ApplicationsViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Application", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ViewFiles", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(32, 801, true);
            WriteLiteral(@"<div class=""container"">
    <div class=""row"">
        <div class=""col-lg-12"">
            <h3 class=""page-header"">Applications in Approval Process </h3>
            <div id="""">
                <table class=""table table-striped table-hover"" id="""">
                    <thead>
                        <tr>
                            <th>Application ID</th>
                            <th>Applicant </th>
                            <th>Programme</th>
                            <th>Status</th>
                            <th>Supervisor</th>
                            <th>Supervisor Decision</th>
                            <th>PGC Decision</th>
                            <th>Details</th>
                        </tr>
                    </thead>
                    <tbody>
");
            EndContext();
#line 22 "/Users/Preshen/Desktop/COMS3002/PGASystem/PGASystem/Views/Application/PendingApplications.cshtml"
                         foreach (var application in Model.Applications)
                        {

#line default
#line hidden
            BeginContext(934, 70, true);
            WriteLiteral("                            <tr>\r\n                                <td>");
            EndContext();
            BeginContext(1005, 14, false);
#line 25 "/Users/Preshen/Desktop/COMS3002/PGASystem/PGASystem/Views/Application/PendingApplications.cshtml"
                               Write(application.Id);

#line default
#line hidden
            EndContext();
            BeginContext(1019, 43, true);
            WriteLiteral("</td>\r\n                                <td>");
            EndContext();
            BeginContext(1063, 21, false);
#line 26 "/Users/Preshen/Desktop/COMS3002/PGASystem/PGASystem/Views/Application/PendingApplications.cshtml"
                               Write(application.FirstName);

#line default
#line hidden
            EndContext();
            BeginContext(1084, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(1086, 20, false);
#line 26 "/Users/Preshen/Desktop/COMS3002/PGASystem/PGASystem/Views/Application/PendingApplications.cshtml"
                                                      Write(application.LastName);

#line default
#line hidden
            EndContext();
            BeginContext(1106, 43, true);
            WriteLiteral("</td>\r\n                                <td>");
            EndContext();
            BeginContext(1150, 35, false);
#line 27 "/Users/Preshen/Desktop/COMS3002/PGASystem/PGASystem/Views/Application/PendingApplications.cshtml"
                               Write(application.Programme.ProgrammeName);

#line default
#line hidden
            EndContext();
            BeginContext(1185, 43, true);
            WriteLiteral("</td>\r\n                                <td>");
            EndContext();
            BeginContext(1229, 29, false);
#line 28 "/Users/Preshen/Desktop/COMS3002/PGASystem/PGASystem/Views/Application/PendingApplications.cshtml"
                               Write(application.ApplicationStatus);

#line default
#line hidden
            EndContext();
            BeginContext(1258, 43, true);
            WriteLiteral("</td>\r\n                                <td>");
            EndContext();
            BeginContext(1302, 28, false);
#line 29 "/Users/Preshen/Desktop/COMS3002/PGASystem/PGASystem/Views/Application/PendingApplications.cshtml"
                               Write(application.Supervisor.Title);

#line default
#line hidden
            EndContext();
            BeginContext(1330, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(1332, 31, false);
#line 29 "/Users/Preshen/Desktop/COMS3002/PGASystem/PGASystem/Views/Application/PendingApplications.cshtml"
                                                             Write(application.Supervisor.LastName);

#line default
#line hidden
            EndContext();
            BeginContext(1363, 43, true);
            WriteLiteral("</td>\r\n                                <td>");
            EndContext();
            BeginContext(1407, 30, false);
#line 30 "/Users/Preshen/Desktop/COMS3002/PGASystem/PGASystem/Views/Application/PendingApplications.cshtml"
                               Write(application.SupervisorApproval);

#line default
#line hidden
            EndContext();
            BeginContext(1437, 43, true);
            WriteLiteral("</td>\r\n                                <td>");
            EndContext();
            BeginContext(1481, 23, false);
#line 31 "/Users/Preshen/Desktop/COMS3002/PGASystem/PGASystem/Views/Application/PendingApplications.cshtml"
                               Write(application.PGCApproval);

#line default
#line hidden
            EndContext();
            BeginContext(1504, 43, true);
            WriteLiteral("</td>\r\n                                <td>");
            EndContext();
            BeginContext(1547, 105, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ac75b29def884173a0ef64daac2576b0", async() => {
                BeginContext(1644, 4, true);
                WriteLiteral("View");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-applicationId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 32 "/Users/Preshen/Desktop/COMS3002/PGASystem/PGASystem/Views/Application/PendingApplications.cshtml"
                                                                                                        WriteLiteral(application.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["applicationId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-applicationId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["applicationId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1652, 42, true);
            WriteLiteral("</td>\r\n                            </tr>\r\n");
            EndContext();
#line 34 "/Users/Preshen/Desktop/COMS3002/PGASystem/PGASystem/Views/Application/PendingApplications.cshtml"

                        }

#line default
#line hidden
            BeginContext(1723, 112, true);
            WriteLiteral("                    </tbody>\r\n                </table>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ApplicationsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591