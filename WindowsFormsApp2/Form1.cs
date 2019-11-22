using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public List<Fruits> Obj = new List<Fruits>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        public class Fruits
        {
            public bool isSelected { get; set; }
            public string Items { get; set; }

            public int Sno { get; set; }


        }

        public void LoadData()
        {
            

            Fruits F1 = new Fruits();
            
            F1.isSelected = false;
            F1.Sno = 1;
            F1.Items = "Apple";

            Obj.Add(F1);

            F1 = new Fruits();
            F1.isSelected = false;
            F1.Items = "Banana";
            F1.Sno = 2;
            Obj.Add(F1);

            F1 = new Fruits();
            F1.isSelected = false;
            F1.Sno = 3;
            F1.Items = "Guva";
            Obj.Add(F1);

            F1 = new Fruits();
            F1.isSelected = false;
            F1.Sno = 4;
            F1.Items = "Grapes";
            Obj.Add(F1);

            F1 = new Fruits();
            F1.isSelected = false;
            F1.Sno = 5;
            F1.Items = "Orange";
            Obj.Add(F1);
            LoadGrid(Obj);
        }

        public void LoadGrid(List<Fruits> f)
        {
            var data = new BindingSource(f, null);
            dataGridView1.DataSource = data;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.Refresh();
        }

        public void processBottom(List<Fruits> f)
        {
        
            List<int> order = new List<int>();

                        string input = Console.ReadLine();
            //String[] ids = input.Split(',');
            ArrayList aList = new ArrayList();

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                bool isCellChecked = (bool)dataGridView1.Rows[i].Cells[0].Value;
                if (isCellChecked)
                {
                    aList.Add(i);
                }
            }


            for (int i = 0; i < f.Count; i++)
            {
                if (!aList.Contains(i))
                {
                    order.Add(i);
                }
            }
            
            order.AddRange(aList.Cast<int>().ToList());

            var result = order.Select(i => f[i]).ToList();

            LoadGrid(result);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            processBottom(Obj);
        }
    }
}
