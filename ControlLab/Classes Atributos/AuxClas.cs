using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControlLab
{
    class AuxClas
    {
        private static int cod;
        public static int codigo
        {
            get { return cod; }
            set { cod = value; }
        }


        private static string reag;
        public static string reagente
        {
            get { return reag; }
            set { reag = value; }
        }

        private static int arm;
        public static int armario
        {
            get { return arm; }
            set { arm = value; }
        }

        private static int lab;
        public static int laboratorio
        {
            get { return lab; }
            set { lab = value; }
        }

        private static string canc;
        public static string cancelar
        {
            get { return canc; }
            set { canc = value; }
        }

        private static string mat;
        public static string material
        {
            get { return mat; }
            set { mat = value; }
        }

        private static int quant;
        public static int quantidade
        {
            get { return quant; }
            set { quant = value; }
        }

        private static string tp;
        public static string tipo
        {
            get { return tp; }
            set { tp = value; }
        }

        private static DateTime dt;
        public static DateTime data
        {
            get { return dt; }
            set { dt = value; }
        }
    }
}
