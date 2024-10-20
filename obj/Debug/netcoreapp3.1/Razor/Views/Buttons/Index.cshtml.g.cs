#pragma checksum "D:\W_MIEW\adminc\Views\Buttons\Index.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "0fa966c18b3c8841c1983d2544377a6a34ba5d5562677ed06073ff0db3e5452e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Buttons_Index), @"mvc.1.0.view", @"/Views/Buttons/Index.cshtml")]
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
#line 1 "D:\W_MIEW\adminc\Views\_ViewImports.cshtml"
using SbAdmin;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\W_MIEW\adminc\Views\_ViewImports.cshtml"
using SbAdmin.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"0fa966c18b3c8841c1983d2544377a6a34ba5d5562677ed06073ff0db3e5452e", @"/Views/Buttons/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"a999d42d22da8658b929639a84eda24a54d0da0314b67405a26a944f771bc5d9", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Buttons_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 2 "D:\W_MIEW\adminc\Views\Buttons\Index.cshtml"
  
    ViewData["Title"] = "Buttons";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<!-- Page Heading -->
<h1 class=""h3 mb-4 text-gray-800"">Buttons</h1>

<div class=""row"">

    <div class=""col-lg-6"">

        <!-- Circle Buttons -->
        <div class=""card shadow mb-4"">
            <div class=""card-header py-3"">
                <h6 class=""m-0 font-weight-bold text-primary"">Circle Buttons</h6>
            </div>
            <div class=""card-body"">
                <p>
                    Use Font Awesome Icons (included with this theme package) along with the circle
                    buttons as shown in the examples below!
                </p>
                <!-- Circle Buttons (Default) -->
                <div class=""mb-2"">
                    <code>.btn-circle</code>
                </div>
                <a href=""#"" class=""btn btn-primary btn-circle"">
                    <i class=""fab fa-facebook-f""></i>
                </a>
                <a href=""#"" class=""btn btn-success btn-circle"">
                    <i class=""fas fa-check""></i>
                </a>
                <a href=""#"" ");
            WriteLiteral(@"class=""btn btn-info btn-circle"">
                    <i class=""fas fa-info-circle""></i>
                </a>
                <a href=""#"" class=""btn btn-warning btn-circle"">
                    <i class=""fas fa-exclamation-triangle""></i>
                </a>
                <a href=""#"" class=""btn btn-danger btn-circle"">
                    <i class=""fas fa-trash""></i>
                </a>
                <!-- Circle Buttons (Small) -->
                <div class=""mt-4 mb-2"">
                    <code>.btn-circle .btn-sm</code>
                </div>
                <a href=""#"" class=""btn btn-primary btn-circle btn-sm"">
                    <i class=""fab fa-facebook-f""></i>
                </a>
                <a href=""#"" class=""btn btn-success btn-circle btn-sm"">
                    <i class=""fas fa-check""></i>
                </a>
                <a href=""#"" class=""btn btn-info btn-circle btn-sm"">
                    <i class=""fas fa-info-circle""></i>
                </a>
                <a href=""#"" class=""btn");
            WriteLiteral(@" btn-warning btn-circle btn-sm"">
                    <i class=""fas fa-exclamation-triangle""></i>
                </a>
                <a href=""#"" class=""btn btn-danger btn-circle btn-sm"">
                    <i class=""fas fa-trash""></i>
                </a>
                <!-- Circle Buttons (Large) -->
                <div class=""mt-4 mb-2"">
                    <code>.btn-circle .btn-lg</code>
                </div>
                <a href=""#"" class=""btn btn-primary btn-circle btn-lg"">
                    <i class=""fab fa-facebook-f""></i>
                </a>
                <a href=""#"" class=""btn btn-success btn-circle btn-lg"">
                    <i class=""fas fa-check""></i>
                </a>
                <a href=""#"" class=""btn btn-info btn-circle btn-lg"">
                    <i class=""fas fa-info-circle""></i>
                </a>
                <a href=""#"" class=""btn btn-warning btn-circle btn-lg"">
                    <i class=""fas fa-exclamation-triangle""></i>
                </a>
               ");
            WriteLiteral(@" <a href=""#"" class=""btn btn-danger btn-circle btn-lg"">
                    <i class=""fas fa-trash""></i>
                </a>
            </div>
        </div>

        <!-- Brand Buttons -->
        <div class=""card shadow mb-4"">
            <div class=""card-header py-3"">
                <h6 class=""m-0 font-weight-bold text-primary"">Brand Buttons</h6>
            </div>
            <div class=""card-body"">
                <p>
                    Google and Facebook buttons are available featuring each company's respective
                    brand color. They are used on the user login and registration pages.
                </p>
                <p>
                    You can create more custom buttons by adding a new color variable in the
                    <code>_variables.scss</code> file and then using the Bootstrap button variant
                    mixin to create a new style, as demonstrated in the <code>_buttons.scss</code>
                    file.
                </p>
                <a href=""#"" cl");
            WriteLiteral(@"ass=""btn btn-google btn-block"">
                    <i class=""fab fa-google fa-fw""></i>
                    .btn-google
                </a>
                <a href=""#"" class=""btn btn-facebook btn-block"">
                    <i class=""fab fa-facebook-f fa-fw""></i> .btn-facebook
                </a>

            </div>
        </div>

    </div>

    <div class=""col-lg-6"">

        <div class=""card shadow mb-4"">
            <div class=""card-header py-3"">
                <h6 class=""m-0 font-weight-bold text-primary"">Split Buttons with Icon</h6>
            </div>
            <div class=""card-body"">
                <p>
                    Works with any button colors, just use the <code>.btn-icon-split</code> class and
                    the markup in the examples below. The examples below also use the
                    <code>.text-white-50</code> helper class on the icons for additional styling,
                    but it is not required.
                </p>
                <a href=""#"" class=""btn btn-primar");
            WriteLiteral(@"y btn-icon-split"">
                    <span class=""icon text-white-50"">
                        <i class=""fas fa-flag""></i>
                    </span>
                    <span class=""text"">Split Button Primary</span>
                </a>
                <div class=""my-2""></div>
                <a href=""#"" class=""btn btn-success btn-icon-split"">
                    <span class=""icon text-white-50"">
                        <i class=""fas fa-check""></i>
                    </span>
                    <span class=""text"">Split Button Success</span>
                </a>
                <div class=""my-2""></div>
                <a href=""#"" class=""btn btn-info btn-icon-split"">
                    <span class=""icon text-white-50"">
                        <i class=""fas fa-info-circle""></i>
                    </span>
                    <span class=""text"">Split Button Info</span>
                </a>
                <div class=""my-2""></div>
                <a href=""#"" class=""btn btn-warning btn-icon-split"">
          ");
            WriteLiteral(@"          <span class=""icon text-white-50"">
                        <i class=""fas fa-exclamation-triangle""></i>
                    </span>
                    <span class=""text"">Split Button Warning</span>
                </a>
                <div class=""my-2""></div>
                <a href=""#"" class=""btn btn-danger btn-icon-split"">
                    <span class=""icon text-white-50"">
                        <i class=""fas fa-trash""></i>
                    </span>
                    <span class=""text"">Split Button Danger</span>
                </a>
                <div class=""my-2""></div>
                <a href=""#"" class=""btn btn-secondary btn-icon-split"">
                    <span class=""icon text-white-50"">
                        <i class=""fas fa-arrow-right""></i>
                    </span>
                    <span class=""text"">Split Button Secondary</span>
                </a>
                <div class=""my-2""></div>
                <a href=""#"" class=""btn btn-light btn-icon-split"">
                 ");
            WriteLiteral(@"   <span class=""icon text-gray-600"">
                        <i class=""fas fa-arrow-right""></i>
                    </span>
                    <span class=""text"">Split Button Light</span>
                </a>
                <div class=""mb-4""></div>
                <p>Also works with small and large button classes!</p>
                <a href=""#"" class=""btn btn-primary btn-icon-split btn-sm"">
                    <span class=""icon text-white-50"">
                        <i class=""fas fa-flag""></i>
                    </span>
                    <span class=""text"">Split Button Small</span>
                </a>
                <div class=""my-2""></div>
                <a href=""#"" class=""btn btn-primary btn-icon-split btn-lg"">
                    <span class=""icon text-white-50"">
                        <i class=""fas fa-flag""></i>
                    </span>
                    <span class=""text"">Split Button Large</span>
                </a>
            </div>
        </div>

    </div>

</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
