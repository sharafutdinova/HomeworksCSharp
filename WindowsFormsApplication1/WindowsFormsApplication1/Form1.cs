using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Text.RegularExpressions;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        StreamReader sr;

        public Form1()
        {
            InitializeComponent();
        }
           
        private void button3_Click(object sender, EventArgs e)
        {//Программа достаёт исходный код страницы
            //создаём строку url,в которой будем указывать адресс сайта
            string url = "https://github.com/kinley/09-411";
            //Создаём объект , который будет выполнять запрос к URI(идентификатор ресурса)
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            //GetResponse - возвращает ответ на интернет-запрос
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            //Реализуем считывание символов из потока байтов в определенной кодировке.
            //GetResponseStream -  возвращает поток данных из  интернет-ресурса
            sr = new StreamReader(response.GetResponseStream());
            //StreamWriter sw = new StreamWriter("code.html");
            //Читаем поток от начала до конца
            //sw.WriteLine(sr.ReadToEnd());
            //sr.BaseStream.Position = 0;
            //richTextBox1.Text = sr.ReadToEnd();
            //закрываем поток

            sr.Close();
        }

       
        private void button2_Click(object sender, EventArgs e)
        {
            Regex regex = new Regex("2015-04-09");
            sr = new StreamReader("code.txt");
            sr.BaseStream.Position = 0;
            string line = sr.ReadLine();
            while (line != null)
            {
                if (regex.IsMatch(line))
                    richTextBox2.Text = "В исходной строке: " + line + " есть совпадения!";
                else
                    richTextBox1.Text = "В исходной строке: " + line + " no совпадения!";
                line = sr.ReadLine();
            }
        }
    }

    public class Commit
    {
        public string content;
        public string message;
        //public string age;
        public DateTime age;
        public string type;//directory or txt...

        public Commit(string type, string content, string message, DateTime age)
        {
            this.age = age;
            this.message = message;
            this.type = type;
            this.content = content;
        }
    }
}
