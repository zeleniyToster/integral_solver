namespace TestIntegralSolver
{
  internal class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Введите путь до файла:");

      var fileReader = new FileReader(args[0]);
      var fileContent = fileReader.Read();

    }
  }
}
