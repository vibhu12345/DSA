using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA
{
    public static class StackExamples
    {
        public static IEnumerable<char> GetPostFix(string input)
        {
            Stack<char> stack = new Stack<char>();
            Dictionary<char, int> operators = new Dictionary<char, int>
        {
            { '+', 1 },  {'-', 1 }, {'*', 2 },  {'/', 2 }
        };
            for (int i = 0; i < input.Length; i++)
            {
                var c = input[i];
                if (char.IsLetterOrDigit(c)) yield return input[i];
                if (c == ')')
                {
                    while (stack.Count > 0)
                    {
                        var top = stack.Pop();
                        if (top != '(') yield return top;
                        else break;
                    }
                }
                if (operators.TryGetValue(c, out var precedence))
                {
                    while (stack.Count > 0)
                    {
                        var top = stack.Peek();
                        operators.TryGetValue(top, out var precedence1);
                        if (top != '(' || precedence1 > precedence) yield return stack.Pop();
                        else break;
                    }
                    stack.Push(c);
                }
                if (c == '(') stack.Push(c);
            }
            while (stack.Count > 0)
            {
                yield return stack.Pop();
            }
        }

        public static double GetInFixResult(string input)
        {
             Stack<char> stack = new Stack<char>();
            Stack<double> operands = new Stack<double>();
            Dictionary<char, int> operators = new Dictionary<char, int>
        {
            { '+', 1 },  {'-', 1 }, {'*', 2 },  {'/', 2 }
        };
            for (int i = 0; i < input.Length; i++)
            {
                var c = input[i];
                if (char.IsDigit(c)) operands.Push(char.GetNumericValue(input[i]));
                if (c == ')')
                {
                    while (stack.Count > 0)
                    {
                        var top = stack.Pop();
                        if (top != '(') Apply(top,operands);
                        else break;
                    }
                }
                if (operators.TryGetValue(c, out var precedence))
                {
                    while (stack.Count > 0)
                    {
                        var top = stack.Peek();
                        operators.TryGetValue(top, out var precedence1);
                        if (top != '(' || precedence1 > precedence) Apply(stack.Pop(),operands);
                        else break;
                    }
                    stack.Push(c);
                }
                if (c == '(') stack.Push(c);
            }
            while (stack.Count>0)
            {
                Apply(stack.Pop(),operands);
            }
            return operands.Count>0 ? operands.Pop() : 0;
        }

        private static void Apply(char top, Stack<double> operands)
        {
            var b= operands.Pop();
            var a= operands.Pop();
            var result = top switch
            {
                '+' => a + b,
                '-' => a - b,
                '*' => a * b,
                '/' => a / b,
                _ => 0
            };
            operands.Push(result);
        }
    }
}
