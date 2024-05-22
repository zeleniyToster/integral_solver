namespace IntegralSolver
{
  internal class Program
  {
    static void Main(string[] args)
    {
      int.TryParse(args[2], out int lowerBound);
      int.TryParse(args[1], out int upperBound);
      string rawExpression = args[0];
      var parserMathFunctions = new ParserMathFunctions();
      var expression = parserMathFunctions.parseExpression(rawExpression);
      var calculatingModule = new CalculatingModule(lowerBound, upperBound, expression);
      var result = calculatingModule.TrapezoidMethod(calculatingModule.MainFunctionAsString);
      Console.WriteLine($"Результат вычисления интеграла: {result}");
    }
  }
}
