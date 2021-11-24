namespace EAwaze.Models
{
	public class Address
	{
		public object SubBuildingName { get; set; }
		public string BuildingName { get; set; }
		public string BuildingNumber { get; set; }
		public string Thoroughfare { get; set; }
		public string Street { get; set; }
		public object DoubleDependantLocality { get; set; }
		public object DependantLocality { get; set; }
		public string PostTown { get; set; }
		public string County { get; set; }
		public string PostCode { get; set; }
		public string Country { get; set; }
		public string UPRN { get; set; }
	}
}