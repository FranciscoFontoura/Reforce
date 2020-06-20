using System;
using System.Collections.Generic;
using System.Text;

namespace ReforceCross.Models
{
	//Model de usuarios
    public class Usuarios
    {
		public int ID { get; set; }
		public string LOGINUSER { get; set; }
		public string TIPOUSUARIO { get; set; }
		public int IDPROF { get; set; }
		public string SENHA { get; set; }
	}
}