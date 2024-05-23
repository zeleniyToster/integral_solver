namespace TestIntegralSolver
{
  internal class FileReader
  {
    public static string[] Read(string filePath)
    {
      string[] fileContent;
      using (StreamReader streamReader = new StreamReader(filePath))
      {
        fileContent = streamReader.ReadToEnd().Replace("\r","").Split("\n");
      }

      return fileContent;
    }
  }
}
