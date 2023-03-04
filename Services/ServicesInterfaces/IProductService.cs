using AtechAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtechAPI.Services
{
    public interface IProductService
    {
        List<Product> GetAll();
        Product GetById(int Id);
        int Add(Product product);

        void Update(Product product);

        void Delete(int Id);

    }
}
