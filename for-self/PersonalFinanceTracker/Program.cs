
using PersonalFinanceTracker;

var r1 = new Transactions(1, 100, "Grocery Shopping", DateTime.Now);
var r2 = new Transactions(2, 50, "Gas", DateTime.Now);

var txs = new List<Transactions>();
txs.Add(r1); 
txs.Add(r2);