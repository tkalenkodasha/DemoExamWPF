using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoExam.Models
{
    public class DemoDbContext :DbContext
    {
        // Объявление статического поля для хранения экземпляра контекста базы данных
        public static DemoDbContext _defaultContext;

        // Метод для получения экземпляра контекста базы данных, создает новый экземпляр, если он еще не создан
        public static DemoDbContext GetContext()
        {
            if (_defaultContext == null)
            {
                _defaultContext = new DemoDbContext();
            }

            return _defaultContext;
        }

        // Переопределение метода OnConfiguring для настройки параметров подключения к базе данных
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Строка подключения к базе данных MySQL
            var connectionString = "host=localhost; port=3360; user id=tklnk; password=123456; database=demodb;";
            // Настройка контекста на использование MySQL с указанной версией сервера
            optionsBuilder.UseMySql(connectionString, MySqlServerVersion.LatestSupportedServerVersion);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderProduct>()
                .HasKey(op => new { op.OrderId, op.ProductId });

            
            base.OnModelCreating(modelBuilder);
        }
        // Свойство, представляющее собой коллекцию сущностей типа Sotrudnik, для работы с данными сотрудников

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        

        public DbSet<Gender> Genders { get; set; }
        public DbSet<Employer> Employers { get; set; }
       
        public DbSet<City> Citys { get; set; }
        
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrdersProducts { get; set; }
        public DbSet<Product> Products { get; set; }    
        public DbSet<Client> Clients { get; set; }
        public DbSet<PickUpPoint> PickUpPoints { get; set; }

    }
}
