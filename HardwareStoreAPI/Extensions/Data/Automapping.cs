using AutoMapper;
using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HardwareStoreAPI.DTOs;

namespace HardwareStoreAPI.Extensions.Data
{
    public class Automapping: Profile
    {
        public Automapping()
        {
            //CPI Index
            CreateMap<CPIIndex, CPIIndexDTO>();
            CreateMap<CPIIndexDTO, CPIIndex>();
        }
    }
}
