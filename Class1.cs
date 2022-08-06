
public class Monster
    {
        public int MID;
        public string Name;
        public int Level;
        public int Experience;
        public int Power;

        public Monster(int ID, string Name, int lv, int exp, int power)
        {
            MID = ID;
            Name = Name;
            Level = lv;
            Experience = exp;
            Power = power;
        }

        public Monster()
        {
            MID = 0;
            Name = "nullMonster";
            Level = 1;
            Experience = 0;
            Power = 0;
        }

        public void levelup(int over)
        {
            this.Level++;
            Experience = over; //leftover exp after levelup
        }

        public void checkEXP()
        {
            if (this.Level <= 0)
            {
                this.levelup(0);
            }

            if (this.Experience >= Math.Pow(2, this.Level))
            {
                this.levelup(this.Experience - Math.Pow(2, this.level));
            }
        }

    }
