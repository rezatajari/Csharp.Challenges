using _06_ValueFrequencyAnalyzer;

TestArray arr=new TestArray();
Console.WriteLine("Number of elements: {0}",arr.NumberOfElements.ToString());
Console.WriteLine("Valid entries: {0}", arr.ValidEntries());
Console.WriteLine("Invalid entries: {0}",arr.NumberOfElements - arr.ValidEntries());

int[] entriesCount=arr.CountEntries();
for (int i = 0; i < entriesCount.Length; i++)
{
        Console.WriteLine("Number of occurances for value of {0} is {1} ", i, entriesCount[i]);
}