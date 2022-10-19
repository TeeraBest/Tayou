using Nut;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utac.BusinessLogic.Helpers
{
    public static class ConvertHelper
    {
        public static Stream ConvertToStream(this byte[] byteArray)
        {
            return new MemoryStream(byteArray);
        }

        public static int GenerateDataRunningID(this IEnumerable<string> ids)
        {
            var onlyFormatGenerated = ids.Where(e => e != null && e.StartsWith($"0")).ToList();
            var maxRunning = !onlyFormatGenerated.IsEmpty() ? onlyFormatGenerated.Max(e => e.GetNumber()) : 0;
            var running = maxRunning + 1;
            return running;
        }

        public static bool IsEmpty<T>(this IEnumerable<T> enumerable)
        {
            if (typeof(T).Name == typeof(char).Name && enumerable != null)
            {
                string str = string.Join("", enumerable);

                return string.IsNullOrWhiteSpace(str);
            }

            return enumerable == null || enumerable?.Count() == 0;
        }

        public static int GetNumber(this string id)
        {
            var digits = id.Where(c => Char.IsDigit(c)).ToArray();
            return new string(digits).ToInt();
        }

        public static int ToInt(this string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return 0;
            return Convert.ToInt32(s);
        }

        public static string MoneyToWord(this decimal money,string lan) {
            string output = "";
            var strMoney = money.ToString();
            if (strMoney.IndexOf(".") != -1) {
                var tempStrMoneyArr = strMoney.Split('.');
                output = int.Parse(tempStrMoneyArr[0]).ToText(lan) + " con ";
                output += int.Parse(tempStrMoneyArr[1]).ToText(lan);
            } else {
                output = int.Parse(strMoney).ToText(lan);
            }
            return output;
        }
        public static string IntToWord(this int number,string lan) {
            string output = "";
            output = number.ToText(lan);
            return output;
        }

        public static T[] RemoveAt<T>(this T[] source, int index)
        {
            T[] dest = new T[source.Length - 1];
            if (index > 0)
                Array.Copy(source, 0, dest, 0, index);

            if (index < source.Length - 1)
                Array.Copy(source, index + 1, dest, index, source.Length - index - 1);

            return dest;
        }
        //public static void WriteLog(this Logger logger, string message)
        //{
        //    logger.Error(message);
        //}

    }
}
