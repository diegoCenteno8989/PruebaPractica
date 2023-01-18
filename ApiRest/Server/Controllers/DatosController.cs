using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using ApiRest.Shared.Models;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
//using Newtonsoft.Json;

namespace ApiRest.Server.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class DatosController : ControllerBase
    {

        [HttpGet]
        [Route("consultaDatosUSDaily")]
        //[Authorize(Roles  = "BUSCADOR")]
        public async Task<JsonResult> ConsultarDatosUSDaily()
        {
            List<DatosUSDaily> data = new List<DatosUSDaily>();
            try
            {
                HttpClient Http = new HttpClient();
                var response = await Http.GetAsync("https://api.covidtracking.com/v1/us/daily.json");
                var jsonString = await response.Content.ReadAsStringAsync();
                data = JsonSerializer.Deserialize<List<DatosUSDaily>>(jsonString);

            }
            catch (Exception ex)
            {

                
            }


            var obj = new { dato1 = 0 };


            return new JsonResult(data);
        }

        [HttpGet]
        [Route("consultaDatosSatateDaily")]
        //[Authorize(Roles = "CIUDADANO")]
        public async Task<JsonResult> ConsultarDatosStatesDaily()
        {
            List<DatosStatesDaily> data = new List<DatosStatesDaily>();
            try
            {
                HttpClient Http = new HttpClient();
                var response = await Http.GetAsync("https://api.covidtracking.com/v1/states/daily.json");
                var jsonString = await response.Content.ReadAsStringAsync();
                data = JsonSerializer.Deserialize<List<DatosStatesDaily>>(jsonString);

            }
            catch (Exception ex)
            {


            }

            return new JsonResult(data);
        }
    }
}
