using AtechAPI.Models;
using AtechAPI.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtechAPI.Factories
{
    public interface IProductFactory
    {
        MethodResult<List<ProductDTOv1>> PrepareProductsList();

        MethodResult<ProductDTOv1> PrepareProductById(int Id);
        MethodResult<int> CreateOrUpdateProduct(ProductDTOv1 product);
        MethodResult<int> CreateOrUpdateProduct(ProductDTOv2 product);

        MethodResult<int> UpdatePartialProduct(ProductDTOPartialv2 product);
        MethodResult<bool> DeleteProduct(int Id);
    }
}
