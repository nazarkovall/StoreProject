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

        public void DeleteCategory(CategoryDTO category)
        {
            throw new NotImplementedException();
        }

        public List<CategoryDTO> GetAllCategories()
        {
            using (var entities = new TradingCompanyDBEntities())
            {
                var categoris = entities.categories.ToList();
                return _mapper.Map<List<CategoryDTO>>(categoris);
            }
        }

        public CategoryDTO GetCategory(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateCategory(CategoryDTO category)
        {
            throw new NotImplementedException();
        }
    }
}
