using System;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace ControlLab
{
    class ConectaEntrada
    {
        public MySqlConnection conexao;
        string caminho = "Persist Security Info=false;SERVER=10.66.122.42;DATABASE=laboratorio;UID=secac;pwd=secac";

        public void cadastro(Entrada en)
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();
                string inserir = "INSERT INTO entradas(material, quant, tipo, data)VALUES('" + en.Material + "','" + en.Quantidade + "','" + en.Tipo + "','" + Convert.ToDateTime(en.Data).ToString("yyyy-MM-dd") + "')";
                MySqlCommand comandos = new MySqlCommand(inserir, conexao);
                comandos.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro de comandos: " + ex.Message);
            }
        }

        public void atualizar(Entrada en)
        {

            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();
                string alterar = "UPDATE entradas SET material ='" + en.Material + "', quant = '" + en.Quantidade + "', tipo = '" + en.Tipo + "', data='" + Convert.ToDateTime(en.Data).ToString("yyyy-MM-dd") + "' WHERE cod = '" + en.Codigo + "'";
                MySqlCommand comandos = new MySqlCommand(alterar, conexao);
                comandos.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro de comandos: " + ex.Message);
            }
        }

        public void excluir(Entrada en)
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();
                string alterar = "DELETE FROM entradas WHERE cod = '" + en.Codigo + "'";
                MySqlCommand comando = new MySqlCommand(alterar, conexao);
                comando.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro de comandos: " + ex.Message);
            }
        }

        public DataTable Material(Entrada es)
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();
                string selecionar = "SELECT cod, material, quant, tipo, data FROM entradas where material LIKE '%" + es.Material + "%' order by data DESC";
                MySqlDataAdapter comandos = new MySqlDataAdapter(selecionar, conexao);
                DataTable dt = new System.Data.DataTable();
                comandos.Fill(dt);
                conexao.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro de comandos: " + ex.Message);
            }
        }
    }
}
