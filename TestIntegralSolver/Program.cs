using System.Diagnostics;

namespace TestIntegralSolver
{
  internal class Program
  {
    static void Main(string[] args)
    {
      var filePath = args[0];
      var fileContent = FileReader.Read(filePath);
      var procesesOutput = new List<string?>();
      var process = new Process();
      Console.WriteLine(6.394.Equals(6.394));
      process.StartInfo.UseShellExecute = false;
      process.StartInfo.RedirectStandardOutput = true;
      process.StartInfo.FileName = @"H:\Projects\integral_solver\IntegralSolver\bin\Debug\net6.0\IntegralSolver.exe";
      foreach ( var item in fileContent )
      {
        process.StartInfo.Arguments = item;
        process.Start();
        procesesOutput.Add(process.StandardOutput.ReadLine().Replace(",", "."));
        process.WaitForExit();
      }
      testCasesAssert(fileContent, procesesOutput);
    }
    
    static void testCasesAssert(string[] fileContent, List<string?> procesesOutput)
    {
      if (fileContent.Length != procesesOutput.Count)
        throw new Exception("Количество тест-кейсов из файла не совпадает с количество результатов их решения.");

      for (int i = 0; i < fileContent.Length; i++)
      {
        var splitedFileContent = fileContent[i].Split(' ');
        if (!procesesOutput[i].Equals(splitedFileContent[^1]))
        {
          Console.WriteLine("Ответы не совпадают, более подробная информация ниже:");
          Console.WriteLine($"Функция - {splitedFileContent[0]}, нижняя граница - {splitedFileContent[1]}, верхняя граница - {splitedFileContent[2]}");
          Console.WriteLine($"Ответ из файла с решением: {splitedFileContent[^1]}, Ответ из программы - {procesesOutput[i]}");
          break;
        }
        Console.WriteLine($"Функция - {splitedFileContent[0]}, нижняя граница - {splitedFileContent[1]}, верхняя граница - {splitedFileContent[2]}");
        Console.WriteLine($"Ответ из файла с решением: {splitedFileContent[^1]}, Ответ из программы - {procesesOutput[i]}");
      }
    }
  }
}
