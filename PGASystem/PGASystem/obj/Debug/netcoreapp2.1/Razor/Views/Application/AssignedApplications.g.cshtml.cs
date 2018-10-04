#pragma checksum "/Users/marc/Desktop/COMS3002/PGASystem/PGASystem/Views/Application/AssignedApplications.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9c433bd9793921092b9417b896f6abe2a34bb5cf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Application_AssignedApplications), @"mvc.1.0.view", @"/Views/Application/AssignedApplications.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Application/AssignedApplications.cshtml", typeof(AspNetCore.Views_Application_AssignedApplications))]
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
#line 1 "/Users/marc/Desktop/COMS3002/PGASystem/PGASystem/Views/_ViewImports.cshtml"
using PGASystem;

#line default
#line hidden
#line 2 "/Users/marc/Desktop/COMS3002/PGASystem/PGASystem/Views/_ViewImports.cshtml"
using PGASystem.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9c433bd9793921092b9417b896f6abe2a34bb5cf", @"/Views/Application/AssignedApplications.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c88f98961700d698e8377b759d0c87927fdfec4b", @"/Views/_ViewImports.cshtml")]
    public class Views_Application_AssignedApplications : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ApplicationsViewModel>
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
            WriteLiteral("  ");
            EndContext();
            BeginContext(32, 700, true);
            WriteLiteral(@"
<!--Web page to view Applications assigned to a specific Supervisor/PGC-->

<div class=""container"">

    <div class=""row"">
        <div class=""col-lg-12"">
            <h3 class=""page-header"">Current Applications</h3>
            <div id="""">
                <table class=""table table-striped table-hover"" id="""">
                    <thead>
                        <tr>
                            <th>ID</th>
                            <th>Applicant </th>
                            <th>Programme</th>
                            <th>Status</th>
                            <th>Details</th>
                        </tr>
                    </thead>
                    <tbody>
");
            EndContext();
#line 22 "/Users/marc/Desktop/COMS3002/PGASystem/PGASystem/Views/Application/AssignedApplications.cshtml"
              foreach (var application in Model.Applications)
            {

#line default
#line hidden
            BeginContext(810, 48, true);
            WriteLiteral("                <tr>\r\n\r\n                    <td>");
            EndContext();
            BeginContext(859, 14, false);
#line 26 "/Users/marc/Desktop/COMS3002/PGASystem/PGASystem/Views/Application/AssignedApplications.cshtml"
                   Write(application.Id);

#line default
#line hidden
            EndContext();
            BeginContext(873, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(905, 21, false);
#line 27 "/Users/marc/Desktop/COMS3002/PGASystem/PGASystem/Views/Application/AssignedApplications.cshtml"
                   Write(application.FirstName);

#line default
#line hidden
            EndContext();
            BeginContext(926, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(928, 20, false);
#line 27 "/Users/marc/Desktop/COMS3002/PGASystem/PGASystem/Views/Application/AssignedApplications.cshtml"
                                          Write(application.LastName);

#line default
#line hidden
            EndContext();
            BeginContext(948, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(980, 35, false);
#line 28 "/Users/marc/Desktop/COMS3002/PGASystem/PGASystem/Views/Application/AssignedApplications.cshtml"
                   Write(application.Programme.ProgrammeName);

#line default
#line hidden
            EndContext();
            BeginContext(1015, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(1047, 29, false);
#line 29 "/Users/marc/Desktop/COMS3002/PGASystem/PGASystem/Views/Application/AssignedApplications.cshtml"
                   Write(application.ApplicationStatus);

#line default
#line hidden
            EndContext();
            BeginContext(1076, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(1107, 105, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6a780c1b772c498d9f3c4ab256ad4581", async() => {
                BeginContext(1204, 4, true);
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
#line 30 "/Users/marc/Desktop/COMS3002/PGASystem/PGASystem/Views/Application/AssignedApplications.cshtml"
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
            BeginContext(1212, 30, true);
            WriteLiteral("</td>\r\n                </tr>\r\n");
            EndContext();
#line 32 "/Users/marc/Desktop/COMS3002/PGASystem/PGASystem/Views/Application/AssignedApplications.cshtml"

}

#line default
#line hidden
            BeginContext(1247, 120, true);
            WriteLiteral("                    </tbody>\r\n                </table>\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n</div>\r\n\r\n\r\n\r\n");
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
