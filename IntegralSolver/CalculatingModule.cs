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
    private const double step = 0.1;

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


    public double TrapezoidMethod(MathFunctionDelegate f)
    {
      double res, sum = 0;
      for (double i = this.LowerBound + step; i < this.UpperBound; i += step)
        sum += (f(i - step) + f(i)) / 2;

      res = sum * step;
      return res;
    }


    public CalculatingModule(double LowerBound, double UpperBound)
    {
      this.LowerBound = LowerBound;
      this.UpperBound = UpperBound;
    }
  }
}
