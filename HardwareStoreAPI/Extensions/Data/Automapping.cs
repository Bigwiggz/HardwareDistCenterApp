using AutoMapper;
using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HardwareStoreAPI.DTOs;
using DataAccessLibrary.Models.SpecialModels;
using HardwareStoreAPI.DTOs.SpecialDTOs;

namespace HardwareStoreAPI.Extensions.Data
{
    public class Automapping: Profile
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
