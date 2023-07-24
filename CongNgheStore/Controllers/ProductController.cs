using CongNgheStore.Models.ViewModel;
using CongNgheStore.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CongNgheStore.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    //[NonController]
    public class ProductController : Controller
    {
        private readonly IOptions<BackEndApiSetting> _backEndApiSetting;
        public ProductController(IOptions<BackEndApiSetting> backEndApiSetting)
        {
            _backEndApiSetting = backEndApiSetting;
        }

        //[NonAction]
        [Route("{CategoryUrl}")]
        public async Task<IActionResult> Category(string CategoryUrl)
        {   
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_backEndApiSetting.Value.Url);

                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage response = await client.GetAsync($"Category/GetCategoryByUrlHandle/{CategoryUrl}");
                //Checking the response is successful or not which is sent using HttpClient
                if (response.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var responseResult = response.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the CategoryVM
                    var categoryVM = JsonConvert.DeserializeObject<CategoryVM>(responseResult);
                    ViewBag.Title = categoryVM.Name;
                    return View();
                }
            }
            return NotFound();
        }
        
        [Route("{CategoryUrl}/{BrandUrl}")]
        public async Task<IActionResult> Brand(string CategoryUrl,string BrandUrl)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_backEndApiSetting.Value.Url);

                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage responseBrand = await client.GetAsync($"Brand/GetBrandByUrlHandle/{BrandUrl}");

                if (responseBrand.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var responseResult = responseBrand.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the CategoryVM
                    var brandVM = JsonConvert.DeserializeObject<BrandVM>(responseResult);
                    foreach(var categoryVM in brandVM.Categories)
                    {
                        if (categoryVM.UrlHandle == CategoryUrl)
                        {
                            ViewBag.Title = brandVM.Name;
                            return View();
                        }
                    }    
                }
            }
            return NotFound();
        }

        [Route("{CategoryUrl}/{BrandUrl}/{ProductId}")]
        public async Task<IActionResult> Detail(string CategoryUrl, string BrandUrl, Guid ProductId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_backEndApiSetting.Value.Url);

                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage responseProduct = await client.GetAsync($"Product/GetProductById/{ProductId}");

                if (responseProduct.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var responseResult = responseProduct.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the CategoryVM
                    var objectData = JsonConvert.DeserializeObject<ApiProductVM>(responseResult);

                    var productVM = objectData.data;

                    if (productVM.Category.UrlHandle == CategoryUrl && productVM.Brand.UrlHandle == BrandUrl)
                    {
                        ViewBag.Title = productVM.Brand.Name;
                        return View();
                    }
                    
                }
            }
            return NotFound();
        }
    }
}
