using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SıgnalRWebUI.DTOs.AboutDTOs;

namespace SıgnalRWebUI.ViewComponents.DefaultComponents
{
    public class _DefaultAboutComponentPartial:ViewComponent
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultAboutComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7001/api/Abouts");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();

            var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
            return View(values);
        }
    }
}
