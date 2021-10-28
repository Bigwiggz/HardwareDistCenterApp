using AutoMapper;
using DataAccessLibrary.Models;
using DataAccessLibrary.Models.SpecialModels;
using HardwareStoreBusinessLogicLibrary.DTOModels;
using HardwareStoreBusinessLogicLibrary.DTOModels.SpecialDTOs;

namespace HardwareStoreAPI.Extensions.Data
{
    public class Automapping : Profile
    {
        public Automapping()
        {
            //CPI Index
            CreateMap<CPIIndex, CPIIndexDTO>();
            CreateMap<CPIIndexDTO, CPIIndex>();

            //ICECATProduct Catalog
            CreateMap<ICECATProductCatalog, ICECATProductCatalogDTO>();
            CreateMap<ICECATProductCatalogDTO, ICECATProductCatalog>();

            //CompanyContactsWithStoreLocations Query Display Only
            CreateMap<CompanyContactsWithStoreLocations, CompanyContactsWithStoreLocationsDTO>();
        }
    }
}
