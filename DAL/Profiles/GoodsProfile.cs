using AutoMapper;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Profiles
{
    class GoodsProfile : Profile
    {
        public GoodsProfile()
        {
            CreateMap<good, GoodsDTO>().ReverseMap();
        }
    }
}
