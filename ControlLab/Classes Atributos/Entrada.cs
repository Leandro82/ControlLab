using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControlLab
{
    class Entrada
    {
        private int nCod;
        private string nMat;
        private int nQuant;
        private string nTp;
        private DateTime nData;

        public int Codigo
        {
            get { return nCod; }
            set { nCod = value; }
        }

        public string Material
        {
            get { return nMat; }
            set { nMat = value; }
        }

        public int Quantidade
        {
            get { return nQuant; }
            set { nQuant = value; }
        }

        public string Tipo
        {
            get { return nTp; }
            set { nTp = value; }
        }

        public DateTime Data
        {
            get { return nData; }
            set { nData = value; }
        }
    }
}
