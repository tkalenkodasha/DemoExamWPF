using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoExam.Models
{
    public class Role
    {
        // Уникальный идентификатор роли.
        public int Id { get; set; }
        // Название роли.
        public string RoleName { get; set; }

        // Коллекция пользователей, связанных с данной ролью.
        // Используется виртуальное свойство для ленивой загрузки.
        public virtual ICollection<User> Users { get; set; }

        // Конструктор класса Role, который инициализирует коллекцию Users.
        public Role()
        {
            Users = new List<User>();
        }
    }
}