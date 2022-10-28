using DapperASPNetCore.Dto;
using DapperASPNetCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperASPNetCore.Contracts
{
	public interface IDispositivoRepository
	{
		//public Task<IEnumerable<DipositivoTTN>> GetCompanies();
		//public Task<IEnumerable<TemperaturaTTN>> GetTemperatura(string email);
		//public Task<IEnumerable<HumedadTTN>> GetHumedad(string email);
		//public Task<IEnumerable<PhTTN>> GetPh(string email);
		//public Task<IEnumerable<MinMax>> GetMinMax();
		//public Task<MinMax> GetMinMaxById(int id);
		//public Task UpdateMinMax(int id, MinMaxUpdateDto minmax);
		public void SendMail(string email, int type, float valor, string momento);
		public Task InitTemperatura(String email);
		public Task UpdateSwitchTemperatura(InitTempDto initTemp);
		public Task InitCorreo(string email);
		public Task UpdateSwitches(UpdateSwitchesDTO updateSwitchesDTO);
		public Task InitHumedad(String email);
		public Task UpdateSwitchHumedad(InitHumDto initHum);
		public Task InitPh(String email);
		public Task UpdateSwitchPh(InitPhDto initPh);
		public Task InitColor(String email);
		public Task UpdateSwitchColor(InitColorDto initColor);
	}
}
