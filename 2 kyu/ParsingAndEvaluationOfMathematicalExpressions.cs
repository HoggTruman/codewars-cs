// https://www.codewars.com/kata/564d9ebde30917684f000048

namespace ParsingAndEvaluationOfMathematicalExpressions;

using System;
using System.Collections.Generic;
using System.Linq;

public class Evaluate
{
    private static readonly Dictionary<char, double> Digits = new()
    {
        {'0', 0 },
        {'1', 1 },
        {'2', 2 },
        {'3', 3 },
        {'4', 4 },
        {'5', 5 },
        {'6', 6 },
        {'7', 7 },
        {'8', 8 },
        {'9', 9 }
    };

    private static readonly Dictionary<char, Func<double, double, double>> Operators = new()
    {
        { '+', (a, b) => a + b },
        { '-', (a, b) => a - b },
        { '*', (a, b) => a * b },
        { '/', (a, b) => b == 0? double.NaN: a / b },
        { '&', Math.Pow }
    };

    private static readonly Dictionary<string, Func<double, double>> Functions = new()
    {
        { "log", Math.Log10 },
        { "ln", Math.Log },
        { "exp", Math.Exp },
        { "sqrt", Math.Sqrt },
        { "abs", Math.Abs },
        { "sin", Math.Sin },
        { "cos", Math.Cos },
        { "tan", Math.Tan },
        { "asin", Math.Asin },
        { "acos", Math.Acos },
        { "atan", Math.Atan },
        { "sinh", Math.Sinh },
        { "cosh", Math.Cosh },
        { "tanh", Math.Tanh }
    };

    public string eval(string expression)
    {
        if (!HasValidWhiteSpace(expression))
        {
            return "ERROR: Invalid Whitespace";
        }

        double result = EvaluateExpression(expression.Replace(" ", ""));
        return ParseDoubleToString(result);
    }

    internal static double EvaluateExpression(string expression)
    {
        List<string> subExpressions = [];
        List<char> operators = [];

        while(expression.Length > 0)
        {
            string? subExpression = ExtractSubExpression(expression);
            if (subExpression == null)
            {
                return double.NaN;
            }

            expression = subExpression.Length < expression.Length? expression[subExpression.Length..]: "";            
            subExpressions.Add(subExpression);

            if (expression.Length > 0)
            {
                char? op = ExtractOperator(expression);
                if (op == null)
                {
                    return double.NaN;
                }

                expression = expression.Length > 1? expression[1..]: "";
                operators.Add(op.Value);
            }
        }

        if (subExpressions.Count - operators.Count != 1)
        {
            return double.NaN;
        }

        List<bool> hasUnaryMinus = subExpressions.Select(HasUnaryMinus).ToList();
        subExpressions = subExpressions.Select(x => x.TrimStart('-')).ToList();
        List<double> operands = subExpressions.Select(EvaluateSubExpression).ToList();

        if (operands.Any(double.IsNaN))
        {
            return double.NaN;
        }

        return ApplyOperators(operands, operators, hasUnaryMinus);        
    }

    private static double ApplyOperators(List<double> operands, List<char> operators, List<bool> hasUnaryMinus)
    {
        for (int i = operators.Count - 1; i >= 0; --i)
        {
            if (operators[i] == '&')
            {
                double rhs = hasUnaryMinus[i + 1]? -operands[i + 1]: operands[i + 1];
                operands[i] = Operators['&'](operands[i], rhs);
                operands.RemoveAt(i + 1);
                hasUnaryMinus.RemoveAt(i + 1);
                operators.RemoveAt(i);
            }
        }

        operands = operands.Select((x, i) => hasUnaryMinus[i]? -x: x).ToList();
        
        foreach (string targets in new[] {"*/", "+-"})
        {
            int i = 0;
            while (i < operators.Count)
            {
                if (targets.Contains(operators[i])) 
                {
                    operands[i] = Operators[operators[i]](operands[i], operands[i + 1]);
                    operands.RemoveAt(i + 1);
                    operators.RemoveAt(i);
                }
                else
                {
                    ++i;
                }            
            }
        }

        return operands[0];
    }

    internal static string? ExtractSubExpression(string expression)
    {
        // functions calls and brackets extract everything up to and including closing bracket
        // numbers extract everything before +-/*& but keeps extracting if +- follows an e

        int firstNonMinusIndex = expression.ToList().FindIndex(x => x != '-');

        if (firstNonMinusIndex == -1)
        {
            return null;
        }

        if (expression[firstNonMinusIndex] == '(')
        {
            int closingIndex = FindClosingBracketIndex(expression, firstNonMinusIndex);
            return closingIndex > -1? expression[Range.EndAt(closingIndex + 1)]: null;
        }

        if (char.IsLetter(expression[firstNonMinusIndex]))
        {
            int openingIndex = expression.IndexOf('(', firstNonMinusIndex);
            int closingIndex = FindClosingBracketIndex(expression, openingIndex);
            return closingIndex > -1? expression[Range.EndAt(closingIndex + 1)]: null;
        }

        if (char.IsDigit(expression[firstNonMinusIndex]))
        {
            for (int i = firstNonMinusIndex + 1; i < expression.Length; ++i)
            {
                if (Operators.ContainsKey(expression[i]))
                {
                    if ((expression[i] == '+' || expression[i] == '-') &&
                        expression[i - 1] == 'e')
                    {
                        continue;
                    }

                    return expression[..i];
                }
            }

            return expression;             
        }

        return null;
    }    

    internal static char? ExtractOperator(string expression)
    {
        return Operators.ContainsKey(expression[0])? expression[0]: null;
    }

    internal static double EvaluateSubExpression(string expression)
    {
        // leading minus are stripped before the expression is passed in
        if (expression[0] == '(')
        {
            return EvaluateExpression(expression[1..^1]);
        }
        else if (char.IsLetter(expression[0]))
        {
            int openingIndex = expression.IndexOf('(');
            string fname = expression[..openingIndex].ToLower();
            if (Functions.TryGetValue(fname, out Func<double, double>? f))
            {
                string bracketContents = expression[(openingIndex + 1)..^1];
                return f(EvaluateExpression(bracketContents));
            }
        }
        else if (char.IsDigit(expression[0])) // no leading dots
        {
            return ParseNumberString(expression);
        }

        return double.NaN;
    }

    private static double ParseNumberString(string number)
    {
        // unary minus considered separately, all numbers passed in are non-negative 
        if (!char.IsDigit(number[0]))
        {
            return double.NaN;
        }

        int dotIndex = number.IndexOf('.');
        int eIndex = number.IndexOf('e');

        int wholeIndexBound = dotIndex != -1? 
            dotIndex: 
            eIndex != -1? eIndex: number.Length;


        double result = ParseIntegerString(number[..wholeIndexBound]); 

        if (dotIndex != -1)
        {
            int decimalIndexBound = eIndex == -1? number.Length: eIndex;
            if (decimalIndexBound == dotIndex + 1)
            {
                return double.NaN;
            }

            string decimalString = number[new Range(dotIndex + 1, decimalIndexBound)];
            result += ParseIntegerString(decimalString) / Math.Pow(10, decimalString.Length);
        }

        if (eIndex != -1)
        {            
            string exponentString;
            if (number.Length - eIndex >= 1 && char.IsDigit(number[eIndex + 1]))
            {
                exponentString = number[Range.StartAt(eIndex + 1)];
            }
            else if (number.Length - eIndex >= 2 &&
                (number[eIndex + 1] == '+' || number[eIndex + 1] == '-'))
            {
                exponentString = number[Range.StartAt(eIndex + 2)];
            }
            else
            {
                return double.NaN;
            }

            int sign = number[eIndex + 1] == '-'? -1: 1;
            double exponent = sign * ParseIntegerString(exponentString);
            result *= Math.Pow(10, exponent);
        }

        return result;
    }

    internal static double ParseIntegerString(string integer)
    {
        double result = 0;
        for (int i = 1; i <= integer.Length; ++i)
        {
            if (!Digits.TryGetValue(integer[^i], out double digit))
            {
                return double.NaN;
            }

            result += digit * Math.Pow(10, i - 1);
        }

        return result;
    }

    private static string ParseDoubleToString(double number)
    {
        if (double.IsNaN(number))
        {
            return "ERROR";
        }

        double rounded = Math.Round(number, 10);
        return $"{rounded}";
    }

    private static bool HasValidWhiteSpace(string expression)
    {
        var parts = expression.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < parts.Length - 1; ++i)
        {
            if (char.IsLetter(parts[i][^1]) && char.IsLetter(parts[i + 1][0]))
            {
                return false;
            }
        }

        return true;
    }

    internal static int FindClosingBracketIndex(string expression, int openIndex)
    {
        int openCount = 1;
        for (int i = openIndex + 1; i < expression.Length; ++i)
        {
            if (expression[i] == ')')
            {
                if (openCount == 1)
                {
                    return i;
                }

                --openCount;
            }
            else if (expression[i] == '(')
            {
                ++openCount;
            }                
        }

        return -1;
    }

    internal static bool HasUnaryMinus(string expression)
    {
        int firstNonMinusIndex = expression.ToList().FindIndex(x => x != '-');
        return firstNonMinusIndex % 2 != 0;
    }
}
