using Estudos.Dominio.Models;
using Estudos.Infraestrutura.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Estudos.Aplicacao.Interfaces
{
    public interface ICategoryAdapter : IAdapter<Category, CategoryDTO>
    {
        IEnumerable<CategoryDTO> MapearColecaoCategoriaParaColecaoCategoriaDTO(IEnumerable<Category> categorias);
    }
}
