using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Persistence.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(256);

            Category category = new Category()
            {
                Id = 1,
                Name = "Elektirik",
                Priorty = 1,
                ParentId = 0,
                IsDeleted = false,
                CreatedDate = DateTime.Now
            };

            Category category1 = new Category()
            {
                Id = 2,
                Name = "Moda",
                Priorty = 1,
                ParentId = 0,
                IsDeleted = false,
                CreatedDate = DateTime.Now
            };

            Category parent = new Category()
            {
                Id = 3,
                Name = "Bilgisayar",
                Priorty = 1,
                ParentId = 1,
                IsDeleted = false,
                CreatedDate = DateTime.Now
            };

            Category parent1 = new Category()
            {
                Id = 4,
                Name = "Kadın",
                Priorty = 1,
                ParentId = 2,
                IsDeleted = false,
                CreatedDate = DateTime.Now
            };


            builder.HasData(category, category1, parent, parent1);


        }
    }
}
