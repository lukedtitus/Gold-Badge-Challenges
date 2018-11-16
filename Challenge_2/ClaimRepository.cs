using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_2
{
    class ClaimRepository
    {
        Queue<Claim> _claimsQueue = new Queue<Claim>();

        public void AddClaimToQueue(Claim items)
        {
            _claimsQueue.Enqueue(items);
        }

        public Queue<Claim> GetClaimList()
        {
            return _claimsQueue;
        }
    }
}
