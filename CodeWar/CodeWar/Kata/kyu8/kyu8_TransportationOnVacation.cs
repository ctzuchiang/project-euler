namespace CodeWar.Kata.kyu8
{
    public class kyu8_TransportationOnVacation
    {
        public int RentalCarCost(int d)
        {
            int rental = 40;
            int price = rental * d;
            int discount = 0;

            if (d >= 3)
                discount = d >= 7 ? 50 : 20;

            return price - discount;
        }
    }
}
