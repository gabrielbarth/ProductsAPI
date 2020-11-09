using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

using Estudos.Dominio.Entidades;

namespace Estudos.Repositorio.Mapping
{
    public class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            Schema("dbo");
            Table("Product");
            Id(x => x.Id).Column("Id").GeneratedBy.Identity();
            Map(x => x.Title).Column("Title").CustomSqlType("varchar").Length(60).Not.Nullable();
            Map(x => x.Description).Column("Description").CustomSqlType("varchar").Length(60).Not.Nullable();
            Map(x => x.Price).Column("Price").CustomSqlType("float").Not.Nullable();
            Map(x => x.Quantity).Column("Quantity").CustomSqlType("int").Not.Nullable();
            Map(x => x.CreateDate).Column("CreateDate").CustomSqlType("date").Not.Nullable();
            Map(x => x.LastUpdateDate).Column("UpdateDate").CustomSqlType("date").Not.Nullable();

            // HasOne(x => x.Category).ForeignKey("CategoryId").LazyLoad().Cascade.SaveUpdate();
            References(x => x.Category, "CategoryId").Not.Nullable().Cascade.None();
        }

    }
}
