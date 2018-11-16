using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_4
{
    public class BadgeRepository
    {
        List<string> doors = new List<string>();
        Dictionary<int, List<string>> _badgeList = new Dictionary<int, List<string>>();

        public void AddBadgeToList(Badge badge)
        {
            _badgeList.Add(badge.BadgeID, badge.DoorsAccessible);
        }

        public void RemoveDoorsFromBadge(int badge)
        {
            _badgeList.Remove(badge);
        }

        public Dictionary<int, List<string>> GetBadgeList()
        {
            return _badgeList;
        }
    }
}
