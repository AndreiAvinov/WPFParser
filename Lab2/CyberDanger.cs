using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class CyberDanger
    {
        public int id;
        public string name;
        public string description;
        public string source;
        public string target;
        public bool conf;
        public bool integrity;
        public bool access;

        public static Dictionary<string, string> translation = new Dictionary<string, string>()
        {
            { "id" , "Идентификатор"},
            { "name" , "Наименование"},
            { "description" , "Описание"},
            { "source" , "Источник"},
            { "target" , "Объект воздействия"},
            { "conf" , "Нарушение конфиденциальности"},
            { "integrity" , "Нарушение целостности"},
            { "access" , "Нарушение доступности"},
        };

    }
}
