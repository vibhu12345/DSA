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
                if (char.IsLetter(c)) yield return input[i];
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
    }
}
