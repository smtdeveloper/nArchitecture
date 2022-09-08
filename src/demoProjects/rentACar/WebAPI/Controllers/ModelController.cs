using Application.Features.Models.Models;
using Application.Features.Models.Queries.GetListModel;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetListModel([FromQuery] PageRequest pageRequest )
        {
            GetListModelQuery getListModelQuery = new() {  pageRequest = pageRequest  };

            ModelListModel result = await Mediator.Send(getListModelQuery);

            return Ok(result);
        }
    }
}
