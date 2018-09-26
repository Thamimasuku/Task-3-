using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public enum Direction { North, South, East, West }
     
    public abstract class Units
    {
        protected int yPos;
        protected int xPos;
        protected int attack;
        protected int speed;
        protected int heath;
        protected int range;
        protected int faction;
        protected string name;
        protected string symbol;

        abstract public void Move(Direction direction);
        abstract public void Combat(Units u);
        abstract public bool inRange(Units u);
        abstract public Units Closest(Units[] units);
        abstract public bool IsDead();
        
        //abstract public void tostring();


    }
}
