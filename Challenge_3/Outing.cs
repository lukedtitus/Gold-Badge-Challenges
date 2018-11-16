using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_3
{
    public enum OutingType
    {
        None,
        Golf = 1,
        Bowling,
        AmusementPark,
        Concert
    }

    public class Outing
    {
        public OutingType OutingType { get; set; }
        public int NumberAttented { get; set; }
        public DateTime DateAttended { get; set; }
        public double CostPerPerson { get; set; }
        public double EventCost { get; set; }

        public Outing(OutingType outingType, int numberAttended, DateTime dateAttended, double costPerPerson, double eventCost)
        {
            OutingType = outingType;
            NumberAttented = numberAttended;
            DateAttended = dateAttended;
            CostPerPerson = costPerPerson;
            EventCost = eventCost;
        }

        public Outing()
        {

        }
    }
}
