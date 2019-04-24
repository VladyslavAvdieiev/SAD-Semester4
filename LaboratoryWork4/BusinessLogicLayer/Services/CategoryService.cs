using AutoMapper;
using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class CategoryService : ICategoryService
    {
        private bool isDisposed;
        private IBoardUnitOfWork unitOfWork;

        public CategoryService(IBoardUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            isDisposed = false;
        }

        public void Create(CategoryDTO category)
        {
            unitOfWork.Categories.Create(new Category(category.Name));
            unitOfWork.Commit();
        }

        public void Update(CategoryDTO category)
        {
            unitOfWork.Categories.Update(new Category { Id = category.Id, Name = category.Name });
            unitOfWork.Commit();
        }

        public void Delete(int id)
        {
            unitOfWork.Categories.DeleteBy(ctg => ctg.Id == id);
        }

        public CategoryDTO Get(int id)
        {
            var category = unitOfWork.Categories.GetSingle(ctg => ctg.Id == id);
            return new CategoryDTO { Id = category.Id, Name = category.Name };
        }

        public IEnumerable<CategoryDTO> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Category, CategoryDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(unitOfWork.Categories.GetAll());
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!isDisposed && disposing)
            {
                unitOfWork.Dispose();
                isDisposed = true;
            }
        }
    }
}
