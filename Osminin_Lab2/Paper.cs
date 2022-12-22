using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osminin_Lab2
{
    internal class Paper
    {
        public string Title { get; set; }
        public Person Person { get; set; }
        public System.DateTime Date { get; set; }


        public Paper(string title, Person person, System.DateTime date)
        {
            Title = title;
            Person = person;
            Date = date;
        }

        public Paper(string title, System.DateTime date)
        {
            Title = title;
            Date = date;
        }

        public Paper()
        {
            Title = "1";
            Person = new Person("Name", "Surname", new DateTime());
            Date = new DateTime();
        }

        public override string ToString() => "Название публикации: " + Title + " " + "Автор: " + Person + " " + "Дата публикации: " + Date;


        public override bool Equals(object obj)
        {
            Paper paper = obj as Paper;
            if (paper.Title == Title && paper.Person == Person && paper.Date == Date)
            {
                return true;
            }
            else
                return false;
        }
        public static bool operator ==(Paper p1, Paper p2) => p1.Equals(p2);
        public static bool operator !=(Paper p1, Paper p2) => !p1.Equals(p2);

        public override int GetHashCode() => Title.GetHashCode() ^ Person.GetHashCode() ^ Date.GetHashCode();

        public object DeepCopy() => new Paper(Title, Person, Date);




    }
}
