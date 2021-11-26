using EAwaze.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace EAwaze.Repositories
{
	public class ChargingStationRepository : IChargingStationRepository
	{
		public async Task<List<ChargingStation>> GetAllChargeDevicesAsync(string latitude, string longitude, int limit, string format = "json")
		{
			var stations = new List<ChargingStation>();
			try
			{
				using var httpClient = new HttpClient();
				httpClient.BaseAddress =
					new Uri(
						$"https://chargepoints.dft.gov.uk/api/retrieve/registry/format/{format}/");
				var response = await httpClient.GetAsync($"lat/{latitude}/long/{longitude}/dist/20/limit/{limit}");

				if (response.IsSuccessStatusCode)
				{
					var responseContent = await response.Content.ReadAsStringAsync();
					var chargeDeviceResponse = JsonSerializer.Deserialize<ChargeDeviceResponse>(responseContent);

					if(chargeDeviceResponse?.ChargeDevice != null)
					{
						stations =  chargeDeviceResponse.ChargeDevice.Distinct().Select(x => new ChargingStation
						{
							Name = x.ChargeDeviceName,
							OperatorName = x.DeviceOwner != null ? x.DeviceOwner.OrganisationName : string.Empty,
							Address = x.ChargeDeviceLocation?.Address != null ? new Address
							{
								Thoroughfare = string.IsNullOrWhiteSpace(x.ChargeDeviceLocation.Address.Thoroughfare) ?  x.ChargeDeviceLocation.Address.Street ?? "First Street" : x.ChargeDeviceLocation.Address.Thoroughfare,								
								County = x.ChargeDeviceLocation.Address.County,
								Country = "United Kingdom",
								PostCode = x.ChargeDeviceLocation.Address.PostCode
							} : null,
							Latitude = x.ChargeDeviceLocation != null ?  x.ChargeDeviceLocation.Latitude : string.Empty,
							Longitude = x.ChargeDeviceLocation != null ?  x.ChargeDeviceLocation.Longitude : string.Empty,
							Status = x.ChargeDeviceStatus,
							PaymentInformation = GetChargingCost(x.DeviceOwner != null ? x.DeviceOwner.OrganisationName : string.Empty),
							Connectors = x.Connector
						}).GroupBy(x=>x.Name).Select(x=>x.First()).ToList();
					}
				}
				
				return stations;
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		private string GetChargingCost(string operatorName)
        {
			var cost = string.Empty;
            switch (operatorName)
            {
				case "EV Solutions":
					cost = "https://www.geniepoint.co.uk/ds";
					break;
				case "Osprey":
					cost = "https://ospreycharging.co.uk/";
					break;
				default:
					cost = "https://ospreycharging.co.uk/";
					break;
			}

			return cost;
        }
	}

	public class ChargingStation
	{
		public string Name { get; set; }

		public string OperatorName { get; set; }

		public Address Address { get; set; }

		public IList<Connector> Connectors { get; set; }

		public string PaymentInformation { get; set; }

		public string Latitude { get; set; }

		public string Longitude { get; set; }

		public string Status { get; set; }
	}
}