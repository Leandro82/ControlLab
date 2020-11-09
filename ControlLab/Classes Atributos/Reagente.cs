using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControlLab
{
    class Reagente
    {
        private int nCod;
        private string nReag;
        private int nArm;
        private int Nlab;
        private DateTime nData;
        private string nReg;

        public int Codigo
        {
            get { return nCod; }
            set { nCod = value; }
        }

        public string Reagentes
        {
            get { return nReag; }
            set { nReag = value; }
        }

        public int Armario
        {
            get { return nArm; }
            set { nArm = value; }
        }

        public int Laboratorio
        {
            get { return Nlab; }
            set { Nlab = value; }
        }

        public DateTime Data
        {
            get { return nData; }
            set { nData = value; }
        }

        public string Registro
        {
            get { return nReg; }
            set { nReg = value; }
        }
    }
}
