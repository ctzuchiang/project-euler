using System.Collections;
using System.Collections.Generic;

namespace Solution.Easy._001_050
{
    public class E20_ValidParentheses
    {
        /// <summary>
        ///     Validate Parentheses.
        /// </summary>
        /// <param name="s">Input Parentheses in string.</param>
        /// <returns>
        ///     <c>true</c> if the specified s is valid; otherwise, <c>false</c>.
        /// </returns>
        public bool IsValid(string s)
        {
            if (s.Length%2 != 0)
                return false;

            var pair = new Dictionary<object, char>
            {
                {'(', ')'},
                {'[', ']'},
                {'{', '}'}
            };

            var stack = new Stack();

            foreach (var c in s)
            {
                if (stack.Count == 0)
                {
                    stack.Push(c);
                    continue;
                }

                if (pair.ContainsKey(stack.Peek()) && pair[stack.Peek()] == c)
                {
                    stack.Pop();
                }
                else
                {
                    stack.Push(c);
                }
            }
            return stack.Count == 0;
        }
    }
}