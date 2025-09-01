int ph;
Console.WriteLine("Please enter the pH level: ");
if (int.TryParse(Console.ReadLine(),out ph)==false||ph<0||ph>14)
    Console.WriteLine("Invalid Input");
else if (ph<7)
    Console.WriteLine("pH is Acidic");
else if (ph>7)
    Console.WriteLine("pH is Alkaline");
else
    Console.WriteLine("pH is neutral");