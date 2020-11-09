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
    public partial class frmAnotacao : Form
    {
        DialogResult result;
        ConectaReag co = new ConectaReag();
        Reagente re = new Reagente();
        int grid;

        public frmAnotacao()
        {
            InitializeComponent();
        }

        private void carregaGrid()
        {
            int cont = co.Registros().Rows.Count;

            if (cont > 0)
            {
                dataGridView1.Rows.Clear();
                foreach (DataRow linha in co.Registros().Rows)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = Convert.ToDateTime(linha["data"].ToString()).ToString("dd/MM/yyyy");
                    dataGridView1.Rows[n].Cells[1].Value = linha["registro"].ToString();
                    dataGridView1.Rows[n].Cells[2].Value = linha["cod"].GetHashCode();
                }
                grid = dataGridView1.Rows.Count;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                string msg = "Não existe registro para ser incluído!!!";
                frmMensagem mg = new frmMensagem(msg);
                mg.ShowDialog();
                textBox1.Focus();
            }
            else
            {
                re.Data = DateTime.Now;
                re.Registro = textBox1.Text;

                co.cadastroRegistro(re);
                string msg = "Registro Cadastrado!!!";
                frmMensagem mg = new frmMensagem(msg);
                mg.ShowDialog();
                textBox1.Text = "";
                carregaGrid();
            }
        }

        private void frmAnotacao_Load(object sender, EventArgs e)
        {
            carregaGrid();
            label1.Visible = false;
            textBox1.MaxLength = 616;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label1.Visible = true;
            string characters = textBox1.Text;
            label1.Text = "Restam: "+Convert.ToString(616 - characters.Length)+" caracteres.";
        }

        private void AutoSizeRowsMode(Object sender, EventArgs es)
        {
            
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (grid > 0)
            {
                string message = "Deseja excluir o arquivo?";
                string caption = "Escolha uma opção";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;

                result = MessageBox.Show(message, caption, buttons);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    re.Codigo = dataGridView1[2, dataGridView1.CurrentCellAddress.Y].Value.GetHashCode();
                    co.excluirRegistro(re);
                    string msg = "Registro Excluído com sucesso!!!";
                    frmMensagem mg = new frmMensagem(msg);
                    mg.ShowDialog();
                    carregaGrid();
                }
            }
        }
    }
}
