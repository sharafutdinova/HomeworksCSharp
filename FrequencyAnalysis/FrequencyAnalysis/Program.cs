using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FrequencyAnalysis
{
    class Program
    {
        public static void SymbolRate(int[] frequency, int code)//частота символа
        {
            if (code >= 65 && code <= 90)
            {
                frequency[code - 65]++;
            }
            else
                if (code >= 97 && code <= 122)
                {
                    frequency[code - 97]++;
                }
        }

        //public static char[] GetAlphabet(int[] frequency1, int[] frequency2)//получаем алфавит для замены символов в тексте
        //{
        //    char[] alph = new char[26];

        //    for (int i = 0; i < 26; i++)
        //    {
        //        for (int j = 0; j < 26; j++)
        //        {
        //            if (frequency1[i] == frequency2[j] && frequency1[i] != 0 && frequency2[j] != 0)
        //            {
        //                alph[i] = (char)(j + 97);
        //                frequency1[i] = 0;
        //                frequency2[j] = 0;
        //            }
        //        }
        //    }

        //    return alph;
        //}

        public static char[] GetAlphabet(int[] fr1, int[] fr2)//получаем алфавит для замены символов в тексте
        {
            int max1;
            int max2;
            char[] alph = new char[26];

            for (int i = 0; i < 26; i++)
            {
                max1 = fr1.Max();
                max2 = fr2.Max();
                bool find = false;
                int j = 0;

                while (!find && j < 26)
                {
                    if (max2 == fr2[j])
                    {
                        break;
                    }
                    j++;
                }

                find = false;
                int k = 0;

                while (!find && k < 26)
                {
                    if (max1 == fr1[k])
                    {
                        break;
                    }
                    k++;
                }

                Console.WriteLine(fr1.Max() + " " + k + " " + fr2.Max() + " " + j);
                //alph[j] = (char)(k + 97);
                //Console.WriteLine((char)(j + 65) + " " + alph[j]);

                alph[k] = (char)(j + 97);
                Console.WriteLine((char)(k + 65) + " " + alph[k]);
                fr1[k] = 0;
                fr2[j] = 0;
            }

            return alph;
        }

        public static StreamWriter Replacement(char[] alph, StreamWriter stw, StreamReader str)//заменяем символы в тексте
        {
            str.BaseStream.Position = 0;
            int length;
            int code;
            string line = str.ReadLine();

            while (line != null)
            {
                length = line.Length;
                for (int i = 0; i < length; i++)
                {
                    code = (int)line[i];
                    code = Decryption(code, alph);
                    stw.Write((char)code);
                }
                line = str.ReadLine();
                stw.WriteLine();
            }
            return stw;
        }

        public static int Decryption(int code, char[] alphabet)//расшифровывание
        {
            if (code >= 65 && code <= 90)
            {
                bool find = false;
                int i = 0;
                while (!find && i < 26)
                {
                    if ((char)(code + 32) == alphabet[i])
                        find = true;
                    else
                        i++;
                }
                code = i + 65;
            }
            else
                if (code <= 122 && code >= 97)
                {
                    bool find = false;
                    int i = 0;
                    while (!find && i < 26)
                    {
                        if ((char)code == alphabet[i])
                            find = true;
                        else
                            i++;
                    }
                    code = i + 97;
                }
            return code;
        }

        public static void FrequencyInText(StreamReader str, int[] frequency)//частота в тесте
        {
            int len;
            int code;
            string line = str.ReadLine();
            while (line != null)
            {
                len = line.Length;
                for (int i = 0; i < len; i++)
                {
                    code = (int)line[i];
                    SymbolRate(frequency, code);
                }
                line = str.ReadLine();
            }
        }

        static void Main(string[] args)
        {
            var str1 = new StreamReader("text1.txt");
            var str2 = new StreamReader("text2.txt");
          
            var stw = new StreamWriter("text3.txt");

            int[] frequency1 = new int[26];//частота в незашифрованном тексте
            int[] frequency2 = new int[26];//частота в зашифрованном тексте

            for (int i = 0; i < 26; i++)
            {
                frequency1[i] = 0;
                frequency2[i] = 0;
            }

            FrequencyInText(str1, frequency1);
            FrequencyInText(str2, frequency2);

            //for (int i = 0; i < 26; i++)
            //{
            //    Console.WriteLine((char)(i + 65) + " " + frequency1[i] + " " + (char)(i + 65) + " " + frequency2[i]);
            //}
            
            char[] alph = GetAlphabet(frequency1, frequency2);

            for (int i = 0; i < 26; i++)
            {
                Console.WriteLine((char)(i + 65) + " " + alph[i]);
            }

            stw = Replacement(alph, stw, str2);

            Console.ReadLine();

        }
    }
}
