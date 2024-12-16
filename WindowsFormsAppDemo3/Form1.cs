using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppDemo3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.Columns.Add("Number", "Номер заявки");
            dataGridView1.Columns.Add("Date", "Дата добавления");
            dataGridView1.Columns.Add("Client", "Клиент");

            request = new List<RequestClass> ();
        }

        public class RequestClass
        {
            public int Number { get; set; }
            public DateTime Date { get; set; }
            public string Client { get; set; }

            public RequestClass(int number, DateTime date, string client)
            {
                Number = number;
                Date = date;
                Client = client;
            }
        }

        private List<RequestClass> request;
        private int count; 
        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int number))
            {
                DateTime time = DateTime.Now;
                string client = textBox2.Text;

                request.Add(new RequestClass(number, time, client));
                count++;
                updateGrid();
            } else
            {
                MessageBox.Show("Номер должен быть числом!");
            }
            label1.Text = request.Count.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox3.Text, out int numberToEdit))
            {
                for (int i = 0; i < request.Count; i++)
                {
                    if (request[i].Number == numberToEdit)
                    {
                        request[i].Client = textBox4.Text;
                        updateGrid();
                        return;
                    }

                }
            } else
            {
                MessageBox.Show("Ошибка");
            }
        }

      
        private void updateGrid()
        {
            dataGridView1.Rows.Clear();

            foreach (var request in request)
            {
                dataGridView1.Rows.Add(request.Number, request.Date, request.Client);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int indexToDel = -1;
            if (int.TryParse(textBox5.Text, out int numberToDel))
            {
                for (int i = 0; i < request.Count; i++)
                {
                    if (request[i].Number == numberToDel)
                    {
                        indexToDel = i;
                        break;
                    }

                }

                if (indexToDel != -1) {
                    request.RemoveAt(indexToDel);
                    updateGrid();
                } else
                {
                    MessageBox.Show("Номер не найден");
                }
            }
            else
            {
                MessageBox.Show("Ошибка");
            }

        }
    }
}
