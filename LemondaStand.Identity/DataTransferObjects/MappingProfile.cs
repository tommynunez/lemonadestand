using AutoMapper;
using LemonadeStand.Identity.Data.Models;
using LemondaStand.Identity.DataTransferObjects;

namespace LemonadeStand.Identity.DataTransferObjects
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      AllowNullCollections = false;
      CreateMap<RegisterDto, AppUser>()
          .ReverseMap();
    }
  }
}
