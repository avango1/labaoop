using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osminin_Lab2
{
    public enum TimeFrame
    {
        Year,
        TwoYears,
        Long
    }

    internal class Program
    {
        public static void Main(string[] args)
        {

            Person theRock = new Person("Dwayne", "Johnson", new DateTime(1972, 05, 02));
            Person misha = new Person("Michael", "Mironov", new DateTime(2003, 05, 19));
            Person alex = new Person("Alex", "Osminin", new DateTime(2003, 11, 26));
            Person rya = new Person();
            Person alex2 = new Person("Alex2", "Osminin2", new DateTime(2003, 11, 26));
            Person p1 = new Person("P1", "p1", new DateTime(2003, 11, 26));
            Person p2 = new Person("P2", "p2", new DateTime(2003, 11, 26));
            Person p3 = new Person("P3", "p3", new DateTime(2003, 11, 26));
            Person person = new Person(null, null, new DateTime());
            Person lesha = new Person("Lesha", "Osminin", new DateTime(2006, 09, 24));

            Paper paper = new Paper("Python", alex, new DateTime(1990, 10, 07));
            Paper pap = new Paper("JS", alex, new DateTime(1990, 10, 07));
            Paper paper1 = new Paper("Java", misha, new DateTime(2020, 11, 5));
            Paper paper3 = new Paper("C#", rya, new DateTime(2021, 6, 12));
            Paper paper4 = new Paper("C++", theRock, new DateTime(2022, 4, 20));
            Paper paper5 = new Paper("Kotlin", theRock, new DateTime(2021, 12, 20));


            ReserachTeam research1 = new ReserachTeam("Programming Languages", "VK", 1123, TimeFrame.Year);
            ReserachTeam research2 = new ReserachTeam("English lessons", "RTU MIREA", 12, TimeFrame.Long);
            ReserachTeam research3 = new ReserachTeam("Deutch lessons", "RTU MIREA", 13, TimeFrame.Long);


            Team t1 = new Team("RTU MIREA", 11);
            Team t2 = new Team("RTU MIREA", 11);


            Console.WriteLine("№ 1");

            t2.CompName = "ADAD";

            Console.WriteLine(t1 == t2);
            Console.WriteLine(t1.GetHashCode());
            Console.WriteLine(t2.GetHashCode());

            Console.WriteLine();

            Console.WriteLine("№ 2");

            try
            {
                t1.RegNum = -121;
            }
            catch (Team e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine();

            Paper[] papers = new Paper[2] { paper, paper1 };
            Paper[] papers2 = new Paper[2] { paper3, paper4 };


            research1.AddPapers(papers);
            research1.AddPapers(pap, paper5);
            research1.AddPapers(papers2);

            research1.AddMembers(alex, misha, alex2, p1);

            Console.WriteLine("№ 3");

            Console.WriteLine(research1.ToString());

            Console.WriteLine("№ 4");

            t2 = research3.Team;
            Console.WriteLine(t2.ToString());

            Console.WriteLine();

            Console.WriteLine("№ 5");
            research2 = (ReserachTeam)research1.DeepCopy();
            research1.AddMembers(p2, p3, rya, theRock);

            Console.WriteLine(research2.ToString());
            Console.WriteLine(research1.ToString());

            Console.WriteLine("№ 6");


            foreach (Person i in research1)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine();


            Console.WriteLine("№ 7");
            foreach (Paper p in research1.GetPaper(2))
            {
                Console.WriteLine(p);
            }

            Console.WriteLine();
            Console.WriteLine("№ 8");

            foreach (Person i in research1.GetPerson())
            {
                Console.WriteLine(i);
            }

            Console.WriteLine();
            Console.WriteLine("№ 9");

            foreach (Person p in research1.GetPersonMore1Paper())
            {
                Console.WriteLine(p);
            }

            Console.WriteLine();
            Console.WriteLine("№ 10");

            foreach (Paper p in research1.GetPaperLastYear())
            {
                Console.WriteLine(p);
            }



            Console.ReadKey();
        }
    }



}
