using AtechAPI.Domain;
using AtechAPI.Models;
using AtechAPI.Models.DTO;
using AtechAPI.Services;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtechAPI.Factories
{
    public class ProductFactory : IProductFactory
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductFactory(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        public MethodResult<int> CreateOrUpdateProduct(ProductDTOv1 product)
        {
            MethodResult<int> methodResult = new MethodResult<int>();
            try
            {
                var productEntity = _mapper.Map<Product>(product);
                if (product.Id  > 0)
                {
                     _productService.Update(productEntity);
                    methodResult.Message = "Product has been updated";
                }
                else
                {
                    int id = _productService.Add(productEntity);
                    methodResult.Data = id;
                    methodResult.Message = "New Product has been created";
                }
               
                methodResult.IsSuccess = true;
                return methodResult;
            }
            catch (Exception ex)
            {
                methodResult.IsSuccess = false;
                methodResult.Errors.Add($"Error happened : {ex.Message}");
                return methodResult;
            }
        }

        public MethodResult<bool> DeleteProduct(int Id)
        {
            MethodResult<bool> methodResult = new MethodResult<bool>();
            try
            {
                var productEntity = _productService.GetById(Id);
                if (productEntity == null)
                {
                    methodResult.IsSuccess = false;
                    methodResult.Errors.Add($"No product with Id= {Id}");
                    return methodResult;
                }
                _productService.Delete(Id);

                methodResult.IsSuccess = true;
                methodResult.Message = "Product has been deleted";
                return methodResult;
            }
            catch (Exception ex)
            {
                methodResult.IsSuccess = false;
                methodResult.Errors.Add($"Error happened : {ex.Message}");
                return methodResult;
            }
        }

        public MethodResult<ProductDTOv1> PrepareProductById(int Id)
        {
            MethodResult<ProductDTOv1> methodResult = new MethodResult<ProductDTOv1>();
            try
            {
                var productEntity = _productService.GetById(Id);
                if (productEntity == null)
                {
                    methodResult.IsSuccess = false;
                    methodResult.Errors.Add($"No product with Id= {Id}");
                    return methodResult;
                }
                var productDTO = _mapper.Map<ProductDTOv1>(productEntity);
                methodResult.Data = productDTO;
                methodResult.IsSuccess = true;
                methodResult.Message = "Product has been prepared";
                return methodResult;
            }
            catch (Exception ex)
            {
                methodResult.IsSuccess = false;
                methodResult.Errors.Add($"Error happened : {ex.Message}");
                return methodResult;
            }
        }

        public MethodResult<List<ProductDTOv1>> PrepareProductsList()
        {
            MethodResult<List<ProductDTOv1>> methodResult = new MethodResult<List<ProductDTOv1>>();
            try
            {
                var productList = _productService.GetAll().Select(x => new ProductDTOv1
                {
                    Id = x.Id,
                    Description = x.Description,
                    Name = x.Name,
                    Price = x.Price
                });

                methodResult.Data = productList.ToList();
                methodResult.IsSuccess = true;
                methodResult.Message = "Product has been prepared";
                return methodResult;
            }
            catch (Exception ex)
            {
                methodResult.IsSuccess = false;
                methodResult.Errors.Add($"Error happened : {ex.Message}");
                return methodResult;
            }
        }
    }
}
