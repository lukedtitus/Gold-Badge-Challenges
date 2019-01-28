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
    }
}
