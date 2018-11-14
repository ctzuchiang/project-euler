namespace CodeWar.Kata._8kyu
{
    public class Kata_BasicMathematicalOperations
    {
        public double basicOp(char operation, double value1, double value2)
        {
            switch (operation)
            {
                case '+':
                    return value1 + value2;
                case '-':
                    return value1 - value2;
                case '*':
                    return value1 * value2;
                case '/':
                    return value1 / value2;
            }

            return 0;
        }
    }
}
