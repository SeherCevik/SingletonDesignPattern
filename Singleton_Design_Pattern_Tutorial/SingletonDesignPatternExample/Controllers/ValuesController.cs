using Microsoft.AspNetCore.Mvc;
using SingletonDesignPatternAspNetCoreExample.Services;


//Uygulamada birden fazla noktada sınıfın instance ina ihtiyacimiz olan bir seneryo
namespace SingletonDesignPatternExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        //INFO: swagger uzerinden istek atilip console uzerinden test yapilabilir.
        [HttpGet("[Action]")]
        public IActionResult X()
        {
            DataBaseService dataBaseService =DataBaseService.GetInstance;
            dataBaseService.Connection();
            dataBaseService.Disconnect();
            return Ok(dataBaseService.Count);
        }

        [HttpGet("[Action]")]
        public IActionResult Y()
        {
            DataBaseService dataBaseService = DataBaseService.GetInstance;
            dataBaseService.Connection();
            dataBaseService.Disconnect();
            return Ok(dataBaseService.Count);
        }
    }
}
