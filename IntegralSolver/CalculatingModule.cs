using NCalc;
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
    /// Подынтегральная функция.
    /// </summary>
    public Expression expression {  get; private set; }

    /// <summary>
    /// Шаг интегрирования.
    /// </summary>
    private double step = 0.1;

    /// <summary>
    /// Нижняя граница интеграла.
    /// </summary>
    public double lowerBound { get; private set; }

    /// <summary>
    /// Верхняя граница интеграла.
    /// </summary>
    public double upperBound { get; private set; }

    public delegate double MathFunctionDelegate(double x);

    public double MainFunctionAsString(double x)
    {
      expression.Parameters["x"] = x;
      var result = Convert.ToDouble(expression.Evaluate());
      return result;
    }

    /// <summary>
    /// Функция для вычисления интегралов методом трапеций.
    /// </summary>
    /// <param name="f">Поддерживаемая математическая функция.</param>
    /// <returns></returns>
    public double TrapezoidMethod(MathFunctionDelegate f)
    {
      double res, sum = 0;
      var reslist = new List<double>(); // для отладки
      var ilist = new List<double>();  // для отладки
      for (double i = this.lowerBound + this.step; i <= this.upperBound; )
      {
        ilist.Add(i);  // для отладки
        sum += (f(i - this.step) + f(i)) / 2;
        reslist.Add(sum);  // для отладки
        i = Math.Round(i + this.step, 6);
      }
        
      res = Math.Round(sum * this.step, 6);
      return res;
    }

    /// <summary>
    /// Конструктор класса.
    /// </summary>
    /// <param name="LowerBound">Нижняя граница интеграла.</param>
    /// <param name="UpperBound">Верхняя граница интеграла.</param>
    public CalculatingModule(double LowerBound, double UpperBound, Expression expression)
    {
      this.lowerBound = LowerBound;
      this.upperBound = UpperBound;
      this.expression = expression;
    }
  }
}
