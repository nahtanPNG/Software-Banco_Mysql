using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Banco_Mysql
{
    public partial class Form1 : Form
    {
        public string sql;
        MySqlConnection conexao;
        MySqlCommand comando;

         
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conexao = new MySqlConnection("server=localhost; user=root; password=root");
            conexao.Open();

            comando = new MySqlCommand("create database if not exists usuario; use usuario", conexao);
            comando.ExecuteNonQuery();

            comando = new MySqlCommand("create table if not exists funcionario(codigo int(11) not null primary key auto_increment,nome varchar(50) not null, rua varchar(50) not null, numero varchar(10) not null, bairro varchar(30) not null, cep varchar(10) not null, tel varchar(50) not null, email varchar(55) not null)", conexao, null);

            comando.ExecuteNonQuery();
            conexao.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            sql = "insert into funcionario(nome, rua, numero, bairro, cep, tel, email)values('" + txtNome.Text + "', '" + txtRua.Text + "', '" + txtNumero.Text + "', '" + txtBairro.Text + "', '" + txtCep.Text + "', '"+ txtTel.Text + "', '"+ txtEmail.Text + "')";

            try //Tratamento de erro - try, catch e finally
            {
                conexao.Open();
                try
                {
                    comando = new MySqlCommand(sql, conexao); //Executa os comandos acima
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Dados Salvos com sucesso!!!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch(Exception erro)
                {
                    MessageBox.Show("Erro ao salvar dados!!!", erro.Message);
                }
            }
            catch(Exception erro)
            {
                MessageBox.Show("Erro ao conectar ao Banco!!!", erro.Message);
            }
            finally
            {
                conexao.Close();
            }
            txtNome.Clear();
            txtBairro.Clear();
            txtCep.Clear();
            txtEmail.Clear();
            txtNumero.Clear();
            txtTel.Clear();
            txtRua.Clear();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var consult = new consulta();
            consult.Show();
        }
    }
}
