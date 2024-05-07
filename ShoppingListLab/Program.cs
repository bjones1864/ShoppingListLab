using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

//C # Data Structures and Algorithms - book rec

Dictionary <string, decimal> itemsStocked = new Dictionary<string, decimal>() { 
    {"shoes", 60}, {"pants", 75}, {"shirt", 20}, {"watch", 100}, {"socks", 10},
    {"sunglasses", 80}, {"underwear", 15}, {"pajamas", 30}, {"cool hat", 120}, {"lame hat", 40 } };

Dictionary <string, int> menuSystem = new Dictionary<string, int>() {
    {"shoes", 1}, {"pants", 2}, {"shirt", 3}, {"watch", 4}, {"socks", 5},
    {"sunglasses", 6}, {"underwear", 7}, {"pajamas", 8}, {"cool hat", 9}, {"lame hat", 10} };

Dictionary<int, string> menuSystem2 = new Dictionary<int, string>() {
    {1, "shoes"}, {2, "pants"}, {3, "shirt"}, {4, "watch"}, {5, "socks"},
    {6, "sunglasses"}, {7, "underwear"}, {8, "pajamas"}, {9, "cool hat"}, {10, "lame hat"} };

List<string> cart = new List<string>();

Console.WriteLine("Welcome to my online store!\nMENU:");

foreach (KeyValuePair<string, decimal> item in itemsStocked)
{
    Console.WriteLine(String.Format("{0, -3}{1, -12}${2, -5}", menuSystem[item.Key], item.Key, item.Value));
}

decimal biggest = -1;
string bigName = "";
decimal smallest = -1;
string smallName = "";

do
{
    Console.WriteLine("Please enter the name or item number of the item you want to add to your cart, or enter end proceed to checkout.");
    string input = Console.ReadLine().Trim().ToLower();
    int selection;
    
    if(int.TryParse(input, out selection))
    {
        if(menuSystem2.ContainsKey(selection))
        {
            cart.Add(menuSystem2[selection]);
            Console.WriteLine(menuSystem2[selection] + " added to cart");

            if (itemsStocked[menuSystem2[selection]] > biggest || biggest == -1)
            {
                biggest = itemsStocked[menuSystem2[selection]];
                bigName = menuSystem2[selection];
            }
            if(itemsStocked[menuSystem2[selection]] < smallest || smallest == -1 )
            {
                smallest = itemsStocked[menuSystem2[selection]];
                smallName = menuSystem2[selection];
            }

            Console.WriteLine("Would you like to add more items to your cart?  Enter end to proceed to checkout, enter anything else to continue adding items");
            if (Console.ReadLine().Trim().ToLower().Equals("end")) break;
        }
        else
        {
            Console.WriteLine("That is not a valid item choice");
        }
    }
    else if (input.Equals("end"))
    {

        break;
    }
    else if (itemsStocked.ContainsKey(input))
    {
        cart.Add(input);
        Console.WriteLine(input + " added to cart");

        if (itemsStocked[input] > biggest || biggest == -1)
        {
            biggest = itemsStocked[input];
            bigName = input;
        }
        if (itemsStocked[input] < smallest || smallest == -1)
        {
            smallest = itemsStocked[input];
            smallName = input;
        }

        Console.WriteLine("Would you like to add more items to your cart?  Enter end to proceed to checkout, enter anything else to continue adding items");
        if (Console.ReadLine().Trim().ToLower().Equals("end")) break;
    }
    else
    {
        Console.WriteLine("That is not a valid item choice");
    }
    } while (true);

if (cart.Any())
{
    decimal sum = 0;


    Console.WriteLine("Your Cart:");

    foreach (string item in cart)
    {
        Console.WriteLine(String.Format("{0, -12}${1, -3}", item, itemsStocked[item]));
        sum += itemsStocked[item];
    }
    Console.WriteLine($"Your total is ${sum}");

    Console.WriteLine($"Your most expensive item is {bigName} which costs ${biggest}");
    Console.WriteLine($"Your least expensive item is {smallName} which costs ${smallest}");
}
else
{
    Console.WriteLine("Nothing in your cart!");
}