using Business.Abstracts;
using DataAccess.Abstracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class ProductManager : IProductService
    {
        IProductRepository _productRepository;

        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        
        public async void Add(Product product)
        {
            if (product.UnitPrice < 0)
                throw new Exception("Ürün fiyatı 0'dan küçük olamaz.");

            // Aynı isimde 2. ürün eklenemez.

            Product? productWithSameName = await _productRepository.GetAsync(p => p.Name == product.Name);
            if (productWithSameName is not null)
                throw new Exception("Aynı isimde 2. ürün eklenemez.");

            // İş kuralları, Validaton => Daha temiz yazarız?
            // Global Ex. Handling.
            // Pipeline Mediator pattern ??

           await _productRepository.AddAsync(product);

        }

        public void Delete(Product product)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Product>> GetAll()
        {
            return await _productRepository.GetListAsync();
        }

        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}