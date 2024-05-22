using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegralSolver
{
  /// <summary>
  /// Класс для вычислений.
  /// </summary>
  internal class CalculatingModule
  {
    /// <summary>
    /// Шаг интегрирования.
    /// </summary>
    private double step = 0.1;

    /// <summary>
    /// Нижняя граница интеграла.
    /// </summary>
    public double LowerBound { get; private set; }

    /// <summary>
    /// Верхняя граница интеграла.
    /// </summary>
    public double UpperBound { get; private set; }

    public delegate double MathFunctionDelegate(double x);


    public double MainFunction(double x)
    {
      var func = Math.Pow(x - 1, 2);
      return func;
    }

    /// <summary>
    /// Функция для вычисления интегралов методом трапеций.
    /// </summary>
    /// <param name="f">Поддерживаемая математическая функция.</param>
    /// <returns></returns>
    public double TrapezoidMethod(MathFunctionDelegate f)
    {
      // Закоментированные строки необходимы для отладки программы
      double asd = 0;
      double res, sum = 0;
      var reslist = new List<double>();
      var ilist = new List<double>();
      //var xi = this.CalculatingXi();
      for (double i = this.LowerBound + this.step; i <= this.UpperBound; )
      {
        ilist.Add(i);
        sum += (f(i - this.step) + f(i)) / 2;
        reslist.Add(sum);
        asd = i;
        i = Math.Round(i + this.step, 6);
      }
      //
      //for (int i = 1; i < xi.GetLength(0); i++)
      //{
      //  sum += (f(xi[i - 1]) + f(xi[i])) / 2;
      //  reslist.Add(sum);
      //}
        

      res = Math.Round(sum * this.step, 6);
      return res;
    }
    
    /// <summary>
    /// Метод необходим для отладки работы программы.
    /// </summary>
    /// <returns></returns>
    public double[] CalculatingXi()
    {
      int n = 0, m = 0;
      double[] xi;
      for (double i = this.LowerBound; Math.Round(i, 10) <= this.UpperBound; i += step)
        n++;
      Console.WriteLine($"n = {n}");
      xi = new double[n];
      for (double x = this.LowerBound; Math.Round(x, 10) <= this.UpperBound; x += step)
      {
        xi[m] = Math.Round(x, 10);
        m++;
      }
      Console.WriteLine($"xi =\n{xi.ToString}");
      return xi;
    }

    /// <summary>
    /// Конструктор класса.
    /// </summary>
    /// <param name="LowerBound">Нижняя граница интеграла.</param>
    /// <param name="UpperBound">Верхняя граница интеграла.</param>
    public CalculatingModule(double LowerBound, double UpperBound)
    {
      this.LowerBound = LowerBound;
      this.UpperBound = UpperBound;
    }
  }
}
