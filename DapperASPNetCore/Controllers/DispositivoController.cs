using DapperASPNetCore.Contracts;
using DapperASPNetCore.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperASPNetCore.Controllers
{
	[Route("api/iot")]
	[ApiController]
	public class DispositivoController : ControllerBase
	{
		private readonly IDispositivoRepository _companyRepo;

		public DispositivoController(IDispositivoRepository companyRepo)
		{
			_companyRepo = companyRepo;
		}

		//[HttpGet]
		//[Route("all")]
		//public async Task<IActionResult> GetCompanies()
		//{
		//	try
		//	{
		//		var companies = await _companyRepo.GetCompanies();
		//		return Ok(companies);
		//	}
		//	catch (Exception ex)
		//	{
		//		//log error
		//		return StatusCode(500, ex.Message);
		//	}
		//}

		//[HttpGet]
		//[Route("humedad/{email}")]
		//public async Task<IActionResult> GetHumedad(string email)
		//{
		//	try
		//	{
		//		var humedad = await _companyRepo.GetHumedad(email);
		//		return Ok(humedad);
		//	}
		//	catch (Exception ex)
		//	{
		//		//log error
		//		return StatusCode(500, ex.Message);
		//	}
		//}

		//[HttpGet]
		//[Route("ph/{email}")]
		//public async Task<IActionResult> GetPh(string email)
		//{
		//	try
		//	{
		//		var ph = await _companyRepo.GetPh(email);
		//		return Ok(ph);
		//	}
		//	catch (Exception ex)
		//	{
		//		//log error
		//		return StatusCode(500, ex.Message);
		//	}
		//}

		//[HttpGet]
		//[Route("temperatura/{email}")]
		//public async Task<IActionResult> GetTemperatura(string email)
		//{
		//	try
		//	{
		//		var temperatura = await _companyRepo.GetTemperatura(email);
		//		return Ok(temperatura);
		//	}
		//	catch (Exception ex)
		//	{
		//		//log error
		//		return StatusCode(500, ex.Message);
		//	}
		//}

		//[HttpGet]
		//[Route("minmax")]
		//public async Task<IActionResult> GetMinMax()
		//{
		//	try
		//	{
		//		var minmax = await _companyRepo.GetMinMax();
		//		return Ok(minmax);
		//	}
		//	catch (Exception ex)
		//	{
		//		//log error
		//		return StatusCode(500, ex.Message);
		//	}
		//}

		//[HttpGet]
		//[Route("minmax/{id}")]
		//public async Task<IActionResult> GetMinMaxById(int id)
		//{
		//	try
		//	{
		//		var minmaxById = await _companyRepo.GetMinMaxById(id);
		//		return Ok(minmaxById);
		//	}
		//	catch (Exception ex)
		//	{
		//		//log error
		//		return StatusCode(500, ex.Message);
		//	}
		//}

		//[HttpPut]
		//[Route("minmax/{id}")]
		//public async Task<IActionResult> UpdateMinMax(int id, MinMaxUpdateDto minmax)
		//{
		//	try
		//	{
		//		await _companyRepo.UpdateMinMax(id, minmax);
		//		return NoContent();
		//	}
		//	catch (Exception ex)
		//	{
		//		//log error
		//		return StatusCode(500, ex.Message);
		//	}
		//}

		[HttpPost]
		[Route("init/correo/{email}")]
		public async Task InitCorreo(string email)
		{
			try
			{
				await _companyRepo.InitCorreo(email);

			}
			catch (Exception ex)
			{
				//log error
				StatusCode(500, ex.Message);
			}
		}

		[HttpPut]
		[Route("update/switches")]
		public async Task UpdateSwitches(UpdateSwitchesDTO updateSwitchesDTO)
		{
			try
			{
				await _companyRepo.UpdateSwitches(updateSwitchesDTO);

			}
			catch (Exception ex)
			{
				//log error
				StatusCode(500, ex.Message);
			}
		}

		[HttpGet]
		[Route("init/temp/{email}")]
		public async Task InitTemp(String email)
        {
			try
			{
				await _companyRepo.InitTemperatura(email);
			
			}
            catch (Exception ex)
			{
				//log error
				StatusCode(500, ex.Message);
			}
		}

		[HttpPut]
		[Route("update/switches/temp")]
		public async Task UpdateSwitchTemp(InitTempDto initTemp)
		{
			try
			{
				await _companyRepo.UpdateSwitchTemperatura(initTemp);

			}
			catch (Exception ex)
			{
                //log error
                StatusCode(500, ex.Message);
            }
		}

		[HttpGet]
		[Route("init/hum/{email}")]
		public async Task InitHum(String email)
		{
			try
			{
				await _companyRepo.InitHumedad(email);

			}
			catch (Exception ex)
			{
				//log error
				StatusCode(500, ex.Message);
			}
		}

		[HttpPut]
		[Route("update/switches/hum")]
		public async Task UpdateSwitchHum(InitHumDto initHum)
		{
			try
			{
				await _companyRepo.UpdateSwitchHumedad(initHum);

			}
			catch (Exception ex)
			{
				//log error
				StatusCode(500, ex.Message);
			}
		}

		[HttpGet]
		[Route("init/ph/{email}")]
		public async Task InitPh(String email)
		{
			try
			{
				await _companyRepo.InitPh(email);

			}
			catch (Exception ex)
			{
				//log error
				StatusCode(500, ex.Message);
			}
		}

		[HttpPut]
		[Route("update/switches/ph")]
		public async Task UpdateSwitchPh(InitPhDto initPh)
		{
			try
			{
				await _companyRepo.UpdateSwitchPh(initPh);

			}
			catch (Exception ex)
			{
				//log error
				StatusCode(500, ex.Message);
			}
		}

		[HttpGet]
		[Route("init/color/{email}")]
		public async Task InitColor(String email)
		{
			try
			{
				await _companyRepo.InitColor(email);

			}
			catch (Exception ex)
			{
				//log error
				StatusCode(500, ex.Message);
			}
		}

		[HttpPut]
		[Route("update/switches/color")]
		public async Task UpdateSwitchColor(InitColorDto initColor)
		{
			try
			{
				await _companyRepo.UpdateSwitchColor(initColor);

			}
			catch (Exception ex)
			{
				//log error
				StatusCode(500, ex.Message);
			}
		}
	}
}
