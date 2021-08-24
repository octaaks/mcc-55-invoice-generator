using System;

namespace InvoiceGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = 10983;
            Console.WriteLine(GenerateInvoice(counter));
        }

        public static string GenerateInvoice(int counter)
        {
            counter++;
            DateTime today = DateTime.Today;

            string invoiceDay = today.ToString("ddd").Substring(0, 2).ToUpper();
            string invoiceDate = today.ToString("dd");
            string invoiceYearMonth = today.ToString("yyyyMM");
            string invoiceYearShort = today.ToString("yyyy").Substring(2, 2);

            string romanDate = toRoman(int.Parse(invoiceDate));
            string romanYear = toRoman(int.Parse(invoiceYearShort));

            return $"INV/{invoiceYearMonth}/{invoiceDay}/{romanDate}/{romanYear}/{counter}";
        }

        private static String toRoman(int num)
        {
            String[] romanCharacters = { "M", "CM", "D", "C", "XC", "L", "X", "IX", "V", "I" };
            int[] romanValues = { 1000, 900, 500, 100, 90, 50, 10, 9, 5, 1 };
            String result = "";

            for (int i = 0; i < romanValues.Length; i++)
            {
                int numberInPlace = num / romanValues[i];
                if (numberInPlace == 0) continue;
                result += numberInPlace == 4 && i > 0 ? romanCharacters[i] + romanCharacters[i - 1] :
                new String(new char[numberInPlace]).Replace("\0", romanCharacters[i]);
                num = num % romanValues[i];
            }
            return result;
        }
    }
}