using EAwaze.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace EAwaze.Repositories
{
	public class ChargingStationRepository : IChargingStationRepository
	{
		public async Task<List<ChargeDevice>> GetAllChargeDevicesAsync(string latitude, string longitude, int limit, string format = "json")
		{
			try
			{
				using (var httpClient = new HttpClient())
				{
					httpClient.BaseAddress =
						new Uri(
							$"https://chargepoints.dft.gov.uk/api/retrieve/registry/format/{format}/");
					var response = await httpClient.GetAsync($"lat/{latitude}/long/{longitude}/limit/10");
					var responseContent = await response.Content.ReadAsStringAsync();
					var chargeDeviceResponse = JsonSerializer.Deserialize<ChargeDeviceResponse>(responseContent);
				}
				return new List<ChargeDevice>();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}
	}
}