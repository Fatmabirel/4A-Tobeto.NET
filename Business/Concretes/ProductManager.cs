using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Product;
using Core.CrossCuttingConcerns.Exceptions.Types;
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
        IMapper _mapper; 

        public ProductManager(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        
        public async Task Add(ProductForAddDto dto)
        {
            if (dto.UnitPrice < 0)
                throw new BusinessException("Ürün fiyatı 0'dan küçük olamaz.");

            // Aynı isimde 2. ürün eklenemez.

            Product? productWithSameName = await _productRepository.GetAsync(p => p.Name == dto.Name);
            if (productWithSameName is not null)
                throw new Exception("Aynı isimde 2. ürün eklenemez.");

            Product product = _mapper.Map<Product>(dto);

           await _productRepository.AddAsync(product);

        }

        public async Task Delete(Product product)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ProductForListingDto>> GetAll()
        {
            List<Product> products = await _productRepository.GetListAsync();
            //List<ProductForListingDto> response = new List<ProductForListingDto>();

            //foreach (Product product in products)
            //{
            //    ProductForListingDto dto = new();
            //    dto.Name = product.Name;
            //    dto.UnitPrice = product.UnitPrice;
            //    dto.Id = product.Id;
            //    response.Add(dto);  
            //}

            // Manual Mapping
            // AutoMapping
            List<ProductForListingDto> response = products.Select(p => new ProductForListingDto()
            {
                Id = p.Id,
                Name = p.Name,
                UnitPrice = p.UnitPrice,
            }).ToList();
            return response;

        }

        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}