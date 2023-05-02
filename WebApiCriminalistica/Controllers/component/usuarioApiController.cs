using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WebApiCriminalistica.Components;
using WebApiCriminalistica.Data;
using WebApiCriminalistica.Models;
using WebApiCriminalistica.Models.component;
using WebApiCriminalistica.services;

namespace WebApiCriminalistica.Controllers.component
{
    [Route("api/[controller]")]
    [ApiController]
    public class usuarioApiController : ControllerBase
    {
        private readonly WebApiCriminalisticaContext _context;

        private IUsuarioApi IUsuarioApi;
        public Result<usuarioApi> res = new Result<usuarioApi>();
        string data;
        public usuarioApiController(IUsuarioApi usuarioApi)
        {
            this.IUsuarioApi = usuarioApi;
        }


        [HttpPost()]
        public async Task<ActionResult<authApi>> GetUsuarioApiJWT(authApi api)
        {

            using (var DBcontext = _context)
            {
                try
                {
                    res.data = 
                }
                catch (Exception ex)
                {
                    res.error = "Error al obtener el dato " + ex.Message;
                }

                data = JsonConvert.SerializeObject(res);

                return Ok(data);
            }
        }

    }
}
