using AtechAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtechAPI.Services
{
    public class ProductService : IProductService
    {
        private List<Product> list;
        public ProductService()
        {
            list= ProductsMockupSingletone.GetProductsMockup();
            
            
        }
        public int Add(Product product)
        {
            product.Id = list.Last().Id + 1;
            list.Add(product);
            return product.Id;
        }

        public void Delete(int Id)
        {
            Product product = list.FirstOrDefault(x => x.Id == Id);
            if (product!=null)
            {
                list.Remove(product);
            }
            
        }

        public List<Product> GetAll()
        {
            return list.ToList();
        }

        public Product GetById(int Id)
        {
            Product product = list.FirstOrDefault(x => x.Id == Id);
            if (product != null)
            {
               return product;
            }
            return null;
        }

        public void Update(Product product)
        {
            Product oldProduct = list.FirstOrDefault(x => x.Id == product.Id);
            list.Remove(oldProduct);
            list.Add(product);
        }
    }
}
