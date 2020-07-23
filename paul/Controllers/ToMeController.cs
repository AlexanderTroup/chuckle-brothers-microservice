using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace paul.Controllers {
  [ApiController]
  [Route("[controller]")]
  public class ToMeController : ControllerBase {
    private readonly IHttpClientFactory _clientFactory;

    public ToMeController(IHttpClientFactory httpClientFactory) {
      this._clientFactory = httpClientFactory;
    }

    [HttpGet]
    public async Task Get() {
      Console.WriteLine("ToMe Called!");

      var client = _clientFactory.CreateClient();

      var response = await client.GetAsync("http://localhost:5001/toyou");

      if (response.IsSuccessStatusCode) {
        Console.WriteLine("message sent successfully");
      } else {
        Console.WriteLine("message FAILED");
      }
    }
  }
}
