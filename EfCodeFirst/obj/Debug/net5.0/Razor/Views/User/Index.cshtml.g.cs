#pragma checksum "C:\Users\Calal\source\repos\EfCodeFirst\EfCodeFirst\Views\User\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "652eee9d40db7ce01f2fe56a10e1302fa285bdd0"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"652eee9d40db7ce01f2fe56a10e1302fa285bdd0", @"/Views/User/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6e76184102deb19503701ff1acdacb52f141e238", @"/Views/_ViewImports.cshtml")]
    public class Views_User_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<UsersViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("selected", new global::Microsoft.AspNetCore.Html.HtmlString("selected"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "10", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "25", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "50", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "100", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<!--begin::Card-->
<div class=""card card-custom gutter-b"">
    <div class=""card-header flex-wrap py-3"">
        <div class=""card-title"">
            <h3 class=""card-label"">
                İstifadəçilər
            </h3>>
        </div>
        <div class=""card-toolbar"">
            <!--begin::Dropdown-->
            <div class=""dropdown dropdown-inline mr-2"">
                <button type=""button"" class=""btn btn-light-primary font-weight-bolder dropdown-toggle"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
                    <span class=""svg-icon svg-icon-md"">
                        <!--begin::Svg Icon | path:/metronic/theme/html/demo1/dist/assets/media/svg/icons/Design/PenAndRuller.svg-->
                        <svg xmlns=""http://www.w3.org/2000/svg"" xmlns:xlink=""http://www.w3.org/1999/xlink"" width=""24px"" height=""24px"" viewBox=""0 0 24 24"" version=""1.1"">
                            <g stroke=""none"" stroke-width=""1"" fill=""none"" fill-rule=""evenodd"">
                      ");
            WriteLiteral(@"          <rect x=""0"" y=""0"" width=""24"" height=""24"" />
                                <path d=""M3,16 L5,16 C5.55228475,16 6,15.5522847 6,15 C6,14.4477153 5.55228475,14 5,14 L3,14 L3,12 L5,12 C5.55228475,12 6,11.5522847 6,11 C6,10.4477153 5.55228475,10 5,10 L3,10 L3,8 L5,8 C5.55228475,8 6,7.55228475 6,7 C6,6.44771525 5.55228475,6 5,6 L3,6 L3,4 C3,3.44771525 3.44771525,3 4,3 L10,3 C10.5522847,3 11,3.44771525 11,4 L11,19 C11,19.5522847 10.5522847,20 10,20 L4,20 C3.44771525,20 3,19.5522847 3,19 L3,16 Z"" fill=""#000000"" opacity=""0.3"" />
                                <path d=""M16,3 L19,3 C20.1045695,3 21,3.8954305 21,5 L21,15.2485298 C21,15.7329761 20.8241635,16.200956 20.5051534,16.565539 L17.8762883,19.5699562 C17.6944473,19.7777745 17.378566,19.7988332 17.1707477,19.6169922 C17.1540423,19.602375 17.1383289,19.5866616 17.1237117,19.5699562 L14.4948466,16.565539 C14.1758365,16.200956 14,15.7329761 14,15.2485298 L14,5 C14,3.8954305 14.8954305,3 16,3 Z"" fill=""#000000"" />
                            </g>
       ");
            WriteLiteral(@"                 </svg>
                        <!--end::Svg Icon-->
                    </span>İxrac et
                </button>
                <!--begin::Dropdown Menu-->
                <div class=""dropdown-menu dropdown-menu-sm dropdown-menu-right"">
                    <!--begin::Navigation-->
                    <ul class=""navi flex-column navi-hover py-2"">
                        <li class=""navi-header font-weight-bolder text-uppercase font-size-sm text-primary pb-2"">Choose an option:</li>
                        <li class=""navi-item"">
                            <a id=""ExportLnkExcel"" class=""navi-link"" href=""javascript:__doPostBack(&#39;ctl00$Body$ExportLnkExcel&#39;,&#39;&#39;)"">
                                <span class=""navi-icon"">
                                    <i class=""la la-file-excel-o""></i>
                                </span>
                                <span class=""navi-text"">Excel</span>
                            </a>
                        </li>
        ");
            WriteLiteral(@"                <li class=""navi-item"">
                            <a id=""ExportLnkWord"" class=""navi-link"" href=""javascript:__doPostBack(&#39;ctl00$Body$ExportLnkWord&#39;,&#39;&#39;)"">
                                <span class=""navi-icon"">
                                    <i class=""la la-file-text-o""></i>
                                </span>
                                <span class=""navi-text"">Word</span>
                            </a>
                        </li>


                    </ul>
                    <!--end::Navigation-->
                </div>
                <!--end::Dropdown Menu-->
            </div>
            <!--end::Dropdown-->
            <!--begin::Button-->
            <a id=""DeleteCh"" class=""btn btn-danger mr-2"" href=""javascript:__doPostBack(&#39;ctl00$Body$DeleteCh&#39;,&#39;&#39;)"">
                <i class=""icon-xl far fa-trash-alt fa-lg""></i>Seçilmişləri Sil
            </a>
            <a id=""ActiveCh"" class=""btn btn-success mr-2"" href=""javascri");
            WriteLiteral(@"pt:__doPostBack(&#39;ctl00$Body$ActiveCh&#39;,&#39;&#39;)"">
                <i class='icon-xl far fa-check-square fa-lg'></i>Seçilmişləri Aktiv et
            </a>
            <a id=""DeactiveCh"" class=""btn btn-warning font-weight-bolder mr-2"" href=""javascript:__doPostBack(&#39;ctl00$Body$DeactiveCh&#39;,&#39;&#39;)"">
                <i class='icon-xl far fa-square fa-lg'></i>Seçilmişləri Deaktiv et
            </a>

            <a id=""LnkInsertbtn"" class=""btn btn-primary font-weight-bolder mr-2"" href=""javascript:__doPostBack(&#39;ctl00$Body$LnkInsertbtn&#39;,&#39;&#39;)"">
                <i class=""la la-plus""></i>Yeni
            </a>
            <!--end::Button-->
        </div>
    </div>
    <div class=""card-body"">
        <!--begin: Datatable-->
        <div id=""kt_datatable1_wrapper"" class=""dataTables_wrapper dt-bootstrap4 no-footer"">
            <div class=""row"">
                <div class=""col-sm-6 text-left"">
                    <div id=""kt_datatable1_filter"" class=""dataTables_filter");
            WriteLiteral(@""">
                        <label>
                            Axtar :
                            <input name=""ctl00$Body$SearchAlltxt"" type=""text"" onchange=""javascript:setTimeout(&#39;__doPostBack(\&#39;ctl00$Body$SearchAlltxt\&#39;,\&#39;\&#39;)&#39;, 0)"" onkeypress=""if (WebForm_TextBoxKeyHandler(event) == false) return false;"" id=""SearchAlltxt"" class=""form-control form-control-sm"" />
                        </label>
                    </div>
                </div>
            </div>
            <div class=""row table-responsive"">
                <div class=""col-sm-12"">
                    <div>
                        <table class=""table table-bordered"" cellspacing=""0"" rules=""all"" border=""1"" id=""GridView1"" style=""border-collapse:collapse;"">
                            <tr>
                                <th>
                                    <span>Record ID</span>:
                                </th>
                                <th>
                                    <span>Name<");
            WriteLiteral(@"/span>:
                                </th>
                                <th>
                                    <span>Username</span>:
                                </th>
                                <th>Active</th>
                                <th class=""ai""><i class='icon-xl far fa-check-square fa-lg'></i></th>
                                <th class=""ai""><i class='la la-edit fa-lg'></i></th>
                                <th class=""ai""><i class='la la-trash fa-lg'></i></th>
                            </tr>
");
#nullable restore
#line 105 "C:\Users\Calal\source\repos\EfCodeFirst\EfCodeFirst\Views\User\Index.cshtml"
                             foreach (var item in Model)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 110 "C:\Users\Calal\source\repos\EfCodeFirst\EfCodeFirst\Views\User\Index.cshtml"
                                   Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 113 "C:\Users\Calal\source\repos\EfCodeFirst\EfCodeFirst\Views\User\Index.cshtml"
                                   Write(item.username);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 116 "C:\Users\Calal\source\repos\EfCodeFirst\EfCodeFirst\Views\User\Index.cshtml"
                                   Write(item.active);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                    </td>
                                    <td>
                                        <span id=""Activelbl""><span class='label label-lg font-weight-bold label-light-success label-inline'>Success</span></span>
                                    </td>
                                    <td>
                                        <a onclick=""return active_deactive(2 );"" id=""LnkActive"" class=""btn btn-sm btn-clean btn-icon"" title=""Active"" href=""javascript:__doPostBack(&#39;ctl00$Body$GridView1$ctl02$LnkActive&#39;,&#39;&#39;)""><i class='icon-xl far fa-check-square fa-lg'></i></a>
                                    </td>
                                    <td>
                                        <a id=""LnkEdit"" class=""btn btn-sm btn-clean btn-icon"" title=""Edit details"" href=""javascript:__doPostBack(&#39;ctl00$Body$GridView1$ctl02$LnkEdit&#39;,&#39;&#39;)"">
                                            <i class='la la-edit fa-lg'></i>
                           ");
            WriteLiteral(@"             </a>
                                    </td>
                                    <td>
                                        <a onclick=""return (confirm(&quot;Are you sure you want to delete this element?&quot;));"" id=""LnkDelete"" class=""btn btn-sm btn-clean btn-icon"" title=""Delete"" href=""javascript:__doPostBack(&#39;ctl00$Body$GridView1$ctl02$LnkDelete&#39;,&#39;&#39;)"">
                                            <i class=""la la-trash fa-lg""></i>
                                        </a>
                                    </td>
                                </tr>
");
#nullable restore
#line 135 "C:\Users\Calal\source\repos\EfCodeFirst\EfCodeFirst\Views\User\Index.cshtml"

                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        </table>
                    </div>
                </div>
            </div>
            <div class=""row"">
                <div class=""col-sm-12 col-md-5"">
                    <div class=""dataTables_info"" id=""kt_datatable1_info"" role=""status"" aria-live=""polite"">


                    </div>
                </div>
                <div class=""col-sm-12 col-md-7 dataTables_pager"">
                    <div class=""dataTables_length"" id=""kt_datatable1_length"">
                        <label>
                            Element
                            <select name=""ctl00$Body$SizeTableDrp"" onchange=""javascript:setTimeout(&#39;__doPostBack(\&#39;ctl00$Body$SizeTableDrp\&#39;,\&#39;\&#39;)&#39;, 0)"" id=""SizeTableDrp"" class=""custom-select custom-select-sm form-control form-control-sm"" name=""kt_datatable1_length"" aria-controls=""kt_datatable1"">
                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "652eee9d40db7ce01f2fe56a10e1302fa285bdd016111", async() => {
                WriteLiteral("10");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "652eee9d40db7ce01f2fe56a10e1302fa285bdd017382", async() => {
                WriteLiteral("25");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "652eee9d40db7ce01f2fe56a10e1302fa285bdd018570", async() => {
                WriteLiteral("50");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "652eee9d40db7ce01f2fe56a10e1302fa285bdd019758", async() => {
                WriteLiteral("100");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                            </select>
                            Göstər
                        </label>
                    </div>
                    <div class=""dataTables_paginate paging_simple_numbers"" id=""kt_datatable1_paginate"">
                        <ul class=""pagination"">
                            <li class='paginate_button page-item previous disabled' id='kt_datatable1_previous'>
                                <a href='users2.aspx?page=1' class='page-link'><i class='ki ki-bold-double-arrow-back icon-xs'></i></a>
                            </li>
                            <li class='paginate_button page-item previous disabled' id='kt_datatable1_previous'>
                                <a href='#' aria-controls='kt_datatable1' data-dt-idx='0' tabindex='0' class='page-link'><i class='ki ki-arrow-back'></i></a>
                            </li>
                            <li class='paginate_button page-item active'><a href='javascript:void();' aria-controls='kt_datatable1' data-");
            WriteLiteral(@"dt-idx='1' tabindex='0' class='page-link'>1</a></li>
                            <li class='paginate_button page-item next disabled' id='kt_datatable1_next'><a href='users2.aspx?page=2' aria-controls='kt_datatable1' data-dt-idx='6' tabindex='0' class='page-link'><i class='ki ki-arrow-next'></i></a></li>
                            <li class='paginate_button page-item disabled' id='kt_datatable1_next'><a href='users2.aspx?page=1' aria-controls='kt_datatable1' data-dt-idx='6' tabindex='0' class='page-link'><i class='ki ki-bold-double-arrow-next icon-xs'></i></a></li>
                        </ul>
                    </div>
                </div>
            </div>
            <!--end: Datatable-->
        </div>
    </div>
    <!--end::Card-->
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<UsersViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
