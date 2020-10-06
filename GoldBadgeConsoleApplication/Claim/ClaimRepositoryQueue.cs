using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimRepository
{
    public class ClaimRepositoryQueue
    {
        Queue<Claim> claimItem = new Queue<Claim>();
        
        //Create a claim, add to queue 
        public bool AddClaimToQueue(Claim claim)
        {
            int beforeEnqueue = claimItem.Count;
            claimItem.Enqueue(claim);
            bool isAddedToQ = (claimItem.Count > beforeEnqueue);
            return isAddedToQ;
        }

        //Read all claims
        public Queue<Claim> ReadClaims()
        {
            return claimItem;
        }

        //Delete a claim, remove from queue
        public void RemoveClaimFromQueue()
        {
            int beforeDequeue = claimItem.Count;
            claimItem.Dequeue();
            bool isRemovedFromQ = (claimItem.Count < beforeDequeue);
            Console.WriteLine(isRemovedFromQ);
            return;
        }

        //See if a claim is valid or not
        public bool TestClaimValidity(DateTime incidentDate, DateTime claimDate)
        {
            DateTime dateGreater = new DateTime(2020, 10, 1);
            DateTime dateLesser = new DateTime(2020, 9, 1);
            
            TimeSpan claimPeriod = new TimeSpan();
            TimeSpan validPeriod = new TimeSpan();

            claimPeriod = claimDate - incidentDate;
            validPeriod = dateGreater - dateLesser;

            bool claimIsValid = (claimPeriod < validPeriod);
            return claimIsValid;
        }
    }
}
