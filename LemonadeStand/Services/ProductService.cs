using LemonadeStand.Abstractions.Interfaces;
using LemonadeStand.Abstractions.Models;
using AutoMapper;

namespace LemonadeStand.Services
{
	public class ProductService : IProductService
	{
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductService> _logger;

        public ProductService(IProductRepository productRepository,
            ILogger<ProductService> logger,
            IMapper mapper)
		{
            _logger = logger;
            _mapper = mapper;
            _productRepository = productRepository;

        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            var oReturn = await _productRepository.GetProductsAsync();
            return _mapper.Map<IEnumerable<Product>>(oReturn);
        }
    }
}

