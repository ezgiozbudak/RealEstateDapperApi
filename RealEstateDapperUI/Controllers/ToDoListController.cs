﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstateDapperUI.Dtos.ToDoListDtos;

namespace RealEstateDapperUI.Controllers
{
    public class ToDoListController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ToDoListController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7267/api/ToDoLists");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultToDoListDto>>(jsonData);
                return View(values);
            }

            return View();
        }
    }
}
