using Estudos.Infraestrutura.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Estudos.Aplicacao.IServices
{
    public  interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetCategories();

    }
}
