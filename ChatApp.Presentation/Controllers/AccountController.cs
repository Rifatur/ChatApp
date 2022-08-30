using ChatApp.Presentation.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ChatApp.Presentation.Controllers
{
    public class AccountController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }
        public async Task<IActionResult> Register(RegisterPreViewDTOs model)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7090/");
            var response = await client.PostAsJsonAsync<RegisterPreViewDTOs>("Account/RegisterAsysc", model);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("index", "Home");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginPreViewDTOs model)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7090/");
            var response = await client.PostAsJsonAsync<LoginPreViewDTOs>("Account/LoginAsysc", model);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("index", "Home");
            }

            return View();
        }
    }

}
