using System.Diagnostics;
using System.IO;

namespace TestIntegralSolver
{
  internal class Program
  {
    static void Main(string[] args)
    {
      var testCaseFilePath = args[0];
      var integralSolverFileName = "IntegralSolver.exe";
      var fileContent = FileReader.Read(testCaseFilePath);
      var procesesOutput = new List<string?>();
      var process = new Process();
      Console.WriteLine(6.394.Equals(6.394));
      process.StartInfo.UseShellExecute = false;
      process.StartInfo.RedirectStandardOutput = true;
      process.StartInfo.FileName = filePath(integralSolverFileName);
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
          Console.WriteLine($"Функция - {splitedFileContent[0]}, верхняя граница - {splitedFileContent[1]}, нижняя граница - {splitedFileContent[2]}");
          Console.WriteLine($"Ответ из файла с решением: {splitedFileContent[^1]}, Ответ из программы - {procesesOutput[i]}");
          break;
        }
        Console.WriteLine($"Функция - {splitedFileContent[0]}, верхняя граница - {splitedFileContent[1]}, нижняя граница - {splitedFileContent[2]}");
        Console.WriteLine($"Ответ из файла с решением: {splitedFileContent[^1]}, Ответ из программы - {procesesOutput[i]}");
      }
    }

    static string filePath(string fileName) => Path.GetFullPath(fileName);

  }
}
