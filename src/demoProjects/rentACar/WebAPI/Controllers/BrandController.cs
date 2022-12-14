using Application.Features.Brands.Commands.CreateBrand;
using Application.Features.Brands.Commands.DeleteBrand;
using Application.Features.Brands.Commands.UpdateBrand;
using Application.Features.Brands.Dtos;
using Application.Features.Brands.Models;
using Application.Features.Brands.Queries.GetByIdBrand;
using Application.Features.Brands.Queries.GetListBrand;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers;

namespace WebAPI.Controllerss
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> AddBrand([FromBody] CreateBrandCommand createBrandCommand)
        {
            CreatedBrandDto result = await Mediator.Send(createBrandCommand);
            return Created("", result);
        }

        [HttpGet]
        public async Task<IActionResult> GetListBrand([FromQuery] PageRequest pageRequest)
        {
            GetListBrandQuery getListBrandQuery = new() { pageRequest = pageRequest };
            BrandListModel result = await Mediator.Send(getListBrandQuery);
            return Ok(result);

        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdBrandQuery getByIdIdBrandQuery)
        {
            BrandGetByIdDto brandGetByIdDto = await Mediator.Send(getByIdIdBrandQuery);
            return Ok(brandGetByIdDto);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteBrand([FromRoute] DeleteBrandCommand deleteBrandCommand)
        {
           
            var result = await Mediator.Send(deleteBrandCommand);
            return Ok(result);  
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateBrand([FromBody] UpdateBrandCommand updateBrandCommand)
        {
            var result = await Mediator.Send(updateBrandCommand);
            return Ok(result);
        }

    }
}
