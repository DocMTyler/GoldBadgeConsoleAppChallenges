using ClaimRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Claim_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            ClaimRepositoryQueue claimEntries = new ClaimRepositoryQueue();

            Queue<Claim> claimItem = new Queue<Claim>();

            SeedContent();

            int claimCount = 0;

            bool menuRunning = true;
            while (menuRunning)
            {
                Console.WriteLine("______________Menu_______________");
                Console.WriteLine("1. See All Claims");
                Console.WriteLine("2. Take Care of Next Claim");
                Console.WriteLine("3. Enter a new claim");
                Console.WriteLine("4. Exit");
                Console.WriteLine("                                  \n");
                Console.WriteLine("Please enter the number of the option you would like to select");

                int inputOption = Convert.ToInt32(Console.ReadLine());

                if (inputOption == 4)
                {
                    Console.WriteLine("Press any key to continue");
                    Console.ReadLine();
                    menuRunning = false;
                    break;
                }
                else if (inputOption <= 0 || inputOption > 4)
                {
                    Console.WriteLine("Please enter a valid input\n");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadLine();
                }
                else
                {
                    switch (inputOption)
                    {
                        case 1:
                            ReadAllClaims();
                            break;

                        case 2:
                            ReadAllClaims();
                            Console.WriteLine("The next claim is at the top of the list. Would you like to deal with this claim now? Press 'y' for yes, 'n' for no");
                            string ynResponse = Console.ReadLine();
                            if(ynResponse == "y")
                            {
                                RemoveClaimFromQ();
                                break; 
                            }
                            else { break; }
                        case 3:
                            AddClaimToQ();
                            break;
                    }
                }
            }
            
            void SeedContent()
            {
                Claim carClaim = new Claim(1, "Car", "fender bender", 400.00m, new DateTime(2020, 09, 07), new DateTime(2020, 09, 28), true);
                Claim homeClaim = new Claim(2, "Home", "big fire", 40000.00m, new DateTime(2020, 04, 12), new DateTime(2020, 04, 11), true);
                Claim theftClaim = new Claim(3, "Theft", "stolen pancakes", 4.00m, new DateTime(2018, 04, 27), new DateTime(2018, 06, 01), false);

                claimEntries.AddClaimToQueue(carClaim);
                claimEntries.AddClaimToQueue(homeClaim);
                claimEntries.AddClaimToQueue(theftClaim);
            }
            void ReadAllClaims()
            {
                Queue<Claim> listClaims = claimEntries.ReadClaims();
                foreach(Claim individClaim in listClaims)
                {
                    Console.WriteLine("\n\nClaim ID\n" + individClaim.ClaimID + "\n\nClaim Type\n" + individClaim.Type + "\n\nDescription\n" + individClaim.Description + "\n\nClaimAmount\n" + individClaim.ClaimAmount + "\n\nDate of Incident \n" + individClaim.DateOfIncident + "\n\nDate of Claim \n" + individClaim.DateOfClaim + "\n\nThis claim is valid,True or False? \n" + individClaim.IsValid +"\n");
                }

            }
            void RemoveClaimFromQ()
            {
                
                claimEntries.RemoveClaimFromQueue();
            }
            void AddClaimToQ()
            {
                claimCount++;
                Claim addClaim = new Claim();

                addClaim.ClaimID = claimCount;
                
                Console.WriteLine("What type of claim is this, Car, Home, or Theft?\n");
                string claimTypeInput = Console.ReadLine().ToLower();
                if (claimTypeInput == "car" || claimTypeInput == "home" || claimTypeInput == "theft")
                {
                    addClaim.Type = claimTypeInput;
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                    addClaim.Type = "General";
                }
            
                Console.WriteLine("Please enter a description for the claim.\n");
                string claimDescription = Console.ReadLine();
                addClaim.Description = claimDescription;

                Console.WriteLine("Please enter the amount of the claim.\n");
                decimal claimAmount = Convert.ToDecimal(Console.ReadLine());
                addClaim.ClaimAmount = claimAmount;

                Console.WriteLine("Please enter the date of the incident. First, what year did it occur(YYYY)?\n");
                int year = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Please enter the month of the incident(MM).\n");
                int month = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Please enter the day of the month of the incident(DD).\n");
                int day = Convert.ToInt32(Console.ReadLine());
                DateTime incidentDate = new DateTime(year, month, day);
                addClaim.DateOfIncident = incidentDate;

                Console.WriteLine("Please enter the date of the claim. First, what year did it occur(YYYY)?\n");
                int claimYear = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Please enter the month of the claim(MM).\n");
                int claimMonth = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Please enter the day of the month of the claim(DD).\n");
                int claimDay = Convert.ToInt32(Console.ReadLine());
                DateTime claimDate = new DateTime(claimYear, claimMonth, claimDay);
                addClaim.DateOfClaim = claimDate;

                bool test = claimEntries.TestClaimValidity(incidentDate, claimDate);
                addClaim.IsValid = test;

                claimEntries.AddClaimToQueue(addClaim);
            }
        }//end main
    }
}
