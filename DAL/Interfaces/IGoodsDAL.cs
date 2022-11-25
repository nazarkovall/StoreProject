using DTO;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IGoodsDAL
    {
        List<GoodsDTO> GetAllGoods();
        GoodsDTO CreateGoods(GoodsDTO goods);
        GoodsDTO GetGoods(int id);
        void DeleteGoods(GoodsDTO goods);
        void UpdateGoods(GoodsDTO goods);
    }
}
