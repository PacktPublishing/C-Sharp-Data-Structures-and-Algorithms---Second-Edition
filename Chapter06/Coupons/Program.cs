// COUPONS
// Chapter 6 (Dictionaries and Sets)
// C# Data Structures and Algorithms, Second Edition

HashSet<int> usedCoupons = [];
do
{
    Console.Write("Enter the number: ");
    string number = Console.ReadLine() ?? string.Empty;
    if (!int.TryParse(number, out int coupon)) { break; }

    if (usedCoupons.Contains(coupon))
    {
        Console.WriteLine("Already used.");
    }
    else
    {
        usedCoupons.Add(coupon);
        Console.WriteLine("Thank you!");
    }
}
while (true);

Console.WriteLine("\nUsed coupons:");
foreach (int coupon in usedCoupons)
{
    Console.WriteLine(coupon);
}
