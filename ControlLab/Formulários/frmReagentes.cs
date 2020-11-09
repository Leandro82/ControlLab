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
    public partial class frmReagentes : Form
    {
        Reagente re = new Reagente();
        ConectaReag co = new ConectaReag();
        int cod;
        string cancel;
        public frmReagentes()
        {
            InitializeComponent();
        }

        public void Atualizar()
        {
            //frmReagentes.ActiveForm.Activate();
            cod = AuxClas.codigo;
            textBox1.Text = AuxClas.reagente;
            textBox2.Text = Convert.ToString(AuxClas.armario);
            comboBox1.Text = Convert.ToString(AuxClas.laboratorio);
            cancel = AuxClas.cancelar;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                string msg = "Informe o nome do reagente";
                frmMensagem mg = new frmMensagem(msg);
                mg.ShowDialog();
            }
            else if (textBox2.Text == "")
            {
                string msg = "Informe o nº do armário";
                frmMensagem mg = new frmMensagem(msg);
                mg.ShowDialog();
            }
            else if (comboBox1.Text == "")
            {
                string msg = "Informe o nº do Laboratório";
                frmMensagem mg = new frmMensagem(msg);
                mg.ShowDialog();
            }
            else
            {
                re.Reagentes = textBox1.Text;
                re.Armario = Convert.ToInt32(textBox2.Text);
                re.Laboratorio = Convert.ToInt32(comboBox1.Text);

                co.cadastro(re);
                string msg = "Reagente cadastrado";
                frmMensagem mg = new frmMensagem(msg);
                mg.ShowDialog();

                textBox1.Text = "";
                textBox2.Text = "";
                comboBox1.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "Editar")
            {
                button2.Text = "Salvar";
                button1.Enabled = false;
                button3.Enabled = false;
                frmPesqReagente frm = new frmPesqReagente();
                frm.ShowDialog();
            }
            else if (button2.Text == "Salvar")
            {
                re.Codigo = cod;
                re.Reagentes = textBox1.Text;
                re.Armario = Convert.ToInt32(textBox2.Text);
                re.Laboratorio = Convert.ToInt32(comboBox1.Text);
                co.atualizar(re);
                string msg = "Cadastro alterado com sucesso!!!";
                frmMensagem mg = new frmMensagem(msg);
                mg.ShowDialog();

                button2.Text = "Editar";
                button1.Enabled = true;
                button3.Enabled = true;
                textBox1.Text = "";
                textBox2.Text = "";
                comboBox1.Text = "";
            }
        }

        private void frmReagentes_Activated(object sender, EventArgs e)
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
                AuxClas.cancelar = "";
            }
            else if(cancel != "ok")
            {
                textBox2.Text = "";
                comboBox1.Text = "";
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
                frmPesqReagente frm = new frmPesqReagente();
                frm.ShowDialog();
            }
            else if (button3.Text == "Excluir Cadastro")
            {
                re.Codigo = cod;
                re.Reagentes = textBox1.Text;
                re.Armario = Convert.ToInt32(textBox2.Text);
                re.Laboratorio = Convert.ToInt32(comboBox1.Text);
                co.excluir(re);
                string msg = "Cadastro Excluído!!!";
                frmMensagem mg = new frmMensagem(msg);
                mg.ShowDialog();

                button3.Text = "Excluir";
                button1.Enabled = true;
                button2.Enabled = true;
                textBox1.Text = "";
                textBox2.Text = "";
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
            AuxClas.cancelar = "";
        }
    }
}
