using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Estudos.Aplicacao.IServices;
using Estudos.Infraestrutura.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Estudos.Api.Controllers
{
    [ApiVersion("1")]
    [Route("estudos/v{version:apiVersion}/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;
        public CategoryController(ICategoryService service)
        {
            _service = service;
        }
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get()
        {
            var categorias = await _service.GetCategories();
            return await Task.FromResult(Ok(categorias)); 
        }


    }
}
