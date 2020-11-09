using Estudos.Aplicacao.Interfaces;
using Estudos.Aplicacao.IServices;
using Estudos.Dominio.Interfaces;
using Estudos.Infraestrutura.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Estudos.Aplicacao.Services
{
    public class CategoryService : ICategoryService
    {

        private readonly ICategoryRepository _repository;
        private readonly ICategoryAdapter _adapter;
        public CategoryService(ICategoryRepository repository, ICategoryAdapter adapter)
        {
            _repository = repository;
            _adapter = adapter;
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            var Categorias = await _repository.GetCategories();
            var CategoriasDTO = _adapter.MapearColecaoCategoriaParaColecaoCategoriaDTO(Categorias);

            return await Task.FromResult(CategoriasDTO);
        }
    }
}
