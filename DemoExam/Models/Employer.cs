using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoExam.Models
{
    public class Employer
    {
        public int Id { get; set; }
        public string Pastname { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? Birthday { get; set; }

        // Идентификатор должности сотрудника
        // Отношение один-ко-многим: один сотрудник может занимать только одну должность,
        // но одна должность может быть занята многими сотрудниками
        public int JobId { get; set; }
        public virtual Job Job { get; set; }

        // Идентификатор пола сотрудника
        // Отношение один-ко-многим: один сотрудник может иметь только один пол,
        // но один пол может быть у многих сотрудников
        public int GenderId { get; set; }
        public virtual Gender Gender { get; set; }
        // Идентификатор города проживания сотрудника
        // Отношение один-ко-многим: один сотрудник может проживать только в одном городе,
        // но один город может быть местом проживания многих сотрудников
        public int CityID { get; set; }
        public virtual City City { get; set; }
        public int UserID { get; set; }
        public virtual User User { get; set; }

    }
}
