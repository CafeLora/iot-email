using Dapper;
using DapperASPNetCore.Context;
using DapperASPNetCore.Contracts;
using DapperASPNetCore.Dto;
using DapperASPNetCore.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;

namespace DapperASPNetCore.Repository
{
	public class DispositivoRepository : IDispositivoRepository
	{
		private readonly DapperContext _context;

		public DispositivoRepository(DapperContext context)
		{
			_context = context;
		}

		//public async Task<IEnumerable<DipositivoTTN>> GetCompanies()
		//{
		//	var query = "SELECT id, temperatura, humedad, ph FROM [dbo].[devicesync] WHERE tiempo BETWEEN DATEADD(HOUR, -3, GETUTCDATE()) AND GETUTCDATE()";

		//	using (var connection = _context.CreateConnection())
		//	{
		//		var companies = await connection.QueryAsync<DipositivoTTN>(query);
		//		return companies.ToList();
		//	}
		//}

		//      public async Task<IEnumerable<HumedadTTN>> GetHumedad(string email)
		//      {
		//	var query = "SELECT id, humedad, tiempo FROM [dbo].[devicesync] WHERE tiempo BETWEEN DATEADD(HOUR, -3, GETUTCDATE()) AND GETUTCDATE()";

		//	var query2 = "SELECT * FROM [dbo].[UltimaUmbralMaxHumedad]";

		//	var query3 = "SELECT * FROM [dbo].[UltimaUmbralMinHumedad]";

		//	using (var connection = _context.CreateConnection())
		//	{
		//		var umbralMaxHumedad = await connection.QuerySingleOrDefaultAsync<UmbralMaxHum>(query2);
		//		var umbralMinHumedad = await connection.QuerySingleOrDefaultAsync<UmbralMinHum>(query3);

		//		List<HumedadTTN> list = new List<HumedadTTN>();
		//		list = (List<HumedadTTN>)await connection.QueryAsync<HumedadTTN>(query);
		//		foreach (var x in list)
		//		{
		//			if (x.Humedad < umbralMinHumedad.Ultimo || x.Humedad > umbralMaxHumedad.Ultimo)
		//			{
		//				DateTime dt = DateTime.Parse(x.Tiempo);
		//				SendMail(email, 2, x.Humedad, dt.ToString("hh:mm tt"));
		//			}
		//		}

		//		var humedadTTN = await connection.QueryAsync<HumedadTTN>(query);
		//		return humedadTTN.ToList();
		//	}
		//}

		//      public async Task<IEnumerable<MinMax>> GetMinMax()
		//      {
		//	var query = "SELECT * FROM [dbo].[TemperaturaMaxMin]";

		//	using (var connection = _context.CreateConnection())
		//	{
		//		var minMax = await connection.QueryAsync<MinMax>(query);
		//		return minMax.ToList();
		//	}
		//}

		//      public async Task<MinMax> GetMinMaxById(int id)
		//      {
		//	var query = "SELECT * FROM [dbo].[TemperaturaMaxMin] WHERE Id = @Id";
		//	var parameters = new DynamicParameters();
		//	parameters.Add("Id", id, DbType.Int32, ParameterDirection.Input);

		//	using (var connection = _context.CreateConnection())
		//	{
		//		var minMax = await connection.QueryFirstOrDefaultAsync<MinMax>(query,parameters);

		//		return minMax;
		//	}
		//}

		//      public async Task<IEnumerable<PhTTN>> GetPh(string email)
		//      {
		//	var query = "SELECT id, ph, tiempo FROM [dbo].[devicesync] WHERE tiempo BETWEEN DATEADD(HOUR, -3, GETUTCDATE()) AND GETUTCDATE()";

		//	var query2 = "SELECT * FROM [dbo].[UltimaUmbralMaxPh]";

		//	var query3 = "SELECT * FROM [dbo].[UltimaUmbralMinPh]";

		//	using (var connection = _context.CreateConnection())
		//	{
		//		var umbralMaxPh = await connection.QuerySingleOrDefaultAsync<UmbralMaxPh>(query2);
		//		var umbralMinPh = await connection.QuerySingleOrDefaultAsync<UmbralMinPh>(query3);

		//		List<PhTTN> list = new List<PhTTN>();
		//		list = (List<PhTTN>)await connection.QueryAsync<PhTTN>(query);
		//		foreach (var x in list)
		//		{
		//			if (x.Ph < umbralMinPh.Ultimo || x.Ph > umbralMaxPh.Ultimo)
		//			{
		//				DateTime dt = DateTime.Parse(x.Tiempo);
		//				SendMail(email, 2, x.Ph, dt.ToString("hh:mm tt"));
		//			}
		//		}

		//		var phTTN = await connection.QueryAsync<PhTTN>(query);
		//		return phTTN.ToList();
		//	}
		//}

		//      public async Task<IEnumerable<TemperaturaTTN>> GetTemperatura(string email)
		//      {
		//	var query = "SELECT id, temperatura, tiempo FROM [dbo].[devicesync] WHERE tiempo BETWEEN DATEADD(HOUR, -3, GETUTCDATE()) AND GETUTCDATE()";

		//	var query2 = "SELECT * FROM [dbo].[UltimaUmbralMaxTemperatura]";

		//	var query3 = "SELECT * FROM [dbo].[UltimaUmbralMinTemperatura]";

		//	using (var connection = _context.CreateConnection())
		//	{
		//		var umbralMaxTemp = await connection.QuerySingleOrDefaultAsync<UmbralMaxTemp>(query2);
		//		var umbralMinTemp = await connection.QuerySingleOrDefaultAsync<UmbralMinTemp>(query3);

		//		List<TemperaturaTTN> list = new List<TemperaturaTTN>();
		//              list = (List<TemperaturaTTN>)await connection.QueryAsync<TemperaturaTTN>(query);
		//		foreach (var x in list)
		//		{
		//			if (x.Temperatura < umbralMinTemp.Ultimo || x.Temperatura > umbralMaxTemp.Ultimo)
		//                  {
		//				DateTime dt = DateTime.Parse(x.Tiempo);
		//				SendMail(email, 1, x.Temperatura, dt.ToString("hh:mm tt"));
		//			}
		//		}

		//		var temperaturaTTN = await connection.QueryAsync<TemperaturaTTN>(query);
		//		return temperaturaTTN.ToList();
		//	}
		//}

		public void SendMail(string email, int type, float valor, string momento)
		{
			try
			{
				using (MailMessage mail = new MailMessage())
				{
					mail.From = new MailAddress("funuser535@gmail.com");
					mail.To.Add(email);

					if (type == 1)
					{
						mail.Subject = "Alerta de Temperatura";
						mail.Body = "A las " + momento + " la temperatura detectada fue de " + valor.ToString();
					}
					else if (type == 2)
					{
						mail.Subject = "Alerta de Humedad";
						mail.Body = "A las " + momento + " la humedad detectada fue de " + valor.ToString();
					}
					else if (type == 3)
					{
						mail.Subject = "Alerta de Ph";
						mail.Body = "A las " + momento + " el Ph detectado fue de " + valor.ToString();
					}
					else if (type == 4)
					{
						mail.Subject = "Alerta de Color";
						mail.Body = "A las " + momento + " el Color detectado fue de " + valor.ToString() + ". Se ha detectado una anomalía que representa un indicio de la enfermedad de la roya amarilla en su cafeto. Por favor, acercarse a verificar el estado de la planta.";

					}

					mail.IsBodyHtml = true;

					using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
					{
						smtp.Credentials = new NetworkCredential("funuser535@gmail.com", "cvuwjihlqscbuwnv");
						smtp.EnableSsl = true;
						smtp.Send(mail);
					}
				}
			}
			catch (Exception ex)
			{

			}


		}

		//      public async Task UpdateMinMax(int id, MinMaxUpdateDto minmax)
		//      {
		//	var query = "UPDATE [dbo].[TemperaturaMaxMin] SET minimo = @Minimo, maximo = @Maximo WHERE Id = @Id";

		//	var parameters = new DynamicParameters();
		//	parameters.Add("Id", id, DbType.Int32);
		//	parameters.Add("Minimo", minmax.Minimo, DbType.String);
		//	parameters.Add("Maximo", minmax.Maximo, DbType.String);

		//	using (var connection = _context.CreateConnection())
		//	{
		//		await connection.ExecuteAsync(query, parameters);
		//	}
		//}

		public async Task InitCorreo(String email)
		{

			using (var cnn = _context.CreateConnection())
			{
				string query = "INSERT INTO [dbo].[InitEmail2](switches, correo, tipo) VALUES (@Switches, @Correo, @Tipo)";

				cnn.Execute(query,
					new[]
					{
							new {Switches = 0, Correo = email, Tipo = "temperatura"},
							new {Switches = 0, Correo = email, Tipo = "humedad"},
							new {Switches = 0, Correo = email, Tipo = "ph"},
							new {Switches = 0, Correo = email, Tipo = "color"}
					});
			}
		}

		public async Task InitTemperatura(String email)
		{
			//var number = 0;
			var check = 1;

			//Query que lee los ultimos valores registrados en las ultimas 3 horas, el horario esta en UTC
			var query = "SELECT id, temperatura, tiempo FROM [dbo].[devicesync] WHERE tiempo BETWEEN DATEADD(HOUR, -100, GETUTCDATE()) AND GETUTCDATE()";

			var query2 = "SELECT * FROM [dbo].[UltimaUmbralMaxTemperatura]";

			var query3 = "SELECT * FROM [dbo].[UltimaUmbralMinTemperatura]";

			var query4 = "SELECT * FROM [dbo].[InitEmail2] WHERE tipo = @tipo AND correo = @correo";

			while (check == 1)
			{
				using (var connection = _context.CreateConnection())
				{
					var initTemp = await connection.QuerySingleOrDefaultAsync<InitIot>(query4,
						new
						{
							tipo = "temperatura",
							correo = email
						});

					var umbralMaxTemp = await connection.QuerySingleOrDefaultAsync<UmbralMaxTemp>(query2);
					var umbralMinTemp = await connection.QuerySingleOrDefaultAsync<UmbralMinTemp>(query3);

					List<TemperaturaTTN> list = new List<TemperaturaTTN>();
					list = (List<TemperaturaTTN>)await connection.QueryAsync<TemperaturaTTN>(query);
					foreach (var x in list)
					{
						if (x.Temperatura < umbralMinTemp.Ultimo || x.Temperatura > umbralMaxTemp.Ultimo)
						{
							DateTime dt = DateTime.Parse(x.Tiempo);
							DateTime currentTime = TimeZoneInfo.ConvertTime(dt, TimeZoneInfo.FindSystemTimeZoneById("SA Pacific Standard Time"));

							SendMail(email, 1, x.Temperatura, currentTime.ToString("hh:mm tt"));
						}
					}
					check = initTemp.Switches;
					connection.Close();
				}
				//Tiempo en el que se volverá a ejecutar la funcion de arriba -> Linea 229
				await Task.Delay(1000 * 10);
			}
		}

		public async Task UpdateSwitchTemperatura(InitTempDto initTemp)
		{
			var query = "UPDATE [dbo].[InitEmail] SET switches = @Switches WHERE Id = @Id";

			var parameters = new DynamicParameters();
			parameters.Add("Id", 1, DbType.Int32);
			parameters.Add("Switches", initTemp.Switches, DbType.Int32);

			using (var connection = _context.CreateConnection())
			{
				await connection.ExecuteAsync(query, parameters);
			}
		}

		public async Task InitHumedad(String email)
		{
			//var number = 0;
			var check = 1;

			var query = "SELECT id, humedad, tiempo FROM [dbo].[devicesync] WHERE tiempo BETWEEN DATEADD(HOUR, -1, GETUTCDATE()) AND GETUTCDATE()";

			var query2 = "SELECT * FROM [dbo].[UltimaUmbralMaxHumedad]";

			var query3 = "SELECT * FROM [dbo].[UltimaUmbralMinHumedad]";

			var query4 = "SELECT * FROM [dbo].[InitEmail2] WHERE tipo = @tipo AND correo = @correo";

			while (check == 1)
			{
				using (var connection = _context.CreateConnection())
				{
					var initHum = await connection.QuerySingleOrDefaultAsync<InitIot>(query4,
						new
						{
							tipo = "humedad",
							correo = email
						});
					var umbralMaxHum = await connection.QuerySingleOrDefaultAsync<UmbralMaxHum>(query2);
					var umbralMinHum = await connection.QuerySingleOrDefaultAsync<UmbralMinHum>(query3);

					List<HumedadTTN> list = new List<HumedadTTN>();
					list = (List<HumedadTTN>)await connection.QueryAsync<HumedadTTN>(query);
					foreach (var x in list)
					{
						if (x.Humedad < umbralMinHum.Ultimo || x.Humedad > umbralMaxHum.Ultimo)
						{
							DateTime dt = DateTime.Parse(x.Tiempo);
							DateTime currentTime = TimeZoneInfo.ConvertTime(dt, TimeZoneInfo.FindSystemTimeZoneById("SA Pacific Standard Time"));

							SendMail(email, 2, x.Humedad, currentTime.ToString("hh:mm tt"));
						}
					}
					check = initHum.Switches;
					connection.Close();
				}
				//Interlocked.Increment(ref number);
				//System.Console.WriteLine($"Worker printing number: {number}");
				await Task.Delay(1000 * 10);
			}
		}

		public async Task UpdateSwitchHumedad(InitHumDto initHum)
		{
			var query = "UPDATE [dbo].[InitEmail] SET switches = @Switches WHERE Id = @Id";

			var parameters = new DynamicParameters();
			parameters.Add("Id", 2, DbType.Int32);
			parameters.Add("Switches", initHum.Switches, DbType.Int32);

			using (var connection = _context.CreateConnection())
			{
				await connection.ExecuteAsync(query, parameters);
			}
		}

		public async Task InitPh(String email)
		{
			//var number = 0;
			var check = 1;

			//De tiempo actual a "n" horas atrás
			var query = "SELECT id, ph, tiempo FROM [dbo].[devicesync] WHERE tiempo BETWEEN DATEADD(HOUR, -100, GETUTCDATE()) AND GETUTCDATE()";

			var query2 = "SELECT * FROM [dbo].[UltimaUmbralMaxPh]";

			var query3 = "SELECT * FROM [dbo].[UltimaUmbralMinPh]";

			var query4 = "SELECT * FROM [dbo].[InitEmail2] WHERE tipo = @tipo AND correo = @correo";

			while (check == 1)
			{
				using (var connection = _context.CreateConnection())
				{
					var initPh = await connection.QuerySingleOrDefaultAsync<InitIot>(query4,
						new
						{
							tipo = "ph",
							correo = email
						});
					var umbralMaxPh = await connection.QuerySingleOrDefaultAsync<UmbralMaxPh>(query2);
					var umbralMinPh = await connection.QuerySingleOrDefaultAsync<UmbralMinPh>(query3);

					List<PhTTN> list = new List<PhTTN>();
					list = (List<PhTTN>)await connection.QueryAsync<PhTTN>(query);
					foreach (var x in list)
					{
						if (x.Ph < umbralMinPh.Ultimo || x.Ph > umbralMaxPh.Ultimo)
						{
							DateTime dt = DateTime.Parse(x.Tiempo);
							DateTime currentTime = TimeZoneInfo.ConvertTime(dt, TimeZoneInfo.FindSystemTimeZoneById("SA Pacific Standard Time"));

							SendMail(email, 3, x.Ph, currentTime.ToString("hh:mm tt"));
						}	
					}
					check = initPh.Switches;
					connection.Close();
				}
				//Tiempo de ejecución del loop 
				await Task.Delay(1000 * 10);
			}
		}

		public async Task UpdateSwitchPh(InitPhDto initPh)
		{
			var query = "UPDATE [dbo].[InitEmail] SET switches = @Switches WHERE Id = @Id";

			var parameters = new DynamicParameters();
			parameters.Add("Id", 3, DbType.Int32);
			parameters.Add("Switches", initPh.Switches, DbType.Int32);

			using (var connection = _context.CreateConnection())
			{
				await connection.ExecuteAsync(query, parameters);
			}
		}

		public async Task InitColor(String email)
		{
			//var number = 0;
			var check = 1;

			//De tiempo actual a "n" horas atrás
			var query = "SELECT id, color, tiempo FROM [dbo].[device_color] WHERE tiempo BETWEEN DATEADD(HOUR, -1, GETUTCDATE()) AND GETUTCDATE()";

			var query2 = "SELECT * FROM [dbo].[UltimaUmbralMaxColor]";

			var query3 = "SELECT * FROM [dbo].[UltimaUmbralMinColor]";

			var query4 = "SELECT * FROM [dbo].[InitEmail2] WHERE tipo = @tipo AND correo = @correo";

			while (check == 1)
			{
				using (var connection = _context.CreateConnection())
				{
					var initColor = await connection.QuerySingleOrDefaultAsync<InitIot>(query4,
						new
						{
							tipo = "color",
							correo = email
						});
					var umbralMaxColor = await connection.QuerySingleOrDefaultAsync<UmbralMaxColor>(query2);
					var umbralMinColor = await connection.QuerySingleOrDefaultAsync<UmbralMinColor>(query3);

					List<ColorTTN> list = new List<ColorTTN>();
					list = (List<ColorTTN>)await connection.QueryAsync<ColorTTN>(query);
					foreach (var x in list)
					{
						if (x.Color < umbralMinColor.Ultimo || x.Color > umbralMaxColor.Ultimo)
						{
							DateTime dt = DateTime.Parse(x.Tiempo);
							DateTime currentTime = TimeZoneInfo.ConvertTime(dt, TimeZoneInfo.FindSystemTimeZoneById("SA Pacific Standard Time"));

							SendMail(email, 4, x.Color, currentTime.ToString("hh:mm tt"));
						}
					}
					check = initColor.Switches;
					connection.Close();
				}
				//Tiempo de ejecución del loop 
				await Task.Delay(1000 * 10);
			}
		}

		public async Task UpdateSwitchColor(InitColorDto initColor)
		{
			var query = "UPDATE [dbo].[InitEmail] SET switches = @Switches WHERE Id = @Id";

			var parameters = new DynamicParameters();
			parameters.Add("Id", 4, DbType.Int32);
			parameters.Add("Switches", initColor.Switches, DbType.Int32);

			using (var connection = _context.CreateConnection())
			{
				await connection.ExecuteAsync(query, parameters);
			}
		}

		public async Task UpdateSwitches(UpdateSwitchesDTO updateSwitchesDTO)
		{
			var query = "UPDATE [dbo].[InitEmail2] SET switches = @Switches WHERE Correo = @Correo AND Tipo = @Tipo";

			var parameters = new DynamicParameters();
			parameters.Add("Switches", updateSwitchesDTO.Switches, DbType.Int32);
			parameters.Add("Correo", updateSwitchesDTO.Correo, DbType.String);
			parameters.Add("Tipo", updateSwitchesDTO.Tipo, DbType.String);

			using (var connection = _context.CreateConnection())
			{
				await connection.ExecuteAsync(query, parameters);
			}
		}
	}
}
