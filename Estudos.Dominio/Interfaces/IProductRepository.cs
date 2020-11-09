using System;
using System.Collections.Generic;
using System.Text;

using Estudos.Dominio.Entidades;

namespace Estudos.Dominio.Interfaces
{
    public interface IProductRepository
    {
        Product GetProductById(int id);
        void SaveProduct(Product product);
        void UpdateProduct(Product product);
        void RemoveProduct(Product product);
        IEnumerable<Product> GetProductsByCategoryId(int id);

    }

}