namespace CodeWar.Kata.kyu8
{
    public class kyu8_BasicMathematicalOperations
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
                default:
                    throw new System.ArgumentException("Unknown operation!", operation.ToString());
            }
        }
    }
}
