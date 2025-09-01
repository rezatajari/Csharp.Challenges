using _02_MonthFinder;

Console.WriteLine("Please enter the month number: ");
int monthNumber=Convert.ToInt32(Console.ReadLine());

Month month=new Month(monthNumber);

Console.WriteLine(month);