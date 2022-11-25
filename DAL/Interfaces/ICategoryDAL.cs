using DTO;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface ICategoryDAL
    {
        List<CategoryDTO> GetAllCategories();
        CategoryDTO CreateCategory(CategoryDTO category);
        CategoryDTO GetCategory(int id);
        void DeleteCategory(CategoryDTO category);
        void UpdateCategory(CategoryDTO category);
    }
}