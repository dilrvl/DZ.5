using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    internal class Program
    {
        static void Calculate(char[] letters, out int vowels, out int consonants)
        {
            vowels = 0;
            consonants = 0;
            string rvowels = "уУеЕёЁоОаАыЫяЯиИюЮ";
            string rconsonants = "йЙцЦкКнНгГшШщЩзЗхХъЪфФвВпПрРлЛдДжЖчЧсСмМтТьЬбБ";
            foreach (char c in letters)
            {
                if (char.IsLetter(c))
                {
                    if (rvowels.Contains(c))
                    {
                        vowels++;
                    }
                    else if (rconsonants.Contains(c))
                    {
                        consonants++;
                    }
                }
            }
            static void Main(string[] args)
        {
        }
    }
}
