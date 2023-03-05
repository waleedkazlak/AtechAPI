using AtechAPI.Domain;
using AtechAPI.Models.DTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtechAPI.Automapper
{
    public class Automap : Profile
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public Automap()
        {
            CreateMap<ProductDTOv1, Product>().ReverseMap();
            CreateMap<ProductDTOv2, Product>().ReverseMap();
        }
    }
}
