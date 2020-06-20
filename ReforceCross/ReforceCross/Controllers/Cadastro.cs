using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Xamarin.Forms;
using System.Runtime.CompilerServices;
using System.Data;
using Dapper;
using ReforceCross.Models;

namespace ReforceCross.Controllers
{
    //Classe de cadastro
    class Cadastro
    {
        string Sql, Sql2, Sql3;

        SqlCommand Command;
        ConexaoSql con = new ConexaoSql();

        //Método para realizar o cadastro de um novo professor
        public void Cadastrar(DateTime dtcadastro, string nome, string sobrenome, string cep, string rua, string bairro,
            string cidade, string uf, int numero, string complemento, string mail, string fixo, string celular,
            SqlMoney valor, string loginuser, string senha, int discp, char tipousuario)
        {
            Sql = " insert into PROFESSOR (DTCADASTRO, NOME, SOBRENOME, CEP, RUA, BAIRRO, CIDADE,UF, NUMERO, COMPLEMENTO, FIXO, CELULAR, MAIL, VALORAULA) values(@dtcadastro, @nome, @sobrenome, @cep, @rua, @bairro, @cidade, @uf, @numero, @complemento, @fixo, @celular, @mail, @valor)";
            Sql2 = " insert into USUARIO(LOGINUSER, SENHA, IDPROF, TIPOUSUARIO) VALUES(@loginuser, @senha, @idprof, @tipousuario)";
            Sql3 = "insert into DISCIPLINASEPROFESSORES(IDPROF, IDMATERIA) VALUES (@idprof, @idmateria)";
            Command = new SqlCommand(Sql);

            Command.Parameters.AddWithValue("@dtcadastro", dtcadastro);
            Command.Parameters.AddWithValue("@nome", nome);
            Command.Parameters.AddWithValue("@sobrenome", sobrenome);
            Command.Parameters.AddWithValue("@cep", cep);
            Command.Parameters.AddWithValue("@rua", rua);
            Command.Parameters.AddWithValue("@bairro", bairro);
            Command.Parameters.AddWithValue("@cidade", cidade);
            Command.Parameters.AddWithValue("@uf", uf);
            Command.Parameters.AddWithValue("@numero", numero);
            Command.Parameters.AddWithValue("@complemento", complemento);
            Command.Parameters.AddWithValue("@fixo", fixo);
            Command.Parameters.AddWithValue("@celular", celular);
            Command.Parameters.AddWithValue("@mail", mail);
            Command.Parameters.AddWithValue("@valor", valor);
            con.ExercutarComandoSQL(Command);

            int id = GetIdProfessor();

            Command = new SqlCommand(Sql2);
            Command.Parameters.AddWithValue("@loginuser", loginuser);
            Command.Parameters.AddWithValue("@senha", senha);
            Command.Parameters.AddWithValue("@idprof", id);
            Command.Parameters.AddWithValue("@tipousuario", tipousuario);
            con.ExercutarComandoSQL(Command);

            Command = new SqlCommand(Sql3);
            
            Command.Parameters.AddWithValue("@idprof", id);
            Command.Parameters.AddWithValue("@idmateria", discp);

            con.ExercutarComandoSQL(Command);
        }

        //Método para Buscar o ID do Professor.
        private int GetIdProfessor()
        {
            List<int> ids = new List<int>();
            using (IDbConnection connection = new SqlConnection(@"Data Source=DESKTOP-99ATQQ4;Initial Catalog=DBTRABALHO;User Id=sa;Password=1234;"))
            {
                ids = connection.Query<int>("SELECT MAX(ID) FROM PROFESSOR").AsList();
                int a = 0;
                foreach (int x in ids)
                {
                    a = x;
                }
                return a;
            }
        }
    }
}
