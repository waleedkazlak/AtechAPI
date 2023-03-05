using AtechAPI.Factories;
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
    [Route("api/v{version:apiVersion}/[controller]/[Action]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductFactory _productFactory;

        public ProductsController(ILogger<ProductsController> logger, IProductFactory productFactory)
        {
            _logger = logger;
            _productFactory = productFactory;
        }

        [HttpGet]
        [Produces(contentType: "application/json", Type = typeof(APIBaseResponse<List<ProductDTOv1>>))]
        public IActionResult All()
        {
            var response = new APIBaseResponse<List<ProductDTOv1>>();
            var methodResult = _productFactory.PrepareProductsList();
            if (methodResult.IsSuccess)
            {
                response.Data = methodResult.Data;
                response.SuccessMessage = methodResult.Message;
                return Ok(response);
            }
            else
            {
                response.ErrorList = methodResult.Errors;
                return response.GetHttpErrorResponse(System.Net.HttpStatusCode.BadRequest);
            }

        }

        [HttpGet]
        [Route("{id:maxlength(10)}")]
        [Produces(contentType: "application/json", Type = typeof(APIBaseResponse<ProductDTOv1>))]
        public IActionResult GetById(int id)
        {
            var response = new APIBaseResponse<ProductDTOv1>();
            var methodResult = _productFactory.PrepareProductById(id);
            if (methodResult.IsSuccess)
            {
                response.Data = methodResult.Data;
                response.SuccessMessage = methodResult.Message;
                return Ok(response);
            }
            else
            {
                response.ErrorList = methodResult.Errors;
                return response.GetHttpErrorResponse(System.Net.HttpStatusCode.BadRequest);
            }

        }

        [HttpPost]
        [Produces(contentType: "application/json", Type = typeof(APIBaseResponse<int>))]
        public IActionResult Add(ProductDTOv1 model)
        {
            var response = new APIBaseResponse<int>();
            var methodResult = _productFactory.CreateOrUpdateProduct(model);
            if (methodResult.IsSuccess)
            {
                response.Data = methodResult.Data;
                response.SuccessMessage = methodResult.Message;
                return Ok(response);
            }
            else
            {
                response.ErrorList = methodResult.Errors;
                return response.GetHttpErrorResponse(System.Net.HttpStatusCode.BadRequest);
            }

        }

        [HttpPut]
        [Produces(contentType: "application/json", Type = typeof(APIBaseResponse<int>))]
        public IActionResult Update(ProductDTOv1 model)
        {
            var response = new APIBaseResponse<int>();
            var methodResult = _productFactory.CreateOrUpdateProduct(model);
            if (methodResult.IsSuccess)
            {
                response.Data = methodResult.Data;
                response.SuccessMessage = methodResult.Message;
                return Ok(response);
            }
            else
            {
                response.ErrorList = methodResult.Errors;
                return response.GetHttpErrorResponse(System.Net.HttpStatusCode.BadRequest);
            }

        }

        [HttpDelete]
        [Produces(contentType: "application/json", Type = typeof(APIBaseResponse<bool>))]
        public IActionResult Delete(int id)
        {
            var response = new APIBaseResponse<bool>();
            var methodResult = _productFactory.DeleteProduct(id);
            if (methodResult.IsSuccess)
            {
                response.Data = methodResult.Data;
                response.SuccessMessage = methodResult.Message;
                return Ok(response);
            }
            else
            {
                response.ErrorList = methodResult.Errors;
                return response.GetHttpErrorResponse(System.Net.HttpStatusCode.BadRequest);
            }

        }
    }
}
