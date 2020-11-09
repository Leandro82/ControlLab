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
    class ConectaReag
    {
        public MySqlConnection conexao;
        string caminho = "Persist Security Info=false;SERVER=10.66.122.42;DATABASE=laboratorio;UID=secac;pwd=secac";

        public void cadastro(Reagente re)
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();
                string inserir = "INSERT INTO reagente(reagente, armario, lab)VALUES('" + re.Reagentes + "','" + re.Armario + "','" + re.Laboratorio + "')";
                MySqlCommand comandos = new MySqlCommand(inserir, conexao);
                comandos.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro de comandos: " + ex.Message);
            }
        }

        public void atualizar(Reagente re)
        {

            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();
                string alterar = "UPDATE reagente SET reagente ='" + re.Reagentes + "', armario = '" + re.Armario + "', lab = '" + re.Laboratorio + "' WHERE cod = '" + re.Codigo + "' AND lab='" + re.Laboratorio + "'";
                MySqlCommand comandos = new MySqlCommand(alterar, conexao);
                comandos.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro de comandos: " + ex.Message);
            }
        }

        public void excluir(Reagente re)
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();
                string alterar = "DELETE FROM reagente WHERE cod = '" + re.Codigo + "'AND lab='" + re.Laboratorio + "'";
                MySqlCommand comando = new MySqlCommand(alterar, conexao);
                comando.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro de comandos: " + ex.Message);
            }
        }

        public void excluirRegistro(Reagente re)
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();
                string alterar = "DELETE FROM registro WHERE cod = '" + re.Codigo + "'";
                MySqlCommand comando = new MySqlCommand(alterar, conexao);
                comando.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro de comandos: " + ex.Message);
            }
        }

        public DataTable Reagente(Reagente re)
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();
                string selecionar = "SELECT cod, reagente, armario, lab FROM reagente where reagente LIKE '%" + re.Reagentes + "%'AND lab='" + re.Laboratorio + "' order by reagente";
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

        public void cadastroRegistro(Reagente re)
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();
                string inserir = "INSERT INTO registro(data, registro)VALUES('" + Convert.ToDateTime(re.Data).ToString("yyyy-MM-dd") + "','" + re.Registro + "')";
                MySqlCommand comandos = new MySqlCommand(inserir, conexao);
                comandos.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro de comandos: " + ex.Message);
            }
        }

        public DataTable Registros()
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();
                string selecionar = "SELECT cod, data, registro FROM registro order by data DESC";
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
