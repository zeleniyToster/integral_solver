using Antlr4.Runtime.Atn;
using NCalc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IntegralSolver
{
  internal class ParserMathFunctions
  {

    public Expression parseExpression(string arg)
    {
      var powerReplaced = powerReplacer(arg);
      var expression = new Expression(powerReplaced);
      return expression;
    }

    private MatchCollection powerFinder(string arg)
    {
      var regex = new Regex(@"(\w*\(?\w*.\w*\)\^\d)|\w\^\d*");
      MatchCollection matches = regex.Matches(arg);
      
      return matches;
    }

    private string powerReplacer(string arg)
    {
      var matches = powerFinder(arg);
      if (matches.Count == 0)
        return arg;

      foreach (Match match in matches)
      {
        Console.WriteLine(match.Value);
        var powerExpressionSplit = match.Value.Split('^');
        var newPowerExpression = $"Pow({powerExpressionSplit[0]}, {powerExpressionSplit[^1]})";
      }
      
      return string.Empty;
    }

    private string replace(string arg)
    {

      return arg;
    }

  }
}
