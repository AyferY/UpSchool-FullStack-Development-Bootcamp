using UpStorage.Domain.Enum;

namespace UpStorage.Crawler.GetUser
{
    public class GetUserPreferences
    {
        public int requestedAmount;
        public ProductCrawlType productCrawlType { get; set; }

        public void Greetings()
        {
            Console.WriteLine("*********************************");
            Console.WriteLine("Welcome to UPSTORAGE!");
            Console.WriteLine("*********************************");
        }

        public void ReadInputs()
        {
            Console.WriteLine(Messages.RequestedAmount);
            string requestedAmountAnswer = Console.ReadLine();

            if (int.TryParse(requestedAmountAnswer, out requestedAmount))
            {
                // User entered a number
                Console.WriteLine($"You want to scrape {requestedAmount} products.");
            }
            else if (requestedAmountAnswer.Equals("all", StringComparison.OrdinalIgnoreCase))
            {
                // User entered 'all'
                productCrawlType = ProductCrawlType.All;
                Console.WriteLine("You want to scrape all products.");
            }
            else
            {
                // User entered invalid input
                Console.WriteLine("Invalid input. Assuming scraping all products.");
                productCrawlType = ProductCrawlType.All;
            }


            Console.WriteLine(Messages.ProductCrawlType);
            Console.WriteLine($"A-){ProductCrawlType.All}");
            Console.WriteLine($"B-){ProductCrawlType.OnDiscount}");
            Console.WriteLine($"C-){ProductCrawlType.NonDiscount}");

            Console.Write("Enter your choice (A, B, or C): ");
            string choice = Console.ReadLine();

            switch (choice.ToUpper())
            {
                case "A":
                    Console.WriteLine("You chose to scrape all products.");
                    productCrawlType = ProductCrawlType.All;
                    break;
                case "B":
                    Console.WriteLine("You chose to scrape products on sale.");
                    productCrawlType = ProductCrawlType.OnDiscount;
                    break;
                case "C":
                    Console.WriteLine("You chose to scrape regular price products.");
                    productCrawlType = ProductCrawlType.NonDiscount;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Assuming scraping all products.");
                    break;
            }

            Console.WriteLine("\nThank you for using the UpStorage Program!");

        }
    }
}
