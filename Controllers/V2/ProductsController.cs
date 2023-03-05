using AtechAPI.ExtensionMethods;
using AtechAPI.Factories;
using AtechAPI.Models.DTO;
using AtechAPI.Models.Responses;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AtechAPI.Controllers.V2
{
    [Route("api/v{version:apiVersion}/[controller]/[Action]")]
    [ApiController]
    [ApiVersion("2.0")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductFactory _productFactory;
        private readonly IValidator<ProductDTOv2> _validatorFull;
        private readonly IValidator<ProductDTOPartialv2> _validatorPartial;

        public ProductsController(
            ILogger<ProductsController> logger,
            IProductFactory productFactory,
            IValidator<ProductDTOv2> validatorFull,
            IValidator<ProductDTOPartialv2> validatorPartial
            )
        {
            _logger = logger;
            _productFactory = productFactory;
            _validatorFull = validatorFull;
            _validatorPartial = validatorPartial;
        }



        [HttpPost]
        [Produces(contentType: "application/json", Type = typeof(APIBaseResponse<int>))]
        public IActionResult AddProduct(ProductDTOv2 model)
        {
            var response = new APIBaseResponse<int>();
            var result = _validatorFull.Validate(model);
            if (result.IsValid)
            {

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
            else
            {
                result.AddToModelState(ModelState);
                foreach (var modelState in ModelState.Values)
                {
                    foreach (ModelError error in modelState.Errors)
                    {
                        response.ErrorList.Add(error.ErrorMessage);
                    }
                }

                return response.GetHttpErrorResponse(System.Net.HttpStatusCode.BadRequest);
            }

        }

        [HttpPut]
        [Produces(contentType: "application/json", Type = typeof(APIBaseResponse<int>))]
        public IActionResult UpdateProduct(ProductDTOv2 model)
        {
            var response = new APIBaseResponse<int>();
            var result = _validatorFull.Validate(model);
            if (result.IsValid)
            {
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
            else
            {
                result.AddToModelState(ModelState);
                foreach (var modelState in ModelState.Values)
                {
                    foreach (ModelError error in modelState.Errors)
                    {
                        response.ErrorList.Add(error.ErrorMessage);
                    }
                }

                return response.GetHttpErrorResponse(System.Net.HttpStatusCode.BadRequest);
            }

        }

        [HttpPatch]
        [Produces(contentType: "application/json", Type = typeof(APIBaseResponse<int>))]
        public IActionResult UpdateProduct(ProductDTOPartialv2 model)
        {
            var response = new APIBaseResponse<int>();
            var result = _validatorPartial.Validate(model);
            if (result.IsValid)
            {
                var methodResult = _productFactory.UpdatePartialProduct(model);
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
            else
            {
                result.AddToModelState(ModelState);
                foreach (var modelState in ModelState.Values)
                {
                    foreach (ModelError error in modelState.Errors)
                    {
                        response.ErrorList.Add(error.ErrorMessage);
                    }
                }

                return response.GetHttpErrorResponse(System.Net.HttpStatusCode.BadRequest);
            }


        }



    }
}
