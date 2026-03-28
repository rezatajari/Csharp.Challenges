using TicketPriority;

var ticket = new Ticket();

ticket.PropertyChanged += (sender, e) =>
{
    Console.WriteLine($"{e.PropertyName} changed");
};

ticket.Title = "Server is down";
