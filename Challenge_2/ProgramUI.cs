using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_2
{
    public class ProgramUI
    {
        ClaimRepository _claimsRepo = new ClaimRepository();
        Queue<string> claims = new Queue<string>();

        public void Run()
        {
            RunMenu();
        }

        private void RunMenu()
        {

            EnterNewClaim();

            bool running = true;
            while (running)
            {
                Console.WriteLine("Welcome to the main menu. Please select an action\n" +
                    "1. See all claims\n" +
                    "2. Take care of next claim\n" +
                    "3. Enter a new claim\n" +
                    "4. Exit");

                int input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        SeeAllClaims();
                        break;
                    case 2:
                        HandleNextClaim();
                        break;
                    case 3:
                        EnterNewClaim();
                        break;
                    case 4:
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid response");
                        break;
                }
            }
        }

        private void SeeAllClaims()
        {
            Queue<Claim> claimQueue = _claimsRepo.GetClaimList();
            foreach (Claim claims in claimQueue)//<--queue)
            {
                Console.WriteLine($"Claim ID: {claims.ClaimID}\n" +
                    $"Type: {claims.ClaimType}\n" +
                    $"Description: {claims.Description}\n" +
                    $"Amount: {claims.ClaimAmount}\n" +
                    $"Date of Accident: {claims.DateOfIncident}\n" +
                    $"Date of Claim: {claims.DateOfClaim}\n" +
                    $"IsValid: {claims.IsValid}");
            }

            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
        }

        private void EnterNewClaim()
        {

            Console.WriteLine("Welcome to the Komodo Claims Department.\n" +
                "What is the claim type? (car, home, or theft)");
            string claimType = Console.ReadLine();

            Console.WriteLine("Please enter a claim description");
            string claimDescription = Console.ReadLine();

            Console.WriteLine("What is the claim amount?");
            double claimAmount = double.Parse(Console.ReadLine());

            Console.WriteLine("When did the incident take place? (YYYY/MM/DD)");
            DateTime accidentDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("What date are you making this claim? (YYYY/MM/DD)");
            DateTime claimDate = DateTime.Parse(Console.ReadLine());

            if (claimDate.Month < accidentDate.Month && claimDate.Year >= accidentDate.Year)
            {
                bool isValid = false;
            }

            else
            {
                bool isValid = true;
            }

            //do i have to assign claimid or is it automatically assigned in the queue?
            Claim newClaim = new Claim(newClaim.claimID, claimType, claimDescription, claimAmount, accidentDate, claimDate, isValid);

            //add info to queue
            _claimsRepo.AddClaimToQueue(newClaim);
        }

        private void HandleNextClaim()
        {

        }
    }
}
