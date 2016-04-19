using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WildcardCode
{
    class Program
    {
        public static int Encryption(int code, char[] alph)
        {
            /*char[] alph = {'q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p', 
                               'a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 
                               'z', 'x', 'c', 'v', 'b', 'n', 'm'};*/
            if (code >= 65 && code <= 90)
            {
                code = (int)alph[code - 65] - 32;
            }
            else
                if (code <= 122 && code >= 97)
                {
                    code = (int)alph[code - 97];
                }
            return code;
        }

        public static int Decryption(int code, char[] alphabet)
        {
            if (code >= 65 && code <= 90)
            {
                bool find = false;
                int i = 0;
                while (!find)
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
                    while (!find)
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

        static void Main(string[] args)
        {
            char[] alphabet = {'q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o',
                               'p', 'a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 
                               'l', 'z', 'x', 'c', 'v', 'b', 'n', 'm'};

            var str = new StreamReader("Lewis_Carroll_Alices Adventures in Wonderland.txt");

            //var str = new StreamReader("Fitzgerald_The_Great_Gatsby.txt");

            var stw = new StreamWriter("text2.txt");

            string line = str.ReadLine();
            int n;
            int code;
            while (line != null)
            {
                n = line.Length;                
                for (int i = 0; i < n; i++)
                {
                    code = (int)line[i];
                    code = Encryption(code, alphabet);
                    stw.Write((char)code);
                }
                line = str.ReadLine();
                stw.WriteLine();
            }
            stw.Close();
            str.Close();

            str = new StreamReader("text2.txt");
            stw = new StreamWriter("text3.txt");
            line = str.ReadLine();
            while (line != null)
            {
                n = line.Length;
                for (int i = 0; i < n; i++)
                {
                    code = (int)line[i];
                    code = Decryption(code, alphabet);
                    stw.Write((char)code);
                }
                line = str.ReadLine();
                stw.WriteLine();
            }

            stw.Close();
            str.Close();
        }
    }
}
