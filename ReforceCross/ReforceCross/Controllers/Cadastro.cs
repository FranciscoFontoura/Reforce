using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace ReforceCross.Controllers
{
    class Cadastro
    {
        string Sql;
        SqlCommand Command;
        ConexaoSql con = new ConexaoSql();

        public void Cadastrar(DateTime dtcadastro, string nome, string sobrenome, string cep, string rua, string bairro,
            string cidade, string uf, int numero, string complemento, string mail, string fixo, string celular, /*char disp,*/
            SqlMoney valor, string loginuser, string senha, char tipousuario)
        {

            Sql = " insert into PROFESSOR (DTCADASTRO, NOME, SOBRENOME, CEP, RUA, BAIRRO, CIDADE,UF, NUMERO, COMPLEMENTO, FIXO, CELULAR, MAIL, DISPONIBILIDADE, VALORAULA) values(@dtcadastro, @nome, @sobrenome, @cep, @rua, @bairro, @cidade, @uf, @numero, @complemento, @fixo, @celular, @mail, @disp, @valor)";
            Sql += " insert into USUARIO(LOGINUSER,SENHA, TIPOUSUARIO) VALUES(@loginuser, @senha, @tipousuario)";
            Command = new SqlCommand(Sql);
            Command.Parameters.AddWithValue("@dtcadastro", dtcadastro);
            Command.Parameters.AddWithValue("@nome", nome);
            Command.Parameters.AddWithValue("@sobrenome", sobrenome);
            Command.Parameters.AddWithValue("@cep", cep);
            Command.Parameters.AddWithValue("@rua", rua);
            Command.Parameters.AddWithValue("@cidade", cidade);
            Command.Parameters.AddWithValue("@uf", cidade);
            Command.Parameters.AddWithValue("@dtcadastro", dtcadastro);
            Command.Parameters.AddWithValue("@numero", numero);
            Command.Parameters.AddWithValue("@complemento", complemento);
            Command.Parameters.AddWithValue("@mail", mail);
            Command.Parameters.AddWithValue("@fixo", fixo);
            Command.Parameters.AddWithValue("@celular", celular);
            // Command.Parameters.AddWithValue("@disp", disp);
            Command.Parameters.AddWithValue("@valor", valor);
            Command.Parameters.AddWithValue("@loginuser", loginuser);
            Command.Parameters.AddWithValue("@senha", senha);
            Command.Parameters.AddWithValue("@tipousuario", tipousuario);
            con.ExercutarComandoSQL(Command);
        }
    }
}
