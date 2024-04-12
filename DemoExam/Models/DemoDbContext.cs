using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoExam.Models
{
    internal class DemoDbContext :DbContext
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

        // Свойство, представляющее собой коллекцию сущностей типа Sotrudnik, для работы с данными сотрудников
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<City> Citys { get; set; }
    }
}
