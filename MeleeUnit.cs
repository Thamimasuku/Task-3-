using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class MeleeUnit: Units
    {
        
        public int XPos
        {
            get { return xPos; }
            set { xPos = value; }
        }

        public int YPos
        {
            get { return yPos; }
            set { yPos = value; }
        }

        public int Attack
        {
            get { return attack; }
            set { attack = value; }
        }

        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }
        
        public int Health
        {
            get { return heath; }
            set { heath = value; }
        }

         public int Range
        {
            get { return range; }
            set { range = value; }
        }

        public int Faction
        {
            get { return faction; }
            set { faction = value; }
        }

        public string Symbol
        {
            get { return symbol; }
            set { symbol = value; }
        }

        public MeleeUnit(int x, int y, int health, int attack, int range, int speed, int faction, string symbol)
        {
            XPos = x;
            YPos = y;
            Health = health;
            Speed = speed;
            Attack = attack;
            Range = range;
            Faction = faction;
            Symbol = symbol;
        }

        public override void Move(Direction d)
        {
            switch (d)
            {
                case Direction.North:
                    {
                        YPos += Speed;
                        break;
                    }
                case Direction.East:
                    {
                        XPos += Speed;
                        break;
                    }
                case Direction.South:
                    {
                        YPos += Speed;
                        break;
                    }
                case Direction.West:
                    {
                        XPos += Speed;
                        break;
                    }
            }
        }
        public override void Combat(Units u)
        {
            if (u.GetType()== typeof(MeleeUnit))
            {
                Health -= ((MeleeUnit)u).Attack;
            }
            //else if (u.GetType() == typeof(RangedUnit))
            //{
            //     Health -= ((RangedUnit)u).Attack;
            //}
        }
        public override bool IsDead()
        {
            if(Health <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public override Units Closest(Units[] units)
        {
            Units closest = this;
            int closestDistance = 50;
            foreach(Units u in units)
            {
                if (u.GetType() == typeof(MeleeUnit))
                {
                    if (((MeleeUnit)u).Faction != Faction)
                        if (DistanceTo(u) < closestDistance)
                        {
                            closest = u;
                            closestDistance = DistanceTo(u); 
                        }
                }
                //if (u.GetType() == typeof(MeleeUnit))
                //{
                //    if (((MeleeUnit)u).Faction != Faction)
                //        if (DistanceTo(u) < closestDistance)
                //        {
                //            closest = u;
                //            closestDistance = DistanceTo(u);
                //        }
                //}
            }
            return closest;
            
        }
        public override bool inRange(Units u)
        {
            if (u.GetType() == typeof(MeleeUnit))
            {
                MeleeUnit m = (MeleeUnit)u;

                if (DistanceTo(u) <= Range)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public override string ToString()
        {
            return "MU: " + XPos + ", " + YPos + ", " + Health;
        }

     
        //public override bool Equals(object obj)
        //{
        //    return base.Equals(obj);
        //}
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }


        private int DistanceTo(Units u)
        {
            if (u.GetType() == typeof(MeleeUnit))
            {
                MeleeUnit m = (MeleeUnit)u;
                int d = Math.Abs(XPos - m.XPos) + Math.Abs(YPos - m.YPos);
                return d;

            }
            else
            {
                return 0;
            }
        }

        public Direction DirectionTo(Units u)
        {
            if (u.GetType() == typeof(MeleeUnit))
            {
                MeleeUnit m = (MeleeUnit)u;
                if (m.XPos < XPos)
                {
                    return Direction.East;
                }
                else if (m.YPos > YPos)
                {
                    return Direction.South;
                }
                else if (m.XPos < XPos)
                {
                    return Direction.North;
                }
                else
                {
                    return Direction.West;
                }
            }
        }



    }
}
