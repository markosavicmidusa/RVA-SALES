using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using RRVAPRODAVNICA.Models;
using RVAPRODAVNICA.Data;

namespace RVAPRODAVNICA.Services
{
    public class MapperService : Profile
    {
        public MapperService() {
            CreateMap<Product, ProductModel>().ReverseMap(); //product model je des , a product src, u oba smera
           // CreateMap<ProductModel, Product>(); //product model je src , a product destination
            // .ForMember(X=>X.Description, opt=>opt.MapFrom(src=> src.Description ))
            //;
            //x je product model on je src je product 

        }
    }
}
