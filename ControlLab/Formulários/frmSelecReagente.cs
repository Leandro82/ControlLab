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
    public partial class frmSelecReagente : Form
    {
        Reagente re = new Reagente();
        ConectaReag co = new ConectaReag();

        public frmSelecReagente()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                string msg = "Informar o nº do laboratório";
                frmMensagem mg = new frmMensagem(msg);
                mg.ShowDialog();
                comboBox1.Focus();
            }
            else
            {
                re.Reagentes = textBox1.Text;
                re.Laboratorio = Convert.ToInt32(comboBox1.Text);
                int cont = co.Reagente(re).Rows.Count;
                if (cont > 0)
                {
                    dataGridView1.Rows.Clear();
                    foreach (DataRow item in co.Reagente(re).Rows)
                    {
                        int n = dataGridView1.Rows.Add();
                        dataGridView1.Rows[n].Cells[0].Value = item["cod"].GetHashCode();
                        dataGridView1.Rows[n].Cells[1].Value = item["reagente"].ToString();
                        dataGridView1.Rows[n].Cells[2].Value = item["armario"].ToString();
                        dataGridView1.Rows[n].Cells[3].Value = item["lab"].GetHashCode();
                    }
                }
                else
                {
                    dataGridView1.Rows.Clear();
                }
            }
        }
    }
}
