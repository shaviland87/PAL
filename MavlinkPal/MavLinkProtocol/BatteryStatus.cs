using MavLinkPal.Attributes;

namespace MavLinkPal.MavLinkProtocol
{
    /// <summary>
    /// Battery information.
    /// </summary>
    public class BatteryStatus : Message
    {
        /// <summary>
        /// Consumed charge, in milliampere hours (1 = 1 mAh), -1: autopilot does not provide mAh consumption estimate
        /// </summary>
        [Metadata(Unit = "mAh")]
        public Int32 CurrentConsumed { get; set; }

        /// <summary>
        /// Consumed energy, in 100*Joules (intergrated U*I*dt)  (1 = 100 Joule), -1: autopilot does not provide energy consumption estimate
        /// </summary>
        [Metadata(Unit = "hJ")]
        public Int32 EnergyConsumed { get; set; }

        /// <summary>
        /// Temperature of the battery in centi-degrees celsius. INT16_MAX for unknown temperature.
        /// </summary>
        [Metadata(Unit = "cdegC")]
        public Int16 Temperature { get; set; }

        /// <summary>
        /// Battery voltage of cells, in millivolts (1 = 1 millivolt). Cells above the valid cell count for this battery should have the UINT16_MAX value.
        /// </summary>
        [Metadata(Unit = "mV")]
        public UInt16 Voltage1 { get; set; }

        /// <summary>
        /// Battery voltage of cells, in millivolts (1 = 1 millivolt). Cells above the valid cell count for this battery should have the UINT16_MAX value.
        /// </summary>
        [Metadata(Unit = "mV")]
        public UInt16 Voltage2 { get; set; }

        /// <summary>
        /// Battery voltage of cells, in millivolts (1 = 1 millivolt). Cells above the valid cell count for this battery should have the UINT16_MAX value.
        /// </summary>
        [Metadata(Unit = "mV")]
        public UInt16 Voltage3 { get; set; }

        /// <summary>
        /// Battery voltage of cells, in millivolts (1 = 1 millivolt). Cells above the valid cell count for this battery should have the UINT16_MAX value.
        /// </summary>
        [Metadata(Unit = "mV")]
        public UInt16 Voltage4 { get; set; }

        /// <summary>
        /// Battery voltage of cells, in millivolts (1 = 1 millivolt). Cells above the valid cell count for this battery should have the UINT16_MAX value.
        /// </summary>
        [Metadata(Unit = "mV")]
        public UInt16 Voltage5 { get; set; }

        /// <summary>
        /// Battery voltage of cells, in millivolts (1 = 1 millivolt). Cells above the valid cell count for this battery should have the UINT16_MAX value.
        /// </summary>
        [Metadata(Unit = "mV")]
        public UInt16 Voltage6 { get; set; }

        /// <summary>
        /// Battery voltage of cells, in millivolts (1 = 1 millivolt). Cells above the valid cell count for this battery should have the UINT16_MAX value.
        /// </summary>
        [Metadata(Unit = "mV")]
        public UInt16 Voltage7 { get; set; }

        /// <summary>
        /// Battery voltage of cells, in millivolts (1 = 1 millivolt). Cells above the valid cell count for this battery should have the UINT16_MAX value.
        /// </summary>
        [Metadata(Unit = "mV")]
        public UInt16 Voltage8 { get; set; }

        /// <summary>
        /// Battery voltage of cells, in millivolts (1 = 1 millivolt). Cells above the valid cell count for this battery should have the UINT16_MAX value.
        /// </summary>
        [Metadata(Unit = "mV")]
        public UInt16 Voltage9 { get; set; }

        /// <summary>
        /// Battery voltage of cells, in millivolts (1 = 1 millivolt). Cells above the valid cell count for this battery should have the UINT16_MAX value.
        /// </summary>
        [Metadata(Unit = "mV")]
        public UInt16 Voltage10 { get; set; }

        /// <summary>
        /// Battery current, in 10*milliamperes (1 = 10 milliampere), -1: autopilot does not measure the current
        /// </summary>
        [Metadata(Unit = "cA")]
        public Int16 CurrentBattery { get; set; }

        /// <summary>
        /// Battery ID
        /// </summary>
        [Metadata]
        public byte BatteryId { get; set; }

        /// <summary>
        /// Function of the battery
        /// </summary>
        [Metadata]
        public byte BatteryFunction { get; set; }

        /// <summary>
        /// Type (chemistry) of the battery
        /// </summary>
        [Metadata]
        public byte BatteryType { get; set; }

        /// <summary>
        /// Remaining battery energy: (0%: 0, 100%: 100), -1: autopilot does not estimate the remaining battery
        /// </summary>
        [Metadata(Unit = "%")]
        public SByte BatteryRemaining { get; set; }

        public BatteryStatus()
        {
            Id = 147;
            Crc = 154;
            PayloadLength = 48 - 12;
        }

        public override void Deserialize(BinaryReader br)
        {
            CurrentConsumed = br.ReadInt32();
            EnergyConsumed = br.ReadInt32();
            Temperature = br.ReadInt16();
            Voltage1 = br.ReadUInt16();
            Voltage2 = br.ReadUInt16();
            Voltage3 = br.ReadUInt16();
            Voltage4 = br.ReadUInt16();
            Voltage5 = br.ReadUInt16();
            Voltage6 = br.ReadUInt16();
            Voltage7 = br.ReadUInt16();
            Voltage8 = br.ReadUInt16();
            Voltage9 = br.ReadUInt16();
            Voltage10 = br.ReadUInt16();
            CurrentBattery = br.ReadInt16();
            BatteryId = br.ReadByte();
            BatteryFunction = br.ReadByte();
            BatteryType = br.ReadByte();
            BatteryRemaining = br.ReadSByte();
            // +12 extended
        }

        public override void Serialize(BinaryWriter bw)
        {
            bw.Write(CurrentConsumed);
            bw.Write(EnergyConsumed);
            bw.Write(Temperature);
            bw.Write(Voltage1);
            bw.Write(Voltage2);
            bw.Write(Voltage3);
            bw.Write(Voltage4);
            bw.Write(Voltage5);
            bw.Write(Voltage6);
            bw.Write(Voltage7);
            bw.Write(Voltage8);
            bw.Write(Voltage9);
            bw.Write(Voltage10);
            bw.Write(CurrentBattery);
            bw.Write(BatteryId);
            bw.Write(BatteryFunction);
            bw.Write(BatteryType);
            bw.Write(BatteryRemaining);
        }
    }
}