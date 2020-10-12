#pragma checksum "E:\Git\CommonBaseRole\CommonBaseRoleUI\Views\Shared\_LeftMenu.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ab50b9896c7e3dcd4d186bb17296bea488ae7a9b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__LeftMenu), @"mvc.1.0.view", @"/Views/Shared/_LeftMenu.cshtml")]
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
#line 1 "E:\Git\CommonBaseRole\CommonBaseRoleUI\Views\_ViewImports.cshtml"
using CommonBaseRoleUI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Git\CommonBaseRole\CommonBaseRoleUI\Views\_ViewImports.cshtml"
using CommonBaseRoleUI.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "E:\Git\CommonBaseRole\CommonBaseRoleUI\Views\Shared\_LeftMenu.cshtml"
using Model.EntityModel.BaseRole;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ab50b9896c7e3dcd4d186bb17296bea488ae7a9b", @"/Views/Shared/_LeftMenu.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1bff575286deb02e41b7457970d37efc38275778", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__LeftMenu : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<AdminModule>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<!-- Left side column. contains the logo and sidebar -->
<aside class=""main-sidebar"">
    <!-- sidebar: style can be found in sidebar.less -->
    <section class=""sidebar"">
        <!-- /.search form -->
        <!-- sidebar menu: : style can be found in sidebar.less -->
        <ul class=""sidebar-menu"">
            <li class=""header""> Header </li>
");
#nullable restore
#line 11 "E:\Git\CommonBaseRole\CommonBaseRoleUI\Views\Shared\_LeftMenu.cshtml"
             foreach (var item in Model)
            {
                if (item.ParentModuleID == 0)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li class=\"treeview\">\r\n                        <a href=\"#\"><i");
            BeginWriteAttribute("class", " class=\"", 624, "\"", 646, 1);
#nullable restore
#line 16 "E:\Git\CommonBaseRole\CommonBaseRoleUI\Views\Shared\_LeftMenu.cshtml"
WriteAttributeValue("", 632, item.MenuIcon, 632, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></i><span>");
#nullable restore
#line 16 "E:\Git\CommonBaseRole\CommonBaseRoleUI\Views\Shared\_LeftMenu.cshtml"
                                                                   Write(item.ModuleName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span><i class=\"fa fa-angle-left pull-right\"> </i></a>\r\n                        <ul class=\"treeview-menu\">\r\n");
#nullable restore
#line 18 "E:\Git\CommonBaseRole\CommonBaseRoleUI\Views\Shared\_LeftMenu.cshtml"
                             foreach (var childrenItem in item.ChildrenModules)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <li> <a style=\"padding-left:20px\" class=\"nav-link\"");
            BeginWriteAttribute("onclick", " onclick=\"", 977, "\"", 1122, 11);
            WriteAttributeValue("", 987, "addTabs({id:\'", 987, 13, true);
#nullable restore
#line 20 "E:\Git\CommonBaseRole\CommonBaseRoleUI\Views\Shared\_LeftMenu.cshtml"
WriteAttributeValue("", 1000, childrenItem.ModuleID, 1000, 22, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1022, "\',title:", 1022, 8, true);
            WriteAttributeValue(" ", 1030, "\'", 1031, 2, true);
#nullable restore
#line 20 "E:\Git\CommonBaseRole\CommonBaseRoleUI\Views\Shared\_LeftMenu.cshtml"
WriteAttributeValue("", 1032, childrenItem.ModuleName, 1032, 24, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1056, "\',close:", 1056, 8, true);
            WriteAttributeValue(" ", 1064, "true,url:", 1065, 10, true);
            WriteAttributeValue(" ", 1074, "\'", 1075, 2, true);
#nullable restore
#line 20 "E:\Git\CommonBaseRole\CommonBaseRoleUI\Views\Shared\_LeftMenu.cshtml"
WriteAttributeValue("", 1076, childrenItem.MenuPath, 1076, 22, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1098, "\',urlType:", 1098, 10, true);
            WriteAttributeValue(" ", 1108, "\'relative\'});", 1109, 14, true);
            EndWriteAttribute();
            WriteLiteral("><i");
            BeginWriteAttribute("class", " class=\"", 1126, "\"", 1156, 1);
#nullable restore
#line 20 "E:\Git\CommonBaseRole\CommonBaseRoleUI\Views\Shared\_LeftMenu.cshtml"
WriteAttributeValue("", 1134, childrenItem.MenuIcon, 1134, 22, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></i>");
#nullable restore
#line 20 "E:\Git\CommonBaseRole\CommonBaseRoleUI\Views\Shared\_LeftMenu.cshtml"
                                                                                                                                                                                                                                                                      Write(childrenItem.ModuleName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a> </li>\r\n");
#nullable restore
#line 21 "E:\Git\CommonBaseRole\CommonBaseRoleUI\Views\Shared\_LeftMenu.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </ul>\r\n                    </li>\r\n");
#nullable restore
#line 24 "E:\Git\CommonBaseRole\CommonBaseRoleUI\Views\Shared\_LeftMenu.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li> <a style=\"padding-left:20px\" class=\"nav-link\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1417, "\"", 1537, 11);
            WriteAttributeValue("", 1427, "addTabs({id:\'", 1427, 13, true);
#nullable restore
#line 27 "E:\Git\CommonBaseRole\CommonBaseRoleUI\Views\Shared\_LeftMenu.cshtml"
WriteAttributeValue("", 1440, item.ModuleID, 1440, 14, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1454, "\',title:", 1454, 8, true);
            WriteAttributeValue(" ", 1462, "\'", 1463, 2, true);
#nullable restore
#line 27 "E:\Git\CommonBaseRole\CommonBaseRoleUI\Views\Shared\_LeftMenu.cshtml"
WriteAttributeValue("", 1464, item.MenuTitle, 1464, 15, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1479, "\',close:", 1479, 8, true);
            WriteAttributeValue(" ", 1487, "true,url:", 1488, 10, true);
            WriteAttributeValue(" ", 1497, "\'", 1498, 2, true);
#nullable restore
#line 27 "E:\Git\CommonBaseRole\CommonBaseRoleUI\Views\Shared\_LeftMenu.cshtml"
WriteAttributeValue("", 1499, item.MenuPath, 1499, 14, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1513, "\',urlType:", 1513, 10, true);
            WriteAttributeValue(" ", 1523, "\'relative\'});", 1524, 14, true);
            EndWriteAttribute();
            WriteLiteral("><i");
            BeginWriteAttribute("class", " class=\"", 1541, "\"", 1563, 1);
#nullable restore
#line 27 "E:\Git\CommonBaseRole\CommonBaseRoleUI\Views\Shared\_LeftMenu.cshtml"
WriteAttributeValue("", 1549, item.MenuIcon, 1549, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></i><span>");
#nullable restore
#line 27 "E:\Git\CommonBaseRole\CommonBaseRoleUI\Views\Shared\_LeftMenu.cshtml"
                                                                                                                                                                                                                               Write(item.ModuleName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span> </a> </li>\r\n");
#nullable restore
#line 28 "E:\Git\CommonBaseRole\CommonBaseRoleUI\Views\Shared\_LeftMenu.cshtml"
                }
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </ul>\r\n    </section>\r\n</aside>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<AdminModule>> Html { get; private set; }
    }
}
#pragma warning restore 1591
