using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CaesarCode
{
    class Program
    {
        public static int Encryption(int code, int k)
        {
            if (code >= 97 && code <= 122)
            {
                if (code + k > 122)
                {
                    code = (code + k) % 122 + 96;
                }
                else
                {
                    code = code + k;
                }
            }
            else
            {
                if (code >= 65 && code <= 90)
                {
                    if (code + k > 90)
                    {
                        code = (code + k) % 90 + 64;
                    }
                    else
                    {
                        code = code + k;
                    }
                }
            }
            return code;
        }

        public static int Decryption(int code, int k)
        {
            if (code >= 97 && code <= 122)
            {
                if (code - k < 97)
                {
                    code = (code - k) + 26;
                }
                else
                {
                    code = code - k;
                }
            }
            else
            {
                if (code >= 65 && code <= 90)
                {
                    if (code - k < 65)
                    {
                        code = (code - k) + 26;
                    }
                    else
                    {
                        code = code - k;
                    }
                }
            }
            return code;
        }

        static void Main(string[] args)
        {
            var str = new StreamReader("Fitzgerald_The_Great_Gatsby.txt");
            //var str = new StreamReader("Lewis_Carroll_Alices Adventures in Wonderland.txt");            
            var stw = new StreamWriter("text2.txt");
            string line = str.ReadLine();
            int n;
            int k = 5;//сдвиг в алфавите
            
            while (line != null)
            {
                n = line.Length;
                for (int i = 0; i < n; i++)
                {
                    int code = (int)line[i];
                    code = Encryption(code, k);
                    stw.Write((char)code);
                }
                line = str.ReadLine();
                stw.WriteLine();
            }
            str.Close();
            stw.Close();


            str = new StreamReader("text2.txt");
            stw = new StreamWriter("text3.txt");
            line = str.ReadLine();

            while (line != null)
            {
                n = line.Length;
                for (int i = 0; i < n; i++)
                {
                    int code = (int)line[i];
                    code = Decryption(code, k);
                    stw.Write((char)code);
                }
                line = str.ReadLine();
                stw.WriteLine();
            }
            str.Close();
            stw.Close();
        }
    }
}
