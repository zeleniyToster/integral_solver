namespace IntegralSolver
{
  internal class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Вычисляем интеграл из функции (x-1)^2 в области от 1 до 2.");
      var cm = new CalculatingModule(1, 2);
      var res = cm.TrapezoidMethod(cm.MainFunction);
      Console.WriteLine($"Результат вычисления интеграла: {res}");
    }
  }
}
