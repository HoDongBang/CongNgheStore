#pragma checksum "D:\Ôn C# 2023\CongNgheStore\CongNgheStore\Views\Home\Search.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "86dd1cdd82d1e3b0ddfa1f37a31785afd389fc2a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Search), @"mvc.1.0.view", @"/Views/Home/Search.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"86dd1cdd82d1e3b0ddfa1f37a31785afd389fc2a", @"/Views/Home/Search.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"980ca5096ad25b66c297bd844fd6a2a7b1e4d926", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_Search : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Ôn C# 2023\CongNgheStore\CongNgheStore\Views\Home\Search.cshtml"
  
    ViewBag.Title = "Tìm kiếm";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""render-product"">
    <div class=""product"">
        <div class=""list-item"">
        </div>      
    </div>
</div>


<script>
    $(document).ready(function () {
        var urlApi = 'https://localhost:44311/api/';
        var urlApiSearch = urlApi + 'Product/GetProductsBySearch';
        const queryString = window.location.search;

        const urlParams = new URLSearchParams(queryString);
        const value = urlParams.get('key');
        
        function sendRequest(url, data, method, async) {
            $.ajax({
                url: url,
                async: async,
                data: data,
                success: function(response) {
                    for (var key in response.data) {
                        var product = response.data[key];
                        var urlImg = `${response.Url}${product.Category.Name}/${product.Brand.Name}/${product.Name}/${product.Colors[0].Img}`;
                        var name = `${product.Name} ${product.MemoryAndStor");
            WriteLiteral(@"ages[0].Ram}/${product.MemoryAndStorages[0].Rom} - Chính hãng`;
                        var urlProduct = `/${product.Category.UrlHandle}/${product.Brand.UrlHandle}/${product.Id}`;

                        let formatPrice = new Intl.NumberFormat('vi-VN', {
                            style: 'currency',
                            currency: 'VND',
                        });
                        new Intl.NumberFormat('en-US').format(price)

                        var price = formatPrice.format(product.SellingPrice + product.Colors[0].Price + product.MemoryAndStorages[0].Price);

                        $('.list-item').append(
                            '<div class=""item"">' +
                                '<a href=""'+ urlProduct +'"">' +
                                    '<img src=""' + urlImg + '"">' +
                                    '<div class=""info"">' +
                                        '<span class=""name"">' + name + '</span>' +
                                        '<span ");
            WriteLiteral(@"class=""price"">' + price + '</span>' +
                                    '</div>' +
                                '</a>' +
                            '</div>'
                        );
                    }
                },
                type: method,
                headers: {'Content-Type': 'application/json'},
                contentType: 'application/json; charset=utf-8',
                dataType: 'json'
            });
        }
        var data = {
                value: value
            };
        sendRequest(urlApiSearch, data, 'get', true);          
    });
</script>");
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