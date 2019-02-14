using System;

namespace PadawansTask6
{
    public static class NumberFinder
    {
        public static int? NextBiggerThan(int number)
        {
            if (number == 0)
            {
                throw new ArgumentException();
            }
            string buf = number.ToString();
            int buffer;
            char[] charr = new char[buf.Length];
            for (int i = 0; i < buf.Length; i++)
            {
                charr[i] = buf[i];
            }
            for (int i = buf.Length - 1; i > 0; i--)
            {
                if (Convert.ToInt32(charr[i]) > Convert.ToInt32(charr[i - 1]))
                {
                    char temp = charr[i - 1];
                    charr[i - 1] = charr[i];
                    charr[i] = temp;
                    break;
                }
            }
            string result = new string(charr);
            buffer = int.Parse(result);
            return buffer;
        }
    }
}
