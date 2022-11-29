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

        public List<GoodsDTO> GetAllGoods()
        {
            using (var entities = new TradingCompanyDBEntities())
            {
                var Goods = entities.goods.ToList();
                return _mapper.Map<List<GoodsDTO>>(Goods);
            }
        }

        public void DeleteGoods(GoodsDTO goods)
        {
            using (var entities = new TradingCompanyDBEntities())
            {
                var found = entities.goods.SingleOrDefault(g => g.GoodsID == goods.GoodsID);
                entities.goods.Remove(found);
                entities.SaveChanges();
            }
        }

        public GoodsDTO GetGoods(int id)
        {
            using (var entities = new TradingCompanyDBEntities())
            {
                var found = entities.goods.SingleOrDefault(g => g.GoodsID == id);
                return _mapper.Map<GoodsDTO>(found);
            }
        }

        public void UpdateGoods(GoodsDTO goods)
        {
            using (var entities = new TradingCompanyDBEntities())
            {
                var found = entities.goods.SingleOrDefault(g => g.GoodsID == goods.GoodsID);
                if (found != null)
                {
                    found.Name = goods.Name;
                    found.RowUpdateTime = DateTime.UtcNow;
                    entities.SaveChanges();
                }
            }
        }
    }
}
