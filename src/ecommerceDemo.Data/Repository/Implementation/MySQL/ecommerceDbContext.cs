using System;
using ecommerceDemo.Data.Model;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ecommerceDemo.Data.Repository.MySQL
{
    public class ecommerceDbContext : AdvancedDbContext
    {
        public DbSet<Product> Products { get; set; }
        // public DbSet<Basket> Baskets { get; set; }
        public DbSet<Category> Categories { get; set; }
        // public DbSet<Order> Orders { get; set; }
        // public DbSet<Address> Addresses { get; set; }

        public ecommerceDbContext(IDatabaseSettings databaseSettings) : base(databaseSettings) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ModelProductEntity(modelBuilder);
            // ModelBasketEntity(modelBuilder);
            // ModelCategoryEntity(modelBuilder);
            // ModelOrderEntity(modelBuilder);
            // ModelAddressEntity(modelBuilder);
        }

        private void ModelProductEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Id)
                        .ValueGeneratedOnAdd();

                entity.HasOne(p => p.Category);
            });
        }

        private void ModelBasketEntity(ModelBuilder modelBuilder)
        {
            throw new NotImplementedException();
        }

        private void ModelCategoryEntity(ModelBuilder modelBuilder)
        {
            throw new NotImplementedException();
        }

        private void ModelOrderEntity(ModelBuilder modelBuilder)
        {
            throw new NotImplementedException();
        }

        private void ModelAddressEntity(ModelBuilder modelBuilder)
        {
            throw new NotImplementedException();
        }
    }
}