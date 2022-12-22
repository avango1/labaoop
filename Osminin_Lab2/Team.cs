using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osminin_Lab2
{
    internal class Team : Exception, INameAndCopy
    {
        protected string compName;
        protected int regNum;

        public Team(string orgName, int regNum)
        {
            this.compName = orgName;
            this.regNum = regNum;
        }

        public Team()
        {
            compName = "Organization name";
            regNum = 11111;
        }

        public string CompName { get { return compName; } set { compName = value; } }

        public Team(string message) : base(message) { }

        public int RegNum
        {
            get { return regNum; }

            set
            {
                if (value <= 0)
                {
                    throw new Team("Регистрационный номер не может быть меньше или равно 0");
                }
                else
                    regNum = value;
            }
        }

        public string Name { get; set; }

        public object DeepCopy()
        {
            return new Team(compName, regNum);
        }


        public virtual new bool Equals(object obj)
        {
            Team team = obj as Team;
            if (team.Name == Name && team.compName == CompName && team.regNum == RegNum)
            {
                return true;
            }
            else
                return false;
        }

        public static bool operator ==(Team p1, Team p2) => p1.Equals(p2);
        public static bool operator !=(Team p1, Team p2) => !p1.Equals(p2);

        public virtual new int GetHashCode() => compName.GetHashCode() ^ regNum.GetHashCode();

        public virtual new string ToString() => "Название организации: " + compName + "; " + "Регистрационный номер: " + regNum;

    }
}
