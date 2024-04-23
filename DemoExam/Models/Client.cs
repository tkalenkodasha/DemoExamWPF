using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoExam.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Pastname { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? Birthday { get; set; }


        // Идентификатор пола клиента
        // Отношение один-ко-многим: один клиент может иметь только один пол,
        // но один пол может быть у многих клиентов
        public int GenderId { get; set; }
        public virtual Gender Gender { get; set; }
        // Идентификатор города проживания клиента
        // Отношение один-ко-многим: один клиент может проживать только в одном городе,
        // но один город может быть местом проживания многих клиентов
        public int CityID { get; set; }
        public virtual City City { get; set; }
        public int UserID { get; set; }
        public virtual User User{ get; set; }

    }
}
