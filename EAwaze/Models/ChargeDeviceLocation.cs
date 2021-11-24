namespace EAwaze.Models
{
	public class ChargeDeviceLocation
	{
		public string Latitude { get; set; }
		public string Longitude { get; set; }
		public Address Address { get; set; }
		public object LocationShortDescription { get; set; }
		public string LocationLongDescription { get; set; }
	}
}