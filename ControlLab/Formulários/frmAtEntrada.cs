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
    public partial class frmAtEntrada : Form
    {
        Entrada en = new Entrada();
        ConectaEntrada co = new ConectaEntrada();
        frmEntradaProd frm = new frmEntradaProd();
        public frmAtEntrada()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AuxClas.cancelar = "cancelar";
            frm.Atualizar();
            this.Close();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            AuxClas.codigo = dataGridView1[0, dataGridView1.CurrentCellAddress.Y].Value.GetHashCode();
            AuxClas.material = dataGridView1[1, dataGridView1.CurrentCellAddress.Y].Value.ToString();
            AuxClas.quantidade = Convert.ToInt32(dataGridView1[2, dataGridView1.CurrentCellAddress.Y].Value.ToString());
            AuxClas.tipo = dataGridView1[3, dataGridView1.CurrentCellAddress.Y].Value.ToString();
            AuxClas.data = Convert.ToDateTime(dataGridView1[4, dataGridView1.CurrentCellAddress.Y].Value.ToString());
            AuxClas.cancelar = "ok";
            frm.Atualizar();
            this.Close();
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
