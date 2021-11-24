namespace EAwaze.Models
{
	public class Connector
	{
		public string ConnectorId { get; set; }
		public string ConnectorType { get; set; }
		public string RatedOutputkW { get; set; }
		public string RatedOutputVoltage { get; set; }
		public string RatedOutputCurrent { get; set; }
		public string ChargeMethod { get; set; }
		public string ChargeMode { get; set; }
		public string ChargePointStatus { get; set; }
		public string TetheredCable { get; set; }
		public string Information { get; set; }
		public string Validated { get; set; }
	}
}