using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoExam.Models
{
    // Класс Gender представляет собой модель для хранения информации о полах
    public class Gender
    {
        // Уникальный идентификатор пола
        public int Id { get; set; }
        // Название пола
        public string GenderName { get; set; }
        // Список сотрудников данного пола
        // Отношение многие-ко-многим: один пол может быть у многих сотрудников,
        // и один сотрудник может иметь только один пол
        public virtual List<Employer> Employers { get; set; }
        public Gender()
        {
            // Инициализация списка сотрудников
            Employers = new List<Employer>();
        }
        // Возвращает название пола
        public override string ToString()
        {
            return GenderName;
        }
    }
}