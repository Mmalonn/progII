using Repository2025.Data;
using Repository2025.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository2025.Services
{
    public class ProductService
    {
        private iProductRepository _repository;
        public ProductService()
        {
            _repository = new ProductRepository();
        }
        public List<Product> GetProducts()
        {
            return _repository.GetAll();
        }

        public Product GetProduct(int id)
        {
            return _repository.GetById(id);
        }

        public bool DeleteProductById(int id)
        {
            return _repository.Delete(id);
        }

        internal bool SaveProduct(Product aGuardar)
        {
            return _repository.Save(aGuardar);
        }
    }
}
