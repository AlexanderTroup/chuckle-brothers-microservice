using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace barry.Controllers {

  [ApiController]
  [Route("[controller]")]
  public class ToYouController : ControllerBase {
    private readonly IHttpClientFactory _clientFactory;

    public ToYouController(IHttpClientFactory httpClientFactory) {
      this._clientFactory = httpClientFactory;
    }

    [HttpGet]
    public async Task Get() {
      Console.WriteLine("ToYou Called!");

      var client = _clientFactory.CreateClient();

      var response = await client.GetAsync("http://localhost:5000/tome");

      if (response.IsSuccessStatusCode) {
        Console.WriteLine("message sent successfully");
      } else {
        Console.WriteLine("message FAILED");
      }
    }
  }
}
