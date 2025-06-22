using AutoMapper;
using DTOs;
using Entities;
using repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Services
{
    public class ProductService : IProductService
    {
        public readonly IMapper _mapper;

        IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }


        public async Task<List<ProductDTO>> GetAllProducts()
        {
            List<Product>products= await _productRepository.GetAllProducts();
            List<ProductDTO> productsToReturn = _mapper.Map<List<ProductDTO>> (products);
            return productsToReturn;
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts(int position, int skip, string? desc, int? minPrice, int? maxPrice, int?[] categoryIds)
        {
            IEnumerable<Product> products = await _productRepository.GetProducts(position, skip, desc, minPrice, maxPrice, categoryIds);

            var productDTOs = _mapper.Map<List<Product>, List<ProductDTO>>((List<Product>)products);

            return productDTOs;
        }
    }
}
