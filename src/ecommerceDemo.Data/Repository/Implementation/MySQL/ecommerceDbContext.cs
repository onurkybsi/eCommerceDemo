using System;
using ecommerceDemo.Data.Model;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ecommerceDemo.Data.Repository.MySQL
{
    public class ecommerceDbContext : DbContextWrapper
    {
        public DbSet<User> User { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Basket> Basket { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Order> Order { get; set; }

        public ecommerceDbContext(IDatabaseSettings databaseSettings) : base(databaseSettings) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ModelUserEntity(modelBuilder);
            ModelProductEntity(modelBuilder);
            ModelCategoryEntity(modelBuilder);
            ModelBasketEntity(modelBuilder);
            ModelAddressEntity(modelBuilder);
            ModelOrderEntity(modelBuilder);
        }

        private void ModelUserEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id)
                        .ValueGeneratedOnAdd();

                entity.Property(e => e.FirstName).IsRequired();
                entity.Property(e => e.LastName).IsRequired();
                entity.Property(e => e.Email).IsRequired();
            });
        }

        private void ModelProductEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Id)
                        .ValueGeneratedOnAdd();

                entity.HasOne(p => p.Category);

                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Price).IsRequired();
            });
        }

        private void ModelCategoryEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Id)
                        .ValueGeneratedOnAdd();

                entity.Property(e => e.Name).IsRequired();
            });
        }

        private void ModelBasketEntity(ModelBuilder modelBuilder) { }

        private void ModelAddressEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.Id)
                        .ValueGeneratedOnAdd();

                entity.Property(p => p.Country).IsRequired();
                entity.Property(p => p.City).IsRequired();
                entity.Property(p => p.District).IsRequired();
                entity.Property(p => p.Zip).IsRequired();
                entity.Property(p => p.AddressDetail).IsRequired();
            });
        }

        private void ModelOrderEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Id)
                        .ValueGeneratedOnAdd();

                entity.HasOne(e => e.Owner);
                entity.HasOne(e => e.Basket);
                entity.HasOne(e => e.Address);
            });
        }
    }
}