using BadgeRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Badge_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            BadgeRepositoryDictionary badgeDoorAccess = new BadgeRepositoryDictionary();
            SeedContent();

            bool menuRunning = true;
            while (menuRunning)
            {
                Console.WriteLine("______________Menu_______________");
                Console.WriteLine("1. Add A Badge");
                Console.WriteLine("2. Update a Badge");
                Console.WriteLine("3. List All Badges");
                Console.WriteLine("4. Exit");
                Console.WriteLine("                                  \n");
                Console.WriteLine("Please enter the number of the option you would like to select");
                var menuInputResponse = Convert.ToInt32(Console.ReadLine());

                if (menuInputResponse == 4)
                {
                    Console.WriteLine("Press any key to continue");
                    Console.ReadLine();
                    menuRunning = false;
                    break;
                }else if (menuInputResponse < 1 || menuInputResponse > 4)
                {
                    Console.WriteLine("Invalid input");
                    continue;
                }
                else
                {
                    switch (menuInputResponse)
                    {
                        case 1:
                            AddBadgeAccess();
                            break;
                        case 2:
                            UpdateBadgeAccess();
                            break;
                        case 3:
                            ListAllBadges();
                            break;
                    }
                }
            }
            void SeedContent()
            {
                List<string> doorAccess = new List<string>() { "A1", "B2" };
                List<string> doorAccess1 = new List<string>() { "C3", "D4" };
                List<string> doorAccess2 = new List<string>() { "E5", "F6" };
                List<string> doorAccess3 = new List<string>() { "G7", "H8" };

                Badge doorBadge1 = new Badge(12,doorAccess);
                Badge doorBadge2 = new Badge(34,doorAccess1);
                Badge doorBadge3 = new Badge(56,doorAccess2);
                Badge doorBadge4 = new Badge(78,doorAccess3);

                badgeDoorAccess.AddBadgeAccessToDict(doorBadge1);
                badgeDoorAccess.AddBadgeAccessToDict(doorBadge2);
                badgeDoorAccess.AddBadgeAccessToDict(doorBadge3);
                badgeDoorAccess.AddBadgeAccessToDict(doorBadge4);

                Console.WriteLine(badgeDoorAccess);
            }
            void ListAllBadges() 
            {
                Dictionary<int, List<string>> masterBadgeDoorAccessList = badgeDoorAccess.ListBadgeAccess();
                foreach (KeyValuePair<int, List<string>> entry in masterBadgeDoorAccessList)
                {
                    string tempValue=null;
                    
                    foreach(string valueItem in entry.Value)
                    {
                        tempValue += valueItem + " ";
                    }
                    Console.WriteLine($"Key = {entry.Key}, Value = {tempValue}");
                }
                return;
            }
            void AddBadgeAccess() 
            {
                List<string> newBadgeAccess = new List<string>();

                Console.WriteLine("What is the badge number you would like to add? Integers only");
                int badgeInput = Convert.ToInt32(Console.ReadLine());
                
                        bool keepAdding = true;
                        while (keepAdding)
                        {
                            Console.WriteLine("What door would you like this badge to access?");
                            string accessInput = Console.ReadLine();
                            newBadgeAccess = badgeDoorAccess.AddDoorAccess(accessInput);

                            Console.WriteLine("Would you like to add any more doors? 'y' for yes, 'n' for no");
                            string moreDoors = Console.ReadLine();
                            if (moreDoors == "y" || moreDoors == "Y")
                            {

                                Console.WriteLine("Please enter the door you would like to add");
                                string moreAccessInput = Console.ReadLine();
                                newBadgeAccess.Add(moreAccessInput);
                                break;
                            }else if(moreDoors=="n" || moreDoors == "N")
                            {
                                keepAdding = false;
                                break;
                            }
                            else
                            {
                                keepAdding = false;
                                break;
                            }
                        }
                Badge initializedBadge = new Badge(badgeInput, newBadgeAccess);
                badgeDoorAccess.AddBadgeAccessToDict(initializedBadge);
            }
            void UpdateBadgeAccess() 
            {
                Console.WriteLine("What badge what you like to update?");
                int badgeEntry = Convert.ToInt32(Console.ReadLine());
                List<string> forGetValues = badgeDoorAccess.GetValues(badgeEntry);
                Dictionary<int, List<string>> masterBadgeDoorAccessList = badgeDoorAccess.ListBadgeAccess();

                    if(masterBadgeDoorAccessList.ContainsKey(badgeEntry))
                    {
                        Console.WriteLine("Would you like to Add or Remove access? A for Add, R for Remove");
                        string accessEntry = Console.ReadLine();
                        if (accessEntry == "A" || accessEntry == "a")
                        {
                            Console.WriteLine("What door would you like to add access to for this badge?");
                            string doorAdded = Console.ReadLine();
                            forGetValues.Add(doorAdded);
                            return;
                        }
                        else if (accessEntry == "R" || accessEntry == "r")
                        {
                            Console.WriteLine("What door would you like to remove access to?");
                            string doorRemoved = Console.ReadLine();
                            forGetValues.Remove(doorRemoved);
                            return;
                        }
                        else { Console.WriteLine("Invalid input"); return; }
                    }
            }
        }
    }
}
