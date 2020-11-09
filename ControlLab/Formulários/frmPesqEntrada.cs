using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ControlLab
{
    public partial class frmPesqEntrada : Form
    {
        Entrada en = new Entrada();
        ConectaEntrada co = new ConectaEntrada();
        public frmPesqEntrada()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            en.Material = textBox1.Text;
            int cont = co.Material(en).Rows.Count;
            if (cont > 0)
            {
                dataGridView1.Rows.Clear();
                foreach (DataRow item in co.Material(en).Rows)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = item["cod"].GetHashCode();
                    dataGridView1.Rows[n].Cells[1].Value = item["material"].ToString();
                    dataGridView1.Rows[n].Cells[2].Value = item["quant"].GetHashCode();
                    dataGridView1.Rows[n].Cells[3].Value = item["tipo"].ToString();
                    dataGridView1.Rows[n].Cells[4].Value = Convert.ToDateTime(item["data"].ToString()).ToString("dd/MM/yyyy");
                }
            }
            else
            {
                dataGridView1.Rows.Clear();
            }
        }
    }
}
