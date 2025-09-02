using AutoMapper;
using LemonadeStand.Abstractions.Interfaces;
using LemonadeStand.Abstractions.Models;
using Microsoft.Toolkit.Diagnostics;
using LemonadeStand.Abstractions.Struct;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System;

namespace LemonadeStand.Services
{
  public class ProductTypeService : IProductTypeService
  {
    private readonly ILogger<ProductTypeService> _logger;
    private readonly IProductTypeRepository _ProductTypeRepository;
    private readonly IMapper _mapper;

    public ProductTypeService(ILogger<ProductTypeService> logger,
        IProductTypeRepository ProductTypeRepository,
        IMapper mapper)
    {
      _logger = logger;
      _ProductTypeRepository = ProductTypeRepository;
      _mapper = mapper;
    }

    public async Task DeleteAsync(int id)
    {
      try
      {
        Guard.IsNotEqualTo<int>(id, 0, nameof(id));
        _logger.LogInformation(ProductTypeLogMessages.ProductType_INVOKE_DELETE_SERVICE);
        await _ProductTypeRepository.DeleteAsync(id);
      }
      catch (Exception ex)
      {
        _logger.LogError(ProductTypeLogMessages.ProductType_INVOKE_DELETE_SERVICE_ERROR);
      }
    }

    public async Task<IEnumerable<ProductType>> GetAllAsync(string search, int pageIndex, int pageSize, string sortField = null)
    {
      try
      {
        _logger.LogInformation(ProductTypeLogMessages.ProductType_INVOKE_GETALL_SERVICE);
        var oList = await _ProductTypeRepository.GetAllAsync(search, pageIndex, pageSize, sortField);
        return _mapper.Map<IEnumerable<ProductType>>(oList);
      }
      catch (Exception ex)
      {
        _logger.LogError(ProductTypeLogMessages.ProductType_INVOKE_GETALL_SERVICE_ERROR);
        return new List<ProductType>();
      }
    }

    public async Task<IEnumerable<ProductType>> GetAllProductTypesAsync()
    {
      var oReturn = await _ProductTypeRepository.GetAllProductTypesAsync();
      return _mapper.Map<IEnumerable<ProductType>>(oReturn);
    }

    public async Task<ProductType?> GetByIdAsync(int id)
    {
      try
      {
        Guard.IsNotEqualTo<int>(id, 0, nameof(id));
        _logger.LogInformation(ProductTypeLogMessages.ProductType_INVOKE_GETBYID_SERVICE);
        var oModel = await _ProductTypeRepository.GetByIdAsync(id);
        Guard.IsNotNull(oModel, nameof(oModel));
        return _mapper.Map<ProductType>(oModel);
      }
      catch (Exception ex)
      {
        _logger.LogError(ProductTypeLogMessages.ProductType_INVOKE_GETBYID_SERVICE_ERROR);
        return new ProductType();
      }
    }

    public async Task InsertAsync(ProductType ProductType)
    {
      try
      {
        Guard.IsNotNull<ProductType>(ProductType, nameof(ProductType));
        _logger.LogInformation(ProductTypeLogMessages.ProductType_INVOKE_INSERT_SERVICE);
        var oEntity = _mapper.Map<LemonadeStand.Abstractions.Entities.ProductType>(ProductType);
        await _ProductTypeRepository.InsertAsync(oEntity);
      }
      catch (Exception ex)
      {
        _logger.LogError(ProductTypeLogMessages.ProductType_INVOKE_INSERT_SERVICE_ERROR);
      }
    }

    public async Task UpdateAsync(int id, ProductType ProductType)
    {
      try
      {
        Guard.IsNotEqualTo<int>(id, 0, nameof(id));
        Guard.IsNotNull<ProductType>(ProductType, nameof(ProductType));
        _logger.LogInformation(ProductTypeLogMessages.ProductType_INVOKE_UPDATE_SERVICE);
        var oEntity = _mapper.Map<LemonadeStand.Abstractions.Entities.ProductType>(ProductType);
        await _ProductTypeRepository.UpdateAsync(id, oEntity);
      }
      catch (Exception ex)
      {
        _logger.LogError(ProductTypeLogMessages.ProductType_INVOKE_UPDATE_SERVICE_ERROR);
      }
    }
  }
}

