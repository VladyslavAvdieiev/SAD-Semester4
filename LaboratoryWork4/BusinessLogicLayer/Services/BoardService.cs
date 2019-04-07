using AutoMapper;
using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class BoardService : IBoardService
    {
        private bool disposed;
        private IUnitOfWork unitOfWork;

        public BoardService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            disposed = false;
        }

        public void CreateCategory(CategoryDTO category)
        {
            unitOfWork.Categories.Create(new Category { Id = category.Id, Name = category.Name });
            unitOfWork.Save();
        }

        public CategoryDTO GetCategory(int id)
        {
            var category = unitOfWork.Categories.Get(ctg => ctg.Id == id);
            return new CategoryDTO { Id = category.Id, Name = category.Name };
        }

        public IEnumerable<CategoryDTO> GetAllCategories()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Category, CategoryDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(unitOfWork.Categories.GetAll());
        }

        public void Dispose()
        {
            if (!disposed)
                unitOfWork.Dispose();
            disposed = true;
            GC.SuppressFinalize(this);
        }
    }
}
