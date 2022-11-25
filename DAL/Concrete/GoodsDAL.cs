using AutoMapper;
using DAL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Concrete
{
    public class GoodsDAL : IGoodsDAL
    {
        private readonly IMapper _mapper;

        public GoodsDAL(IMapper mapper)
        {
            _mapper = mapper;
        }

        public GoodsDTO CreateGoods(GoodsDTO goods)
        {
            using (var entities = new TradingCompanyDBEntities())
            {
                var goodsInDB = _mapper.Map<good>(goods);
                goodsInDB.RowInsertTime = DateTime.UtcNow;
                goodsInDB.RowUpdateTime = DateTime.UtcNow;
                entities.goods.Add(goodsInDB);
                entities.SaveChanges();
                return _mapper.Map<GoodsDTO>(goodsInDB);
            }
        }

        public void DeleteGoods(GoodsDTO goods)
        {
            throw new NotImplementedException();
        }

        public List<GoodsDTO> GetAllGoods()
        {
            using (var entities = new TradingCompanyDBEntities())
            {
                var Goods = entities.goods.ToList();
                return _mapper.Map<List<GoodsDTO>>(Goods);
            }
        }

        public GoodsDTO GetGoods(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateGoods(GoodsDTO goods)
        {
            throw new NotImplementedException();
        }
    }
}
