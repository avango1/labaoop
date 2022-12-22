using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Osminin_Lab2
{
    internal class ReserachTeam : Team, INameAndCopy
    {

        private string resTopic;
        private TimeFrame duration;
        private ArrayList arrPap = new ArrayList();
        private ArrayList arrPer = new ArrayList();


        public ReserachTeam(string resTopic, string compName, int regNum, TimeFrame duration)
        {
            this.resTopic = resTopic;
            this.compName = compName;
            this.regNum = regNum;
            this.duration = duration;
        }

        public ReserachTeam()
        {
            resTopic = "Topic";
            compName = "Company Name";
            regNum = 0;
            duration = new TimeFrame();
            arrPap = new ArrayList();
            arrPer = new ArrayList();
        }


        public string ResTopic { get { return resTopic; } set { resTopic = value; } }
        public TimeFrame Duration { get { return duration; } set { duration = value; } }
        public ArrayList ListPap { get { return arrPap; } set { arrPap = value; } }
        public ArrayList ListMemb { get { return arrPer; } set { arrPer = value; } }
        public Team Team
        {
            get
            {
                return new Team(compName, regNum);
            }
            set
            {
                regNum = value.RegNum;
                compName = value.CompName;
            }
        }


        public new string Name { get; set; }



        public Paper Paper
        {
            get
            {
                System.DateTime dmax = new DateTime(0001, 1, 1);
                int index = 0;
                ArrayList List = new ArrayList();
                List.AddRange(arrPap);
                Paper[] newArray = (Paper[])List.ToArray(typeof(Paper));
                if (List.Count > 0)
                {
                    for (int i = 0; i < List.Count; i++)
                    {
                        if (newArray[i].Date > dmax)
                        {
                            dmax = newArray[i].Date;
                            index = i;
                        }
                    }
                    return newArray[index];
                }
                else return null;
            }
        }

        public bool this[TimeFrame timeFrame]
        {
            get
            {
                if (duration == timeFrame)
                    return true;
                else return false;
            }
        }

        public void AddPapers(params Paper[] arr)
        {
            arrPap.AddRange(arr);
        }


        public void AddMembers(params Person[] arr)
        {
            arrPer.AddRange(arr);
        }

        public virtual string ToShortString() => "Название исследования: " + resTopic + " Название компании: " + compName + " Регистрационный номер: " + regNum + " Продолжительность исследования: " + duration;
        public override string ToString()
        {
            string str = "Название исследования: " + resTopic + " Название компании: " + compName + " Регистрационный номер: " + regNum + " Продолжительность исследования: " + duration + " Список публикаций: " + "\n";
            foreach (var i in arrPap)
            {
                str += i.ToString() + "\n";
            }
            str += "Список участников: " + "\n";
            foreach (var i in arrPer)
            {
                str += i.ToString() + "\n";
            }
            return str;
        }

        public override bool Equals(object obj)
        {
            ReserachTeam team = obj as ReserachTeam;
            int ind = 0;
            int ind1 = 0;

            foreach (var i in team.arrPap)
            {
                if (arrPap.Contains(i) && team.arrPap.Count == arrPap.Count)
                    ind = 0;
                else
                    ind = 1;
            }

            foreach (var i in team.arrPer)
            {
                if (arrPer.Contains(i) && team.arrPer.Count == arrPer.Count)
                    ind1 = 0;
                else
                    ind1 = 1;
            }

            if (team.resTopic == ResTopic && team.compName == CompName && team.regNum == RegNum && ind == 0 && ind1 == 0)
            {
                return true;
            }
            else
                return false;
        }
        public static bool operator ==(ReserachTeam p1, ReserachTeam p2) => p1.Equals(p2);
        public static bool operator !=(ReserachTeam p1, ReserachTeam p2) => !p1.Equals(p2);


        public virtual new object DeepCopy()
        {
            ReserachTeam a = new ReserachTeam(resTopic, compName, regNum, duration);
            ArrayList arrayPer = new ArrayList(arrPer.Count);
            ArrayList arrayPap = new ArrayList(arrPap.Count);
            a.arrPer = arrayPer;
            a.arrPap = arrayPap;
            for (int i = 0; i < arrPap.Count; i++)
            {
                Paper a1 = (Paper)arrPap[i];
                Paper a1Copy = (Paper)a1.DeepCopy();
                arrayPap.Add(a1Copy);
            }
            for (int i = 0; i < arrPer.Count; i++)
            {
                Person a2 = (Person)arrPer[i];
                Person a2Copy = (Person)a2.DeepCopy();
                arrayPer.Add(a2Copy);
            }

            return a;
        }

        public virtual new int GetHashCode()
        {
            var hashCode = 0;
            hashCode += resTopic.GetHashCode() + compName.GetHashCode() + regNum.GetHashCode() + duration.GetHashCode();
            foreach (var i in arrPap)
            {
                hashCode += i.GetHashCode();
            }
            foreach (var i in arrPer)
            {
                hashCode += i.GetHashCode();
            }
            return hashCode;
        }

        public IEnumerator<Person> GetEnumerator()
        {
            int ind = 0;
            List<Person> per = new List<Person>();
            foreach (Person p in arrPer)
            {
                ind = 0;
                foreach (Paper paper in arrPap)
                {
                    if (paper.Person == p)
                    {
                        ind++;
                        continue;
                    }
                }
                if (ind == 0)
                {
                    per.Add(p);
                }
            }
            for (int i = 0; i < per.Count; i++)
            {
                yield return per[i];
            }
        }



        public IEnumerable<Paper> GetPaper(int n)
        {
            List<Paper> list = new List<Paper>();
            foreach (Paper p in arrPap)
            {
                if (p.Date > DateTime.Now.AddYears(-n) && p.Date < DateTime.Now)
                {
                    list.Add(p);
                }
            }
            for (int i = 0; i < list.Count; i++)
            {
                yield return list[i];
            }
        }

        public IEnumerable<Person> GetPerson()
        {
            int ind = 0;
            List<Person> per = new List<Person>();
            foreach (Person p in arrPer)
            {
                ind = 0;
                foreach (Paper paper in arrPap)
                {
                    if (paper.Person == p)
                    {
                        ind++;
                        continue;
                    }
                }
                if (ind > 0)
                {
                    per.Add(p);
                }
            }
            for (int i = 0; i < per.Count; i++)
            {
                yield return per[i];
            }
        }

        public IEnumerable<Person> GetPersonMore1Paper()
        {
            int ind = 0;
            List<Person> per = new List<Person>();
            foreach (Person p in arrPer)
            {
                ind = 0;
                foreach (Paper paper in arrPap)
                {
                    if (paper.Person == p)
                    {
                        ind++;
                        continue;
                    }
                }
                if (ind > 1)
                {
                    per.Add(p);
                }
            }
            for (int i = 0; i < per.Count; i++)
            {
                yield return per[i];
            }
        }

        public IEnumerable<Paper> GetPaperLastYear()
        {
            List<Paper> list = new List<Paper>();
            foreach (Paper p in arrPap)
            {
                if (p.Date > DateTime.Now.AddYears(-1) && p.Date < DateTime.Now)
                {
                    list.Add(p);
                }
            }
            for (int i = 0; i < list.Count; i++)
            {
                yield return list[i];
            }
        }


    }
}
