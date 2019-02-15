using System;

namespace PadawansTask6
{
    public static class NumberFinder
    {
        public static int? NextBiggerThan(int number)
        {
            if (number <= 0 | number == int.MinValue)
            {
                throw new ArgumentException();
            }
            if (number == int.MaxValue)
            {
                return null;
            }
            int buffer;
            char[] charr = number.ToString().ToCharArray();

            if (charr.Length == 1)
            {
                return null;
            }
            // if 111111111111111
            int counter = 0;
            for (int i = 0; i < charr.Length - 1; i++)
            {
                if (char.GetNumericValue(charr[i]) == char.GetNumericValue(charr[i + 1]))
                {
                    if (++counter == charr.Length - 1)
                    {
                        return null;
                    }
                }
            }
            // if 2000
            if (char.GetNumericValue(charr[0]) > char.GetNumericValue(charr[1]))
            {
                int counter3 = 0;
                for (int i = 1; i < charr.Length - 1; i++)
                {
                    if (char.GetNumericValue(charr[1]) == char.GetNumericValue(charr[i + 1]))
                    {
                        if (++counter3 == charr.Length - 2)
                        {
                            return null;
                        }
                    }
                }
            }
            // if 10
            int counter2 = 0;
            for (int i = 0; i < charr.Length - 1; i++)
            {
                if (char.GetNumericValue(charr[i]) > char.GetNumericValue(charr[i + 1]))
                {
                    if (++counter2 == charr.Length - 1)
                    {
                        return null;
                    }
                }
            }
            int targetIndex = 0;
            for (int i = charr.Length - 1; i > 0; i--)
            {
                if (char.GetNumericValue(charr[i]) > char.GetNumericValue(charr[i - 1]))
                {
                    char temp = charr[i - 1];
                    charr[i - 1] = charr[i];
                    charr[i] = temp;
                    targetIndex = i;
                    break;
                }
            }
            double[] array = new double[charr.Length - targetIndex];
            // sorting the tail of a number
            if (targetIndex > 0)
            {
                for (int i = 0, j = targetIndex; i < array.Length; i++, j++)
                {
                    array[i] = char.GetNumericValue(charr[j]);
                }
                for (int i = 0; i < array.Length - 1; i++)
                {
                    int minIdx = i;
                    for (int j = i + 1; j < array.Length; j++)
                    {
                        if (array[i] > array[j])
                        {
                            minIdx = j;
                        }
                    }
                    double temp = array[i];
                    array[i] = array[minIdx];
                    array[minIdx] = temp;
                }
                char[] res = new char[array.Length];
                for (int i = 0, j = targetIndex; i < array.Length; i++, j++)
                {
                    charr[j] = array[i].ToString()[0];
                }
            }
            string result = new string(charr);
            try
            {
                buffer = int.Parse(result);
            }
            catch (OverflowException)
            {
                return null;
            }
            return buffer;
        }
    }
}
