using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestIntegralSolver
{
  internal class FileReader
  {
    public string filePath {  get; private set; }

    public FileReader(string filePath)
    {
      this.filePath = filePath;
    }

    public string[] Read()
    {
      string[] fileContent;
      using (StreamReader streamReader = new StreamReader(this.filePath))
      {
        fileContent = streamReader.ReadToEnd().Split("\n");
      }

      return fileContent;
    }
  }
}
