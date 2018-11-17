namespace CodeWar.Kata.kyu8
{
    public class kyu8_SimpleFun1_SeatsInTheater
    {
        public int SeatsInTheater(int nCols, int nRows, int col, int row)
        {
            var r = nRows - row;
            var c = nCols - col + 1;
            return r * c;
        }
    }
}
