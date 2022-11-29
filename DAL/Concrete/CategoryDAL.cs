using AutoMapper;
using DAL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    public class CategoryDAL : ICategoryDAL
    {
        private readonly IMapper _mapper;
        public CategoryDAL(IMapper mapper)
        {
            _mapper = mapper;
        }

        public CategoryDTO CreateCategory(CategoryDTO category)
        {
            using (var entities = new TradingCompanyDBEntities())
            {
                var categorydb = _mapper.Map<category>(category);
                categorydb.RowInsertTime = DateTime.UtcNow;
                categorydb.RowUpdateTime = DateTime.UtcNow;
                entities.categories.Add(categorydb);
                entities.SaveChanges();
                return _mapper.Map<CategoryDTO>(categorydb);
            }
        }

        public List<CategoryDTO> GetAllCategories()
        {
            using (var entities = new TradingCompanyDBEntities())
            {
                var categories = entities.categories.ToList();
                return _mapper.Map<List<CategoryDTO>>(categories);
            }
        }

        public void DeleteCategory(CategoryDTO category)
        {
            using (var entities = new TradingCompanyDBEntities())
            {
                var found = entities.categories.SingleOrDefault(c => c.CategoryID == category.CategoryID);
                entities.categories.Remove(found);
                entities.SaveChanges();
            }
        }

        public CategoryDTO GetCategory(int id)
        {
            using (var entities = new TradingCompanyDBEntities())
            {
                var found = entities.categories.SingleOrDefault(c => c.CategoryID == id);
                return _mapper.Map<CategoryDTO>(found);
            }
        }

        public void UpdateCategory(CategoryDTO category)
        {
            using (var entities = new TradingCompanyDBEntities())
            {
                var found = entities.categories.SingleOrDefault(c => c.CategoryID == category.CategoryID);
                if (found != null)
                {
                    found.Name = category.Name;
                    found.RowUpdateTime = DateTime.UtcNow;
                    entities.SaveChanges();
                }
            }
        }
    }
}
