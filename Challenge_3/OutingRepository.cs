using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_3
{
    public class OutingRepository
    {
        List<Outing> _outingList = new List<Outing>();

        public List<Outing> GetOutingList()
        {
            return _outingList;
        }

        public void AddToOutingList(Outing outing)
        {
            _outingList.Add(outing);
        }

        //public void CalculateOutingCost()
        //{
        //    string userInput = Console.ReadLine();

        //    foreach (Outing outings in _outingList)
        //    {
        //        if (userInput == OutingType.Golf)
        //        {
                    
        //        }

        //        else if (userInput == OutingType.AmusementPark)
        //        {

        //        }

        //        else if (userInput == OutingType.Bowling)
        //        {

        //        }

        //        else if (userInput == OutingType.Concert)
        //        {

        //        }

        //        else
        //        {
        //            Console.WriteLine("That input is invalid");
        //        }
        //    }
        //}
    }
}
