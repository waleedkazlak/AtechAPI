using AtechAPI.Models.DTO;
using AtechAPI.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtechAPI.Controllers.V1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ILogger<ProductsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("all")]
        [Produces(contentType: "application/json", Type = typeof(APIBaseResponse<List<ProductDTOv1>>))]
        public IActionResult All()
        {
            var response = new APIBaseResponse<List<ProductDTOv1>>();

            return Ok(response);
        }
    }
}
