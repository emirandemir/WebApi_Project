using ConsumeAPI_Project.ResponseModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsumeAPI_Project.Controllers
{
    public class HomeController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public HomeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("http://localhost:24590/api/products");

            if(responseMessage.StatusCode == System.Net.HttpStatusCode.OK) 
            {

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<ProductResponseModel>>(jsonData);
            return View(result);
            }

            else
            {
                return View(null);
            }
             
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductResponseModel model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync("http://localhost:24590/api/products", content);

            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            else
            {
                TempData["errorMessage"] = $"Hata ile karşılaşıldı. Hata Kodu: {(int)responseMessage.StatusCode}";
                return View(model);
            }
        }


        public async Task<IActionResult> Update(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:24590/api/products/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<ProductResponseModel>(jsonData);
                return View(data);
            }

            else
            {
                return View(null);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProductResponseModel product)
        {

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(product);
            var content = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PutAsync($"http://localhost:24590/api/products", content);

            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            else
            {
                return View(product);
            }
        }


        public async Task<IActionResult> Delete(int id)
        {

            var client = _httpClientFactory.CreateClient();
            await client.DeleteAsync($"http://localhost:24590/api/products/{id}");
            return RedirectToAction("Index");
           

           
        }
    }
}
