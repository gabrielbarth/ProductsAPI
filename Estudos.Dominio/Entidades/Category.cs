using Estudos.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Estudos.Dominio.Models
{
    public class Category
    {
        public virtual int Id { get; protected set; }
        public virtual string Title { get; protected set; }
        public virtual ICollection<Product> Products { get; protected set; }

        public Category(int id, string title)
        {
            Id = id;
            Title = title;
        }

        public virtual void AddProduct(Product product)
        {
            Products.Add(product);
        }

        protected Category()
        {

        }

    }
}