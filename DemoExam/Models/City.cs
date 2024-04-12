using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoExam.Models
{
    public class City
    {
        // Уникальный идентификатор города
        public int Id { get; set; }
        // Название города
        public string CityName { get; set; }
        // Список сотрудников, проживающих в данном городе
        // Отношение многие-ко-многим: один город может быть местом проживания многих сотрудников,
        // и один сотрудник может проживать только в одном городе
        public virtual List<Employer> Employers { get; set; }
        public City()
        {
            // Инициализация списка сотрудников
            Employers = new List<Employer>();
        }

        // Возвращает название города в строку
        public override string ToString()
        {
            return CityName;
        }
    }
}
