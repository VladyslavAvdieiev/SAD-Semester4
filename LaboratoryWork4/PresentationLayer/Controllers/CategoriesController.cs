using AutoMapper;
using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Infrastructure;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Services;
using Ninject;
using PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PresentationLayer.Controllers
{
    public class CategoriesController : ApiController
    {
        private ICategoryService service;

        public CategoriesController(ICategoryService service)
        {
            this.service = service;
        }

        public CategoryViewModel Get(int id)
        {
            var category = service.Get(id);
            return new CategoryViewModel { Name = category.Name, Id = category.Id };
        }

        public IEnumerable<CategoryViewModel> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CategoryDTO, CategoryViewModel>()).CreateMapper();
            return mapper.Map<IEnumerable<CategoryDTO>, IEnumerable<CategoryViewModel>>(service.GetAll());
        }

        public void Post(CategoryViewModel category)
        {
            service.Create(new CategoryDTO(category.Name));
        }

        protected override void Dispose(bool disposing)
        {
            service.Dispose();
            base.Dispose(disposing);
        }
    }
}
