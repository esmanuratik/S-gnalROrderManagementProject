using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SıgnalRWebUI.DTOs.ProductDTOs;

namespace SıgnalRWebUI.ViewComponents.DefaultComponents
{
    public class _DefaultOurComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultOurComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7001/api/Products");
            var jsonData=await responseMessage.Content.ReadAsStringAsync();

            var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
            return View(values);
        }
    }
}
