using DTO;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IManager
    {
        List<CategoryDTO> GetAllCategories();
        CategoryDTO AddCategory(CategoryDTO category);
        CategoryDTO DeleteCategoryByID(int id);
        CategoryDTO UpdateCategoryyByID(CategoryDTO category, int id);

        List<GoodsDTO> GetAllGoods();
        List<GoodsDTO> GetAllGoodsByCategoryID(int categoryID);
        GoodsDTO AddGoods(GoodsDTO goods);
        GoodsDTO UpdateGoodsByID(GoodsDTO goods, int id);
        GoodsDTO DeleteGoodsByID(int id);
    }
}