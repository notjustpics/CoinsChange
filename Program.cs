using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace CoinsC
{
    class Program
    {
        static void Main(string[] args)
        {
            string response;
            int amount, count, i;

            Console.Write("What currency do you want to use? (B = British Pound / U = US Dollar) ");
            response = Console.ReadLine();
            if (response.ToUpper() == "B")
            {
                Console.WriteLine("Please select an item: ");
                Console.WriteLine("1) Lunchbar");
                Console.WriteLine("2) KitKat");
                Console.WriteLine("3) Exit");
                Console.Write("\r\nSelect an option: ");

                int[] coins = { 1, 2, 5, 10, 20, 50 }; //cent
                decimal itemRealCost = 0;
                decimal itemInputCost = 0;
                string value = string.Empty;

                string productChosen = Console.ReadLine();
                if(productChosen == "1") { value = "3.50"; }
                else if(productChosen == "2") { value = "5.30"; }
                else { productChosen = "0"; }

                NumberStyles style;
                CultureInfo culture;

                style = NumberStyles.AllowDecimalPoint | NumberStyles.AllowCurrencySymbol;
                culture = CultureInfo.CreateSpecificCulture("en-GB");
                if (Decimal.TryParse(value, style, culture, out itemRealCost))
                {
                    Console.Write("Item cost: " + itemRealCost);
                    Console.ReadLine();
                }

                //ask user input cost
                Console.Write("Please enter amount: ");
                value = Console.ReadLine();
                if (Decimal.TryParse(value, style, culture, out itemInputCost))
                {
                    Console.Write("Item input: " + itemInputCost);
                    Console.ReadLine();
                }


                decimal d = itemInputCost - itemRealCost;

                if(d < 0)
                {
                    Console.Write("Amount of " + "\u00A3" + d.ToString() + " short.");
                    Console.ReadLine();
                    //Environment.Exit(0);
                    return;
                }

                string inputCostString = d.ToString();
                String[] strlist = inputCostString.Split(",");
                inputCostString = strlist[0].ToString() + strlist[1].ToString();

                amount = Int32.Parse(inputCostString);

                Console.WriteLine(inputCostString);
                Console.WriteLine("==========================");
                for (i = 0; i < coins.Length; i++)
                {
                    amount = Int32.Parse(inputCostString);
                    count = amount / coins[i];
                    if (count != 0)
                        Console.WriteLine("Count of {0} cent(s) :{1}", coins[i], count);
                    amount %= coins[i];
                }

                Console.ReadLine();
            }
            else if (response.ToUpper() == "U")
            {
                Console.WriteLine("Please select an item: ");
                Console.WriteLine("1) Lunchbar");
                Console.WriteLine("2) KitKat");
                Console.WriteLine("3) Exit");
                Console.Write("\r\nSelect an option: ");

                int[] coins = { 1, 5, 10, 25 }; //cent
                decimal itemRealCost = 0;
                decimal itemInputCost = 0;
                string value = string.Empty;

                string productChosen = Console.ReadLine();
                if (productChosen == "1") { value = "3.75"; }
                else if (productChosen == "2") { value = "7"; }
                else { value = "0"; }

                NumberStyles style;
                CultureInfo culture;

                style = NumberStyles.AllowDecimalPoint | NumberStyles.AllowCurrencySymbol;
                culture = CultureInfo.CreateSpecificCulture("en-GB");
                if (Decimal.TryParse(value, style, culture, out itemRealCost))
                {
                    Console.Write("Item cost: " + itemRealCost);
                    Console.ReadLine();
                }

                //ask user input cost
                Console.Write("Please enter amount: ");
                value = Console.ReadLine();
                if (Decimal.TryParse(value, style, culture, out itemInputCost))
                {
                    Console.Write("Item input: " + itemInputCost);
                    Console.ReadLine();
                }


                decimal d = itemInputCost - itemRealCost;

                if (d < 0)
                {
                    Console.Write("Amount of $" + d.ToString() + " short.");
                    Console.ReadLine();
                    //Environment.Exit(0);
                    return;
                }

                string inputCostString = d.ToString();
                if (inputCostString.Length > 1)
                {
                    String[] strlist = inputCostString.Split(",");
                    inputCostString = strlist[0].ToString() + strlist[1].ToString();
                }
                else if(inputCostString.Length == 1)
                {
                    inputCostString = inputCostString + "00";
                }

                amount = Int32.Parse(inputCostString);

                Console.WriteLine(inputCostString);
                Console.WriteLine("==========================");
                for (i = 0; i < coins.Length; i++)
                {
                    amount = Int32.Parse(inputCostString);
                    count = amount / coins[i];
                    if (count != 0)
                        Console.WriteLine("Count of {0} cent(s) :{1}", coins[i], count);
                    amount %= coins[i];
                }

                Console.ReadLine();
            }

            //else
            //{
            //    Console.Write("Only British Pound & US Dollar supported by this vending machine. :-(");
            //    Console.ReadLine();
            //    Environment.Exit(0);
            //}
        }
    }
}
