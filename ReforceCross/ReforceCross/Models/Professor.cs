using System;
using System.Collections.Generic;
using System.Text;

namespace ReforceCross.Models
{
    public class Professor
    {
		public int ID { get; set; }
		public DateTime DTCADASTARO { get; set; }
		public string NOME { get; set; }
		public string SOBRENOME { get; set; }
		public string CEP { get; set; }
		public string RUA { get; set; }
		public string BAIRRO { get; set; }
		public string CIDADE { get; set; }
		public string UF { get; set; }
		public int NUMERO { get; set; }
		public string COMPLEMENTO { get; set; }
		public string FIXO { get; set; }
		public string CELULAR { get; set; }
		public string MAIL { get; set; }
		public decimal VALORAULA { get; set; }

		public string DISCIPLINA { get; set; }
	}
}
