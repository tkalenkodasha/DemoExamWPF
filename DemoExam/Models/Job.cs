using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoExam.Models
{
    public class Job
    {

        // Уникальный идентификатор должности
        public int Id { get; set; }
        // Название должности
        public string JobName { get; set; }
        // Список сотрудников, занимающих данную должность
        // Отношение многие-ко-многим: одна должность может быть занята многими сотрудниками,
        // и один сотрудник может занимать только одну должность
        public virtual List<Employer> Employers { get; set; }

        public Job()
        {
            // Инициализация списка сотрудников
            Employers = new List<Employer>();
        }
        // Возвращает название должности
        public override string ToString()
        {
            return JobName;
        }
    }
}
