using BusinessLogicLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface ICategoryService : IDisposable
    {
        void Create(CategoryDTO category);
        void Update(CategoryDTO category);
        void Delete(int id);
        CategoryDTO Get(int id);
        IEnumerable<CategoryDTO> GetAll();
    }
}
