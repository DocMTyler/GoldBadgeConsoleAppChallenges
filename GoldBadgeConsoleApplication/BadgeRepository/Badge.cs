using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BadgeRepository
{
    public class Badge
    {
        public int BadgeID { get; set; }
        public List<string> DoorAccess { get; set; }

        public Badge() { }
        
        public Badge(int badgeID, List<string> doorAccess)
        {
            BadgeID = badgeID;
            DoorAccess = doorAccess;

        }
    }
}

    //public class Access
    //{
    //    public string DoorAccess { get; set; }
    //    public Access() { }
    //    public Access(string access)
    //    {
    //        DoorAccess = access;
    //    }
    //}

