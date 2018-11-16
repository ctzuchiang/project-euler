namespace CodeWar.Kata.kyu8
{
    public class kyu8_TheFeastOfManyBeasts
    {
        public bool Feast(string beast, string dish)
        {
            return beast[0] == dish[0] && beast[beast.Length - 1] == dish[dish.Length - 1];
        }
    }
}
