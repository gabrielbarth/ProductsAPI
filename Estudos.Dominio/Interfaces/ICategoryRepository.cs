using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Estudos.Dominio.Models;

namespace Estudos.Dominio.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategories();
     //   Category GetCategoryById(int id);
     //   void SaveCategory(Category category);
     //   void UpdateCategory(Category category);
     //   void RemoveCategory(Category category);

    }

}