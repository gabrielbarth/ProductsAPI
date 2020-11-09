using Estudos.Dominio.Interfaces;
using Estudos.Dominio.Models;
using Estudos.Repositorio.ConfiguracaoHibernate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Estudos.Repositorio.Repositorios
{
    public class CategoryRepository : ICategoryRepository
    {

        private readonly IUnityOfWork _unity;
        public CategoryRepository(IUnityOfWork unity)
        {
            _unity = unity;
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _unity.Query<Category>();
            
        }


    }
}
