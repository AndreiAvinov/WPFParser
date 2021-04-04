using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class CyberDanger
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Source { get; set; }
        public string Target { get; set; }
        public bool Conf { get; set; }
        public bool Integrity { get; set; }
        public bool Access { get; set; }

        public static Dictionary<string, string> translation = new Dictionary<string, string>()
        {
            { "Id" , "Идентификатор"},
            { "Name" , "Наименование"},
            { "Description" , "Описание"},
            { "Source" , "Источник"},
            { "Target" , "Объект воздействия"},
            { "Conf" , "Нарушение конфиденциальности"},
            { "Integrity" , "Нарушение целостности"},
            { "Access" , "Нарушение доступности"},
        };

    }
}
