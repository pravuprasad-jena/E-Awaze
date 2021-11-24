using System.Collections.Generic;

namespace EAwaze.Models
{
	public class ChargeDevice
	{
		public string ChargeDeviceId { get; set; }
		public string ChargeDeviceRef { get; set; }
		public string ChargeDeviceName { get; set; }
		public object ChargeDeviceText { get; set; }
		public ChargeDeviceLocation ChargeDeviceLocation { get; set; }
		public string ChargeDeviceManufacturer { get; set; }
		public string ChargeDeviceModel { get; set; }
		public string PublishStatusID { get; set; }
		public string DateCreated { get; set; }
		public string DateUpdated { get; set; }
		public string Attribution { get; set; }
		public string DateDeleted { get; set; }
		public List<Connector> Connector { get; set; }
		public DeviceOwner DeviceOwner { get; set; }
		public DeviceController DeviceController { get; set; }
		public List<object> DeviceAccess { get; set; }
		public string DeviceNetworks { get; set; }
		public string ChargeDeviceStatus { get; set; }
		public string PublishStatus { get; set; }
		public string DeviceValidated { get; set; }
		public string RecordModerated { get; set; }
		public string RecordLastUpdated { get; set; }
		public string RecordLastUpdatedBy { get; set; }
		public bool PaymentRequiredFlag { get; set; }
		public string PaymentDetails { get; set; }
		public bool SubscriptionRequiredFlag { get; set; }
		public string SubscriptionDetails { get; set; }
		public bool ParkingFeesFlag { get; set; }
		public string ParkingFeesDetails { get; set; }
		public string ParkingFeesUrl { get; set; }
		public bool AccessRestrictionFlag { get; set; }
		public string AccessRestrictionDetails { get; set; }
		public bool PhysicalRestrictionFlag { get; set; }
		public string PhysicalRestrictionText { get; set; }
		public bool OnStreetFlag { get; set; }
		public string LocationType { get; set; }
		public object Bearing { get; set; }
		public bool Accessible24Hours { get; set; }
	}
}