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
    public partial class frmEntradaProd : Form
    {
        Entrada en = new Entrada();
        ConectaEntrada co = new ConectaEntrada();
        int cod;
        string cancel;

        public frmEntradaProd()
        {
            InitializeComponent();
        }

        public void Atualizar()
        {
            cod = AuxClas.codigo;
            textBox1.Text = AuxClas.material;
            textBox2.Text = Convert.ToString(AuxClas.quantidade);
            comboBox1.Text = AuxClas.tipo;
            if (AuxClas.cancelar == "ok")
            {
                dateTimePicker1.Text = Convert.ToDateTime(AuxClas.data).ToString();
            }
            cancel = AuxClas.cancelar;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                string msg = "Informe o nome do material";
                frmMensagem mg = new frmMensagem(msg);
                mg.ShowDialog();
            }
            else if (textBox2.Text == "")
            {
                string msg = "Informe a quantidade";
                frmMensagem mg = new frmMensagem(msg);
                mg.ShowDialog();
            }
            else if (comboBox1.Text == "")
            {
                string msg = "Informe o tipo";
                frmMensagem mg = new frmMensagem(msg);
                mg.ShowDialog();
            }
            else
            {
                en.Material = textBox1.Text;
                en.Quantidade = Convert.ToInt32(textBox2.Text);
                en.Tipo = comboBox1.Text;
                en.Data = Convert.ToDateTime(dateTimePicker1.Text);

                co.cadastro(en);
                string msg = "Material cadastrado!!!";
                frmMensagem mg = new frmMensagem(msg);
                mg.ShowDialog();

                textBox1.Text = "";
                textBox2.Text = "";
                comboBox1.Text = "";
                this.dateTimePicker1.Value = DateTime.Now.Date;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "Editar")
            {
                button2.Text = "Salvar";
                button1.Enabled = false;
                button3.Enabled = false;
                frmAtEntrada frm = new frmAtEntrada();
                frm.ShowDialog();
            }
            else if (button2.Text == "Salvar")
            {
                en.Codigo = cod;
                en.Material = textBox1.Text;
                en.Quantidade = Convert.ToInt32(textBox2.Text);
                en.Tipo = comboBox1.Text;
                en.Data = Convert.ToDateTime(dateTimePicker1.Text);
                co.atualizar(en);
                string msg = "Cadastro alterado com sucesso!!!";
                frmMensagem mg = new frmMensagem(msg);
                mg.ShowDialog();

                button2.Text = "Editar";
                button1.Enabled = true;
                button3.Enabled = true;
                textBox1.Text = "";
                textBox2.Text = "";
                comboBox1.Text = "";
                this.dateTimePicker1.Value = DateTime.Now.Date;
                AuxClas.cancelar = "";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text == "Excluir")
            {
                button3.Text = "Excluir Cadastro";
                button1.Enabled = false;
                button2.Enabled = false;
                frmAtEntrada frm = new frmAtEntrada();
                frm.ShowDialog();
            }
            else if (button3.Text == "Excluir Cadastro")
            {
                en.Codigo = cod;
                co.excluir(en);
                string msg = "Cadastro Excluído!!!";
                frmMensagem mg = new frmMensagem(msg);
                mg.ShowDialog();

                button3.Text = "Excluir";
                button1.Enabled = true;
                button2.Enabled = true;
                textBox1.Text = "";
                textBox2.Text = "";
                comboBox1.Text = "";
                this.dateTimePicker1.Value = DateTime.Now.Date;
                AuxClas.cancelar = "";
            }
        }

        private void frmEntradaProd_Activated(object sender, EventArgs e)
        {
            Atualizar();
            
            if (cancel == "cancelar")
            {
                button1.Enabled = true;
                button2.Text = "Editar";
                button2.Enabled = true;
                button3.Text = "Excluir";
                button3.Enabled = true;
                textBox1.Text = "";
                textBox2.Text = "";
                comboBox1.Text = "";
            }
            else if (cancel != "ok")
            {
                textBox1.Clear();
                textBox2.Clear();
                comboBox1.Text = "";
                AuxClas.cancelar = "";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Text = "Editar";
            button2.Enabled = true;
            button3.Text = "Excluir";
            button3.Enabled = true;
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.Text = "";
            this.dateTimePicker1.Value = DateTime.Now.Date;
            AuxClas.cancelar = "";
        }
    }
}
