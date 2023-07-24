#pragma checksum "D:\Ôn C# 2023\CongNgheStore\CongNgheStore\Views\Order\Check.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2ffb3957edac652cfab2725c3eda36602ac37a18"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Order_Check), @"mvc.1.0.view", @"/Views/Order/Check.cshtml")]
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
#line 1 "D:\Ôn C# 2023\CongNgheStore\CongNgheStore\Views\_ViewImports.cshtml"
using CongNgheStore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Ôn C# 2023\CongNgheStore\CongNgheStore\Views\_ViewImports.cshtml"
using CongNgheStore.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2ffb3957edac652cfab2725c3eda36602ac37a18", @"/Views/Order/Check.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"980ca5096ad25b66c297bd844fd6a2a7b1e4d926", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Order_Check : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onsubmit", new global::Microsoft.AspNetCore.Html.HtmlString("return false"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "D:\Ôn C# 2023\CongNgheStore\CongNgheStore\Views\Order\Check.cshtml"
  
    ViewBag.Title = "Kiểm tra đơn hàng";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"render-check-order\">\r\n    <div class=\"action\">\r\n        <h4 class=\"col d-flex justify-content-center\">Kiểm tra đơn hàng của bạn</h4>\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2ffb3957edac652cfab2725c3eda36602ac37a184028", async() => {
                WriteLiteral(@"
            <div class=""form-group"">
                <input  type=""text"" id=""text-check"" class=""form-control""/>
                <span for=""text-check"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <button id=""sub-check"" class=""btn btn-success"">Tra cứu</button>
            </div>
        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
    </div>
    <div class=""value"">
        
    </div>
</div>


<script>
    $(document).ready(function () {
        var urlApi = 'https://localhost:44311/api/';

        var orderSucceed = window.sessionStorage.getItem('order-succeed');
        if (orderSucceed != null) {
            var urlApiOrder = urlApi + 'Order/GetOrderById/' + orderSucceed;
            sendRequest(urlApiOrder, null, 'get', true);
        }


        
        $('#sub-check').click(function(){
            var urlApiOrder = urlApi + 'Order/GetOrderById/' + ($('#text-check').val());
            sendRequest(urlApiOrder, null, 'get', true); 
        });
         
        function sendRequest(url, data, method, async) {
            $.ajax({
                url: url,
                async: async,
                data: data,
                error: function(response) {
                    $('#text-check ~ span').html('Đơn hàng không tồn tại');
                },
                success: function(response) {
  ");
            WriteLiteral(@"                  $('#text-check ~ span').html('');

                    var order = response.data;
                    var total = 0;

                    //order
                    $('.render-check-order .value').html('');
                    $('.render-check-order .value').append(
                        '<table class=""table-order"" >'+
                            '<tr>'+
                                '<td style=""width: 200px; vertical-align: top;"">Mã hóa đơn: </td>'+
                                '<td >'+ order.Id +'</td>'+
                            '</tr>'+
                            '<tr>'+
                                '<td style=""width: 200px; vertical-align: top;"" >Sdt người nhận: </td>'+
                                '<td>'+ order.PhoneNumber +'</td>'+
                            '</tr>'+
                            '<tr>'+
                                '<td style=""width: 200px; vertical-align: top;"">Tên người nhận: </td>'+
                                '<td>'+ orde");
            WriteLiteral(@"r.Name +'</td>'+
                            '</tr>'+
                            '<tr>'+
                                '<td style=""width: 200px; vertical-align: top;"">Địa chỉ: </td>'+
                                '<td>'+ order.Address +'</td>'+
                            '</tr>'+
                            '<tr>'+
                                '<td style=""width: 200px; vertical-align: top;"">Ghi chú khách hàng: </td>'+
                                '<td>'+ order.CustomerNotes +'</td>'+
                            '</tr>'+
                            '<tr>'+
                                '<td style=""width: 200px; vertical-align: top;"">Ghi chú cửa hàng: </td>'+
                                '<td>'+ order.StoreNotes +'</td>'+
                            '</tr>'+
                            '<tr>'+
                                '<td style=""width: 200px; vertical-align: top;"">Ngày: </td>'+
                                '<td>'+ order.Date +'</td>'+
                            '</");
            WriteLiteral(@"tr>'+
                            '<tr>'+
                                '<td style=""width: 200px; vertical-align: top;"">Trạng thái: </td>'+
                                '<td>'+ order.Status +'</td>'+
                            '</tr>'+
                            '<tr>'+
                                '<td colspan=""2"">'+
                                    '<table class=""table-detail table-hover"">'+
                                        '<thead>'+
                                            '<tr>'+
                                                '<th style=""width: 100px;""></th>'+
                                                '<th style=""width: 240px;"">Tên sản phẩm</th>'+
                                                '<th style=""width: 120px;"">Ram/Rom</th>'+
                                                '<th style=""width: 120px;"">Màu sắc</th>'+
                                                '<th style=""width: 80px;"">Số lượng</th>'+
                                                ");
            WriteLiteral(@"'<th style=""width: 120px;"">Giá</th>'+
                                            '</tr>'+
                                        '</thead>'+
                                        '<tbody>'+
                                        '</tbody>'+
                                    '</table>'+
                                '</td>'+
                            '</tr>'+
                            '<tr style=""height: 50px; font-weight: 700; font-size: 20px;"">'+
                                '<td style=""text-align: end;"" colspan=""2"">Tổng: <span class=""total""></span></td>'+
                            '</tr>'+
                        '</table>'
                    );

                    let formatPrice = new Intl.NumberFormat('vi-VN', {
                        style: 'currency',
                        currency: 'VND',
                    });
                    new Intl.NumberFormat('en-US').format(price)

                    //table-detail
                    for (var key in order.Detai");
            WriteLiteral(@"ls) {
                        var detail = order.Details[key];
                        var url = `/${detail.Product.Category.UrlHandle}/${detail.Product.Brand.UrlHandle}/${detail.Product.Id}`;
                        var urlImg = `${response.Url}${detail.Product.Category.Name}/${detail.Product.Brand.Name}/${detail.Product.Name}/${detail.Color.Img}`;
                        var name = detail.Product.Name;
                        var ramRom = detail.MemoryAndStorage.Ram + '/' + detail.MemoryAndStorage.Rom;
                        var color = detail.Color.Name;
                        var quantity = detail.Quantity;
                        var price = (detail.Product.SellingPrice + detail.MemoryAndStorage.Price + detail.Color.Price) * detail.Quantity;

                        total += price;

                        price = formatPrice.format(price);

                        $('.table-detail tbody').append(
                            
                            '<tr>'+
                        ");
            WriteLiteral(@"    
                                '<td style=""width: 100px;""><img  src=""'+ urlImg +'""></td>'+
                                '<td style=""width: 240px;""><a href=""'+ url +'"">'+ name +'</a></td>'+
                                '<td style=""width: 120px;"">'+ ramRom  +'</td>'+
                                '<td style=""width: 120px;"">'+ color +'</td>'+
                                '<td style=""width: 80px;"">'+ quantity +'</td>'+
                                '<td style=""width: 120px;"">'+ price +'</td>'+
                                
                            '</tr>'
                            
                        );
                    }
                    total = formatPrice.format(total);
                    $('.total').html(total);
                },
                type: method,
                headers: {'Content-Type': 'application/json'},
                contentType: 'application/json; charset=utf-8',
                dataType: 'json'
            });
        }
    });");
            WriteLiteral("\r\n</script>\r\n");
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