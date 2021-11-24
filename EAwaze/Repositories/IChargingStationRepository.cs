using System.Collections.Generic;
using System.Threading.Tasks;
using EAwaze.Models;

namespace EAwaze.Repositories
{
	public interface IChargingStationRepository
	{
		Task<List<ChargeDevice>> GetAllChargeDevicesAsync(string postCode, int limit, string format = "json");
	}
}