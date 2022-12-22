using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osminin_Lab2
{
    internal class Person
    {
        private string _name = "Ryan";
        private string _surname = "Gosling";
        private System.DateTime _birthday = new DateTime(1980, 11, 12);

        public Person(string name, string surname, System.DateTime birthday)
        {
            _name = name;
            _surname = surname;
            _birthday = birthday;
        }


        public Person()
        {
            _name = "Ryan";
            _surname = "Gosling";
            _birthday = new DateTime(1980, 11, 12);
        }

        public string Name { get { return _name; } set { _name = value; } }

        public string Surname { get { return _surname; } set { _surname = value; } }

        public System.DateTime Birthday { get { return _birthday; } set { _birthday = value; } }

        public int Year { get { return _birthday.Year; } set { _birthday = _birthday.AddYears(value - this.Year); } }


        public override string ToString() => "Фамилия: " + _surname + "; " + "Имя: " + _name + "; " + "Дата рождения: " + _birthday;
        public virtual string ToShortString() => "Фамилия: " + _surname + "; " + "Имя: " + _name;

        public override bool Equals(object obj)
        {
            Person person = obj as Person;
            if (person.Name == _name && person.Surname == _surname && person.Birthday == _birthday)
            {
                return true;
            }
            else
                return false;
        }
        public static bool operator ==(Person p1, Person p2) => p1.Equals(p2);
        public static bool operator !=(Person p1, Person p2) => !p1.Equals(p2);

        public virtual new int GetHashCode() => _surname.GetHashCode() ^ _birthday.GetHashCode() ^ _name.GetHashCode();



        public object DeepCopy() => new Person(_name, _surname, _birthday);
    }
}
