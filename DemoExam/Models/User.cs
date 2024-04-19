using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoExam.Models
{
    class User
    {
        // Уникальный идентификатор пользователя.
        public int Id { get; set; }
        // Логин пользователя.
        public string Login { get; set; }
        // Пароль пользователя.
        public string Password { get; set; }
        // Идентификатор роли, к которой принадлежит пользователь.
        public int RoleId { get; set; }
        // Ссылка на объект Role, представляющий роль пользователя.
        public virtual Role Role { get; set; }
    }
}
