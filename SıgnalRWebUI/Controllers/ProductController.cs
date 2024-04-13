using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using SıgnalRWebUI.DTOs.CategoryDTOs;
using SıgnalRWebUI.DTOs.ProductDTOs;
using System.Text;

namespace SıgnalRWebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;  //Program.cs de ekliyoruz.

        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        //Listeleme İşlemi
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();//istemci oluşturdum
            var responseMessage = await client.GetAsync("https://localhost:7001/api/Products/ProductListWithCategory");//GetAsync HttpClient da var olan metot.Nereye Get isteğinde bulunacaksam orada var olan adresi alıyorum. 

            if (responseMessage.IsSuccessStatusCode) //Eğer  responseMessage başarılı durum koduna sahipse -->
            {
                var jsondata = await responseMessage.Content.ReadAsStringAsync();//json dan gelen içeriği string formatında oku

                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsondata);
                //burada jsondan gelen veriyi çözümleyip atacağım fakat bundan önce dto oluşturyorum.İlk yazdığımız dto lar sadece api ler için çalışıyordu şimdiki oluşturduğum dto lar ise jsondan gelen data propertyler den gelen datayı eşleştirecek.
                //JsonConvert NewtonSoftJson paketi ile kullanılıyor. 
                //Json datayı çözerken kullandığımız deserilaze yani json data normal bir metne dönüşüyor, jsona veri gönderiyorsam yani metni artık json data ya çevirmek için serilaze kullanıyorum. Listelerken deserilaze , eklerken güncellerken serilaze kullanılır.
                return View(values);
            }

            return View();
        }
        /// <summary>
        /// Ürün kategorileriniin dropdownlist ile listelenmesi
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            var client = _httpClientFactory.CreateClient(); //İstemci oluşturdum
            var responseMessage = await client.GetAsync("https://localhost:7001/api/Categories");//Category e istekde bulunacak çünkü kategorilerin gelmesini istiyorum.
            var jsonData= await responseMessage.Content.ReadAsStringAsync();
            var values=JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);//Listeleme olacağı için deserilae kullandım.

            List<SelectListItem> values2 = (from x in values select new SelectListItem
            {
                Text=x.CategoryName,
                Value=x.CategoryID.ToString(),
            }).ToList();

            ViewBag.v = values2; //values2 deki değerleri Viewbag.v komutuyla taşıyacağım.
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            createProductDto.ProductStatus = true;

            var client = _httpClientFactory.CreateClient();//istemci oluşturdum
            var jsonData = JsonConvert.SerializeObject(createProductDto);

            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");//jsona dönüştürdüğüm veriyi encoding ile türkçe karakter almasını sağladığım yapı.

            var responseMessage = await client.PostAsync("https://localhost:7001/api/Products", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteProduct(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7001/api/Products/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            var client1 = _httpClientFactory.CreateClient(); //İstemci oluşturdum
            var responseMessage1 = await client1.GetAsync("https://localhost:7001/api/Categories");//Category e istekde bulunacak çünkü kategorilerin gelmesini istiyorum.
            var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
            var values1 = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData1);//Listeleme olacağı için deserilae kullandım.

            List<SelectListItem> values2 = (from x in values1
                                            select new SelectListItem
                                            {
                                                Text = x.CategoryName,
                                                Value = x.CategoryID.ToString(),
                                            }).ToList();

            ViewBag.v = values2; //values2 deki değerleri Viewbag.v komutuyla taşıyacağım.

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7001/api/Products/{id}");//İlk olarak güncellemem gereken id yi bulmalıyım.

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync(); //json dan gelen içeriği string formatında oku
                var values = JsonConvert.DeserializeObject<UpdateProductDto>(jsonData);//güncelleyeceğim veriyi dto aracılığı ile dönmeliyim.Json veriyi metne dönüştürüyorum.
                return View(values);
            }
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            updateProductDto.ProductStatus = true; 
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateProductDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");//jsona dönüştürüp encoding ile türkçe karakter almasını sağladığım yapı.
            var responseMessage = await client.PutAsync("https://localhost:7001/api/Products", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();

        }
    }
}
