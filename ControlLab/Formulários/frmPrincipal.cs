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
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var peq = new frmReagentes();
            if (Application.OpenForms.OfType<frmReagentes>().Count() > 0)
            {
                Application.OpenForms[peq.Name].Focus();
            }
            else
            {
                peq.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var peq = new frmSelecReagente();
            if (Application.OpenForms.OfType<frmSelecReagente>().Count() > 0)
            {
                Application.OpenForms[peq.Name].Focus();
            }
            else
            {
                peq.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var peq = new frmEntradaProd();
            if (Application.OpenForms.OfType<frmEntradaProd>().Count() > 0)
            {
                Application.OpenForms[peq.Name].Focus();
            }
            else
            {
                peq.Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var peq = new frmPesqEntrada();
            if (Application.OpenForms.OfType<frmPesqEntrada>().Count() > 0)
            {
                Application.OpenForms[peq.Name].Focus();
            }
            else
            {
                peq.Show();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var peq = new frmAnotacao();
            if (Application.OpenForms.OfType<frmAnotacao>().Count() > 0)
            {
                Application.OpenForms[peq.Name].Focus();
            }
            else
            {
                peq.Show();
            }
        }
    }
}
