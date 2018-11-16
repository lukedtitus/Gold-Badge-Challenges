using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_3
{
    class ProgramUI
    {
        OutingRepository _outingRepo = new OutingRepository();

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

                Console.WriteLine("Welcome to Komodo Outings. What would you like to do?\n" +
                    "1. Add outings to the list\n" +
                    "2. Display a list of all outings\n" +
                    "3. Display cost of all outings combined\n" +
                    "4. Display cost of specific outing\n" +
                    "5. Exit");

                int input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        AddOutingToList();
                        break;
                    case 2:
                        DisplayAllOutings();
                        break;
                    case 3:
                        DisplayCombinedCost();
                        break;
                    case 4:
                        DisplayByType();
                        break;
                    case 5:
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Response.");
                        break;
                }
            }
        }

        private void AddOutingToList()
        {
            Console.Clear();

            Outing newOuting = new Outing();
            Console.WriteLine("What is the Type? (Enter the number, not the name).\n" +
                "1. Golf\n" +
                "2. Bowling\n" +
                "3. Amusement Park\n" +
                "4. Concert");
            int outingTypeInput = int.Parse(Console.ReadLine());

            switch (outingTypeInput)
            {
                case 1:
                    newOuting.OutingType = OutingType.Golf;
                    break;
                case 2:
                    newOuting.OutingType = OutingType.Bowling;
                    break;
                case 3:
                    newOuting.OutingType = OutingType.AmusementPark;
                    break;
                case 4:
                    newOuting.OutingType = OutingType.Concert;
                    break;
                default:
                    Console.WriteLine("Invalid Response");
                    break;
            }

            Console.WriteLine("Number of people attented:");
            newOuting.NumberAttented = int.Parse(Console.ReadLine());

            Console.WriteLine("Date of outing: (YYYY/MM/DD)");
            newOuting.DateAttended = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Cost per person:");
            newOuting.CostPerPerson = double.Parse(Console.ReadLine());

            Console.WriteLine("Total event cost:");
            newOuting.EventCost = double.Parse(Console.ReadLine());

            _outingRepo.AddToOutingList(newOuting);
        }

        private void DisplayAllOutings()
        {
            Console.Clear();
            List<Outing> outingList = _outingRepo.GetOutingList();
            foreach (Outing outing in outingList)
            {
                Console.WriteLine($"Outing type: {(OutingType)outing.OutingType}\n" + //--fix this--//
                    $"Number of people attended: {outing.NumberAttented}\n" +
                    $"Date of event: {outing.DateAttended.ToShortDateString()}\n" +
                    $"Cost per person: {outing.CostPerPerson}\n" +
                    $"Total event cost: {outing.EventCost}");
            }

            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
        } 

        private void DisplayByType()
        {
            Console.Clear();
            List<Outing> outingList = _outingRepo.GetOutingList();
            bool running = true;
            while (running)
            {
                Console.Clear();

                Console.WriteLine("Please select which outing type you would like to display the cost of\n" +
                    "1. Golf\n" +
                    "2. Bowling\n" +
                    "3. Amusement Park\n" +
                    "4. Concert\n" +
                    "5. Go to main menu");

                int input = int.Parse(Console.ReadLine());

                double bowling = 0;
                double golf = 0;
                double amusementPark = 0;
                double concert = 0;
                switch (input)
                {
                    case 1:
                        foreach (var outing in outingList)
                        {
                            if (outing.OutingType == OutingType.Golf)
                            {
                                golf += outing.EventCost;
                            }
                        }
                        Console.WriteLine($"Golf cost: {golf}");
                        break;
                    case 2:
                        foreach (var outing in outingList)
                        {
                            if (outing.OutingType == OutingType.Bowling)
                            {
                                bowling += outing.EventCost;
                            }
                        }
                        Console.WriteLine($"Bowling cost: {bowling}");
                        break;
                    case 3:
                        foreach (var outing in outingList)
                        {
                            if (outing.OutingType == OutingType.AmusementPark)
                            {
                                amusementPark += outing.EventCost;
                            }
                        }
                        Console.WriteLine($"Amusement Park cost: {amusementPark}");
                        break;
                    case 4:
                        foreach (var outing in outingList)
                        {
                            if (outing.OutingType == OutingType.Concert)
                            {
                                concert += outing.EventCost;
                            }
                        }
                        Console.WriteLine($"Concert cost: {concert}");
                        break;
                    case 5:
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Response");
                        break;
                }
            }
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
        }

        private void DisplayCombinedCost()
        {
            Console.Clear();

            List<Outing> outingList = _outingRepo.GetOutingList();
            //OutingType typeValue = OutingType.None;
            double actualEventCost = 0;
            foreach (Outing outing in outingList)
            {
                actualEventCost += outing.EventCost;
            }

            Console.WriteLine($"Combined cost for all outings: ${actualEventCost}");

            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();


            //Console.WriteLine((OutingType)Outing.OutingType); USEFUL INFORMATION FOR DISPLAYING ENUMS
        }
    }
}
