using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperASPNetCore.Dto
{
	public class InitEmail
	{
		public int Id { get; set; }
		public int Switches { get; set; }
		public string Correo { get; set; }
		public string Tipo { get; set; }
	}
}
