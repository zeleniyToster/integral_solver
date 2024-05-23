using NCalc;
using System.Text.RegularExpressions;

namespace IntegralSolver
{
  /// <summary>
  /// Класс обертка надо NCalc, для обработки мат. функций в строке.
  /// </summary>
  internal class ParserMathFunctions
  {

    private Regex powerFinderRegex = new Regex(@"(\w*\(?\w*.\w*\)\^\d)|\w\^\d*");

    private Regex powerSupportedFunctionRegex = new Regex(@"(Cos|Tan|Sin|Exp|Ln)(\(.*\))(\^\d*)|(\w\^\d*)|(\(.*\)\^\d*)");

    /// <summary>
    /// Функция для конвертации строки математической функций в выражение пригодное для вычислений.
    /// </summary>
    /// <param name="rawExpression">Математическое выражение в виде строки.</param>
    /// <returns>Экземпляр класса Expression со спарсенной функцией.</returns>
    public Expression parseExpression(string rawExpression)
    {
      var powerReplaced = this.powerExpressionFinder(rawExpression);
      var expression = new Expression(powerReplaced);
      return expression;
    }

    /// <summary>
    /// Заменитель проблемной функции степени ^ на Pow().
    /// </summary>
    /// <param name="rawExpression">Математическое выражение в виде строки.</param>
    /// <returns>Строка с заменой ^ -> Pow()</returns>
    private string replacer(string rawExpression)
    {
      var powerExpressionSplit = rawExpression.Split('^');
      if (powerExpressionSplit.Length == 2)
        return this.replace(powerExpressionSplit);

      var replaceNestedSimplePowerFunction = this.simplePowerExpressionFinder(rawExpression);
      var replacePowerSupportedFunctionRegex = this.powerSupportedFunctionExpressionFinder(replaceNestedSimplePowerFunction);

      return replacePowerSupportedFunctionRegex;
    }

    private string powerExpressionFinder(string rawExpression) => this.powerFinderRegex.Replace(rawExpression, match => $"{this.replacer(match.Value)}");

    /// <summary>
    /// Поиск простейшего выражения вида x^n и замена на Pow(x,n).
    /// </summary>
    /// <param name="rawExpression">Математическое выражение в виде строки.</param>
    /// <returns>Измененная строка.</returns>
    private string simplePowerExpressionFinder(string rawExpression) => Regex.Replace(rawExpression, @"\w\^\d*", match => $"{this.replacer(match.Value)}");

    /// <summary>
    /// Поиск поддерживаеммых функций вида Sin(x)^n и замена на Pow(Sin(x),n).
    /// </summary>
    /// <param name="rawExpression">Математическое выражение в виде строки.</param>
    /// <returns>Измененная строка.</returns>
    private string powerSupportedFunctionExpressionFinder(string rawExpression) => this.powerSupportedFunctionRegex.Replace(rawExpression, match => $"{this.replacer(match.Value)}");

    /// <summary>
    /// Шаблон для замены выражения.
    /// </summary>
    /// <param name="powerExpressionSplit">Аргументы для объединения в строку.</param>
    /// <returns>Измененная строка ^ -> Pow().</returns>
    private string replace(string[] powerExpressionSplit) => $"Pow({powerExpressionSplit[0]},{powerExpressionSplit[^1]})";
  }
}
