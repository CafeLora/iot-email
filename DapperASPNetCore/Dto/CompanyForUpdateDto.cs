using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperASPNetCore.Dto
{
	public class CompanyForUpdateDto
	{
		public int Id { get; set; }
		public float Temperatura { get; set; }
		public float Humedad { get; set; }
	}
}
