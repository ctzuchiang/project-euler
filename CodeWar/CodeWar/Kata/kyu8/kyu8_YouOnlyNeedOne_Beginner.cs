using System;

namespace CodeWar.Kata.kyu8
{
    public class kyu8_YouOnlyNeedOne_Beginner
    {
        public bool Check(object[] a, object x)
        {
            return Array.Exists(a, o => o.Equals(x));
        }
    }
}
