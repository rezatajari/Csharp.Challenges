using RectangularVault;

var vault = new ValutRoom();

vault.AssignBox(1, 2, 42);
vault.AssignBox(3, 4, 99);

Console.WriteLine(vault.GetOwner(1, 2)); // Output: 42
Console.WriteLine(vault.GetOwner(3, 4)); // Output: 99
