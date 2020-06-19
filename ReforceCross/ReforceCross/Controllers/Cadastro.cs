using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Xamarin.Forms;
using System.Runtime.CompilerServices;

namespace ReforceCross.Controllers
{
    class Cadastro
    {
        string Sql;
        string Sql_1;
        string Sql_2;
        SqlCommand Command;
        ConexaoSql con = new ConexaoSql();

        public void Cadastrar(DateTime dtcadastro, string nome, string sobrenome, string cep, string rua, string bairro,
            string cidade, string uf, int numero, string complemento, string mail, string fixo, string celular,
            SqlMoney valor, string loginuser, string senha, char tipousuario)
        {
            int id = 0;


            Sql = " insert into PROFESSOR (DTCADASTRO, NOME, SOBRENOME, CEP, RUA, BAIRRO, CIDADE,UF, NUMERO, COMPLEMENTO, FIXO, CELULAR, MAIL, VALORAULA) values(@dtcadastro, @nome, @sobrenome, @cep, @rua, @bairro, @cidade, @uf, @numero, @complemento, @fixo, @celular, @mail, @valor)";
            Sql += " SELECT SCOPE_IDENTITY() ";
            Sql+= " insert into USUARIO(LOGINUSER,SENHA, IDPROF, TIPOUSUARIO) VALUES(@loginuser, @senha, @idprof @tipousuario)";
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
            Command.Parameters.AddWithValue("@mail", mail);
            Command.Parameters.AddWithValue("@fixo", fixo);
            Command.Parameters.AddWithValue("@celular", celular);
            Command.Parameters.AddWithValue("@valor", valor);
            id = (int)Command.ExecuteScalar();
            con.ExercutarComandoSQL(Command);
            
            Command.Parameters.AddWithValue("@loginuser", loginuser);
            Command.Parameters.AddWithValue("@idprof", id);
            Command.Parameters.AddWithValue("@senha", senha);
            Command.Parameters.AddWithValue("@tipousuario", tipousuario);

          

        }

    }
}
