using NCalc;

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
      for (double i = this.lowerBound + this.step; i <= this.upperBound; i = Math.Round(i + this.step, 6))
      {
        sum += (f(i - this.step) + f(i)) / 2;
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
