using System.Collections.Generic;
using System.Linq;

namespace CodeWar.Kata
{
    public class Kata_DeadAntCount
    {
        public static int DeadAntCount(string ants)
        {
            if (string.IsNullOrEmpty(ants))
                return 0;
            var deadAnts = RemoveLivingAnts(ants);

            var antBodies = new Dictionary<char,int>()
            {
                {'a',0},
                {'n',0},
                {'t',0}
            };

            foreach (var body in deadAnts)
            {
                switch (body)
                {
                    case 'a':
                        antBodies['a']++;
                        break;
                    case 'n':
                        antBodies['n']++;
                        break;
                    case 't':
                        antBodies['t']++;
                        break;
                }
            }

            return antBodies.Values.Max();
        }

        private static string RemoveLivingAnts(string ants)
        {
            return ants.Replace("ant", "");
        }
    }
}
