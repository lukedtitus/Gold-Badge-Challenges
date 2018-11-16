using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_4
{
    public class ProgramUI
    {
        BadgeRepository _badgeRepo = new BadgeRepository();

        public void Run()
        {
            RunMenu();
        }

        private void RunMenu()
        {
            bool running = true;
            while (running)
            {
                Console.Clear();

                Console.WriteLine("Welcome to the Badge System Manager\n" +
                    "1. Create a new badge\n" +
                    "2. Update doors on an existing badge\n" +
                    "3. Delete a badge from the list\n" +
                    "4. Show list of all badge numbers and their door access\n" +
                    "5. Exit.");

                int input = int.Parse(Console.ReadLine());

                switch (input)
                {
                    case 1:
                        CreateNewBadge();
                        break;
                    case 2:
                        UpdateDoorAccess();
                        break;
                    case 3:
                        DeleteBadge();
                        break;
                    case 4:
                        DisplayBadgeAccess();
                        break;
                    case 5:
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Response");
                        break;
                }
            }
        }

        public void CreateNewBadge()
        {
            Console.Clear();

            int badgeID = 0;
            List<string> doors = new List<string>();

            Console.WriteLine("What is the badge number?");
            badgeID = int.Parse(Console.ReadLine());

            Console.WriteLine("What door would you like to give this badge access to?");
            string doorInput = Console.ReadLine();
            doors.Add(doorInput);

            bool running = true;
            while (running)
            {
                Console.Clear();

                Console.WriteLine("Would you like to add another door? (y/n)");
                string yesOrNo = Console.ReadLine();
                switch (yesOrNo)
                {
                    case "y":
                        Console.WriteLine("What door would you like to give this badge access to?");
                        string doorInput2 = Console.ReadLine();
                        doors.Add(doorInput2);
                        break;
                    case "n":
                        running = false;
                        break;
                }
            }

            
            
            Badge newBadge = new Badge(badgeID, doors);

            _badgeRepo.AddBadgeToList(newBadge);
        }

        public void UpdateDoorAccess()
        {
            CreateNewBadge();
        }

        public void DeleteBadge()
        {
            Console.Clear();

            Dictionary<int, List<string>> badgeDict = _badgeRepo.GetBadgeList();
            Console.WriteLine("Please enter the BadgeID of the badge you would like to remove");
            int userInput = int.Parse(Console.ReadLine());

            foreach (var badgeID in badgeDict)
            {
                if (userInput == badgeID.Key)
                {
                    _badgeRepo.RemoveDoorsFromBadge(badgeID.Key);
                    break;
                }
            }
        }

        public void DisplayBadgeAccess()
        {
            Console.Clear();

            Dictionary<int, List<string>> badgeDict = _badgeRepo.GetBadgeList();
            foreach (KeyValuePair<int, List<string>> displayBadge in badgeDict)
            {
                Console.Write($"Badge ID: {displayBadge.Key}\n");
                Console.Write("Accessible Doors: ");
                
                foreach (string displayList in displayBadge.Value)
                {
                    Console.Write($"{displayList}\n");
                }

            }

            Console.WriteLine("\nPress enter to continue...");
            Console.ReadLine();
        }
    }
}
