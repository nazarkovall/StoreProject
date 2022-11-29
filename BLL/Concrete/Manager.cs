using BLL.Interfaces;
using DAL.Interfaces;
using DTO;
using System.Collections.Generic;

namespace BLL.Concrete
{
    public class Manager : IManager
    {
        private readonly ICategoryDAL categoryDal;
        private readonly IGoodsDAL goodsDal;

        public Manager(ICategoryDAL categoryDal, IGoodsDAL goodsDal)
        {
            this.categoryDal = categoryDal;
            this.goodsDal = goodsDal;
        }

        public GoodsDTO AddGoods(GoodsDTO goods)
        {
            return goodsDal.CreateGoods(goods);
        }

        public List<GoodsDTO> GetAllGoodsByCategoryID(int categoryID)
        {
            return goodsDal.GetAllGoodsByCategoryID(categoryID);
        }

        public List<CategoryDTO> GetListOfCategories()
        {
            return categoryDal.GetAllCategories();
        }

        public CategoryDTO AddCategory(CategoryDTO category)
        {
            return categoryDal.CreateCategory(category);
        }

        public CategoryDTO DeleteCategoryByID(int id)
        {
            return categoryDal.DeleteCategory(id);
        }

        public CategoryDTO UpdateCategoryyByID(CategoryDTO category, int id)
        {
            return categoryDal.EditCategoryyByID(category, id);
        }

        public GoodsDTO UpdateGoodsByID(GoodsDTO goods, int id)
        {
            return goodsDal.EditGoodsByID(goods, id);
        }

        public GoodsDTO DeleteGoodsByID(int id)
        {
            return goodsDal.DeleteGoodsByID(id);
        }

        public List<GoodsDTO> GetAllGoods()
        {
            return goodsDal.GetAllGoods();
        }

        public List<CategoryDTO> GetAllCategories()
        {
            throw new System.NotImplementedException();
        }
    }
}