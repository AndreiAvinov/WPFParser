using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lab2
{
    public class CyberDanger : IEquatable<CyberDanger>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Source { get; set; }
        public string Target { get; set; }
        public bool Conf { get; set; }
        [XmlIgnore]
        public string RUConf
        {
            get
            {
                if (Conf == true)
                    return "Да";
                else
                    return "Нет";
            }
            set { }
        }
        public bool Integrity { get; set; }
        [XmlIgnore]
        public string RUIntegrity
        {
            get
            {
                if (Integrity == true)
                    return "Да";
                else
                    return "Нет";
            }
            set { }
        }
        public bool Access { get; set; }
        [XmlIgnore]
        public string RUAccess
        {
            get
            {
                if (Access == true)
                    return "Да";
                else
                    return "Нет";
            }
            set { }
        }
        [XmlIgnore]
        public string SpecId
        {
            get
            {
                return $"УБИ.{Id}";
            }
            set { }
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as CyberDanger);
        }

        public bool Equals(CyberDanger other)
        {
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
            hashCode = hashCode * -1521134295 + Id;
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
            return $"{SpecId} {Name}";
        }
    }
}
