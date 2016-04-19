using System;
using System.IO;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
//using System.ComponentModel;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace DataBaseManager
{
    public partial class Form1 : Form
    {
        FolderBrowserDialog folderBrowserDialog = null;
        DialogResult dialogResult;
        DataSet dataBase;
        TextReader reader;
        TabPage tabPage;
        DataGridView dgv;
        List <DataGridView> tables;

        public Form1()
        {
            InitializeComponent();
            tables = new List<DataGridView>();
        }

        // выбор баззы данных
        public void SelectTheDatabase()
        {
            this.folderBrowserDialog = new FolderBrowserDialog();
            this.dialogResult = this.folderBrowserDialog.ShowDialog();
            this.textBox1.Text = this.folderBrowserDialog.SelectedPath;
        }

        // считывание таблиц
        public void ReadingTables()
        {
            this.reader = new StreamReader(this.folderBrowserDialog.SelectedPath + @"\main.txt");

            string line = reader.ReadLine();
            while (line != null)
            {
                this.dataBase.Tables.Add(line);
                line = reader.ReadLine();
            }
        }

        public void AddingColumns(DataTable table)
        {
            this.reader = new StreamReader(this.folderBrowserDialog.SelectedPath + @"\" + table.TableName + @"\main.txt");
            string column = reader.ReadLine();
            while (column != null)
            {
                table.Columns.Add(column);
                column = reader.ReadLine();
            }
            reader.Close();
        }

        public void AddingData(DataTable table)
        {
            this.reader = new StreamReader(this.folderBrowserDialog.SelectedPath + @"\" + table.TableName + @"\data.txt");
            string data = reader.ReadLine();
            while (data != null)
            {
                table.Rows.Add(data.Split(' '));
                data = reader.ReadLine();
            }
            reader.Close();
        }

        // считывание схем таблиц
        public void ReadingTablesSchema()
        {
            foreach (DataTable table in this.dataBase.Tables)
            {
                AddingColumns(table);

                AddingData(table);
            }
        }

        public DataGridView CreateDataGridView()
        {
            dgv = new DataGridView();
            dgv.Width = 700;
            dgv.Height = 300;
            return dgv;
        }

        public void DisplayData()
        {
            foreach (DataTable table in this.dataBase.Tables)
            {
                tabPage = new TabPage(table.TableName);
                tabControl1.TabPages.Add(tabPage);
                dgv = CreateDataGridView();
                dgv.DataSource = table;
                tabPage.Controls.Add(dgv);
                tables.Add(dgv);
            }      
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            this.dataBase = new DataSet();

            SelectTheDatabase();

            ReadingTables();

            ReadingTablesSchema();

            DisplayData();
        }

        private void deleteRow_Click(object sender, EventArgs e)
        {
            tabPage = tabControl1.SelectedTab;
            bool find = false;
            int i = 0;
            while (!find && i < tabControl1.TabCount)
            {
                if (tabControl1.TabPages[i] == tabPage)
                {
                    int b = 0;
                    int j = tables[i].SelectedRows[b].Index;
                    //tables[i].Rows.RemoveAt(j);
                    dataBase.Tables[i].Rows.RemoveAt(j);
                    //break;
                    find = true;
                }
                else
                {
                    i++;
                }
            }
        }

        private void saveAllChanges_Click(object sender, EventArgs e)
        {
            StreamWriter sw;
            foreach (DataTable table in dataBase.Tables)
            {
                sw = new StreamWriter(this.folderBrowserDialog.SelectedPath + @"\" + table.TableName + @"\data.txt");
                int countCol = table.Columns.Count;
                int countR = table.Rows.Count;
                for (int i = 0; i < countR; i++)
                {
                    string line = "";
                    for (int j = 0; j < countCol - 1; j++)
                    {
                        line += table.Rows[i][j].ToString() + " ";
                    }
                    line += table.Rows[i][countCol - 1].ToString();
                    sw.WriteLine(line);
                }
                sw.Close();
            }
        }
    }
}
