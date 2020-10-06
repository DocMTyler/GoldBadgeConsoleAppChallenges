using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgeRepository
{
    public class BadgeRepositoryDictionary
    {
        Dictionary<int, List<string>> badgeAccess = new Dictionary<int, List<string>>();
        List<string> doorAccess = new List<string>();

        //Get values at key
        public List<string> GetValues(int badgeID)
        {
            foreach(KeyValuePair<int, List<string>> value in badgeAccess)
            {
                if (value.Key == badgeID)
                {
                    return value.Value;
                }
            }return default;
            
        }

        //Add to access list
        public List<string> AddDoorAccess(string door)
        {
            int beforeAdded = doorAccess.Count;
            doorAccess.Add(door);
            Console.WriteLine(doorAccess);
            return doorAccess;
        }

        //Create a dictionary of Badge(key), Access(value) pairs
        public Dictionary<int,List<string>> AddBadgeAccessToDict (Badge badge)
        {
            int countBeforeAdded = badgeAccess.Count;
            badgeAccess.Add(badge.BadgeID,badge.DoorAccess);
            bool isAdded = (badgeAccess.Count > countBeforeAdded);
            Console.WriteLine(isAdded);
            //Console.WriteLine("You have added " + badgeAccess + " to the master badge list.");
            return badgeAccess;
        }

        //Return all items in the dictionary
        public Dictionary<int,List<string>> ListBadgeAccess()
        {
            return badgeAccess;
        } 

        //Remove from access list
        public List<string> RemoveDoorAccess(string door)
        {
            int beforeRemoved = doorAccess.Count;
            doorAccess.Remove(door);
            bool wasRemoved = (beforeRemoved > doorAccess.Count);
            Console.WriteLine("Removed from list, True or False?");
            Console.WriteLine(wasRemoved);
            return doorAccess;
        }
        
        //Update the Access(value) of a specified Badge(key)
        public void UpdateAccess(int badgeID, List<string> access)
        {
            var beforeUpdate = badgeAccess[badgeID].Count;
            badgeAccess[badgeID] = access;
            bool wasUpdated = (badgeAccess[badgeID].Count != beforeUpdate);
            Console.WriteLine("Was the access for this badge updated, True or False?");
            Console.WriteLine(wasUpdated);
            return;
        }
    }
}
