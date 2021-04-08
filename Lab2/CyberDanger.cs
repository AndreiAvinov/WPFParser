using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class CyberDanger : IEquatable<CyberDanger>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Source { get; set; }
        public string Target { get; set; }
        public bool Conf { get; set; }
        public bool Integrity { get; set; }
        public bool Access { get; set; }

        //public static Dictionary<string, string> translation = new Dictionary<string, string>()
        //{
        //    { "Id" , "Идентификатор"},
        //    { "Name" , "Наименование"},
        //    { "Description" , "Описание"},
        //    { "Source" , "Источник"},
        //    { "Target" , "Объект воздействия"},
        //    { "Conf" , "Нарушение конфиденциальности"},
        //    { "Integrity" , "Нарушение целостности"},
        //    { "Access" , "Нарушение доступности"},
        //};

        public override bool Equals(object obj)
        {
            return Equals(obj as CyberDanger);
        }

        public bool Equals(CyberDanger other)
        {
            //bool res = Id == other.Id &&
            //       Name == other.Name &&
            //       Description == other.Description &&
            //       Source == other.Source &&
            //       Target == other.Target &&
            //       Conf == other.Conf &&
            //       Integrity == other.Integrity &&
            //       Access == other.Access;
            //Console.WriteLine($"Visited Equals() method, result: {res}");
            return other != null &&
                   Id == other.Id &&
                   Name == other.Name &&
                   Description == other.Description &&
                   Source == other.Source &&
                   Target == other.Target &&
                   Conf == other.Conf &&
                   Integrity == other.Integrity &&
                   Access == other.Access;
        }

        public override int GetHashCode()
        {
            int hashCode = -1353763451;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Id);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Description);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Source);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Target);
            hashCode = hashCode * -1521134295 + Conf.GetHashCode();
            hashCode = hashCode * -1521134295 + Integrity.GetHashCode();
            hashCode = hashCode * -1521134295 + Access.GetHashCode();
            return hashCode;
        }

        public string ToShortString()
        {
            return $"УБИ.{Id} {Name}";
        }
    }
}
