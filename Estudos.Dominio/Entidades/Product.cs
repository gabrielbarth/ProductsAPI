using Estudos.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Estudos.Dominio.Entidades
{
    public class Product
    {
        public virtual  int Id { get; protected set; }
        public virtual string Title { get; protected set; }
        public virtual string Description { get; protected set; }
        public virtual decimal Price { get; protected set; }
        public virtual int Quantity { get; protected set; }
        public virtual DateTime CreateDate { get; protected set; }
        public virtual DateTime LastUpdateDate { get; protected set; }
        public virtual Category Category { get; protected set; }


        public Product(int id, string title, string description, decimal price, int quantity, DateTime createDate, DateTime lastUpdateDate, Category category)
        {
            Id = id;
            Title = title;
            Description = description;
            Price = price;
            Quantity = quantity;
            CreateDate = createDate;
            LastUpdateDate = lastUpdateDate;
            Category = category;
        }

        protected Product()
        {

        }


    }
}