var translator = new UniversalTranslator.UniversalTranslator();

int intResult = translator.DoubleInput<int>(2);

decimal decimalResult = translator.DoubleInput<decimal>(3.2m);

double doubleResult = translator.DoubleInput<double>(4.2);

Console.WriteLine($"int result: {intResult}");
Console.WriteLine($"decimal result: {decimalResult}");
Console.WriteLine($"double result: {doubleResult}");