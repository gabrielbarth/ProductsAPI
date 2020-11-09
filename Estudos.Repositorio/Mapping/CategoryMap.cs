using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;

using Estudos.Dominio.Entidades;
using Estudos.Dominio.Models;

namespace Estudos.Repositorio.Mapping
{
    public class CategoryMap : ClassMap<Category>
    {
        public CategoryMap()
        {
            Schema("dbo");
            Table("Category");
            Id(x => x.Id).Column("Id").GeneratedBy.Identity();
            Map(x => x.Title).Column("Title").CustomSqlType("varchar").Length(60).Not.Nullable();

            HasMany(x => x.Products).KeyColumn("CategoryId").LazyLoad().Cascade.SaveUpdate();
        }
    }
}
