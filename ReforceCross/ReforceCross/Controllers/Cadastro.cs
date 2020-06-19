using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Xamarin.Forms;
using System.Runtime.CompilerServices;
using System.Data;
using Dapper;

namespace ReforceCross.Controllers
{
    class Cadastro
    {
        string Sql, Sql2;

        SqlCommand Command;
        ConexaoSql con = new ConexaoSql();

        public void Cadastrar(DateTime dtcadastro, string nome, string sobrenome, string cep, string rua, string bairro,
            string cidade, string uf, int numero, string complemento, string mail, string fixo, string celular,
            SqlMoney valor, string loginuser, string senha, char tipousuario)
        {
            Sql = " insert into PROFESSOR (DTCADASTRO, NOME, SOBRENOME, CEP, RUA, BAIRRO, CIDADE,UF, NUMERO, COMPLEMENTO, FIXO, CELULAR, MAIL, VALORAULA) values(@dtcadastro, @nome, @sobrenome, @cep, @rua, @bairro, @cidade, @uf, @numero, @complemento, @fixo, @celular, @mail, @valor)";
            Sql2 = " insert into USUARIO(LOGINUSER, SENHA, IDPROF, TIPOUSUARIO) VALUES(@loginuser, @senha, @idprof, @tipousuario)";
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
        }

        private int GetIdProfessor()
        {
            List<int> ids = new List<int>();
            using (IDbConnection connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=DBTRABALHO;User Id=sa;Password=1234;"))
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
