namespace CodeWar.Kata._8kyu
{
    public class Kata_TheFeastOfManyBeasts
    {
        public bool Feast(string beast, string dish)
        {
            return beast[0] == dish[0] && beast[beast.Length - 1] == dish[dish.Length - 1];
        }
    }
}
