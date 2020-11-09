using Estudos.Aplicacao.Interfaces;
using Estudos.Dominio.Models;
using Estudos.Infraestrutura.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Estudos.Aplicacao.Adapter
{
    public class CategoryAdapter : ICategoryAdapter
    {
        public CategoryAdapter()
        {

        }

        public CategoryDTO MapearEntidadeParaDTO(Category category)
        {
            return new CategoryDTO {
                Id = category.Id,
                Title = category.Title
            };
        }

        public IEnumerable<CategoryDTO> MapearColecaoCategoriaParaColecaoCategoriaDTO(IEnumerable<Category> categorias)
        {
            return categorias.Select(x => MapearEntidadeParaDTO(x));
        }
    }
}
