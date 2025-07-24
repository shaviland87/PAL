using MavLinkPal.Attributes;

namespace MavLinkPal.MavLinkProtocol
{
    /// <summary>
    /// The general system state. If the system is following the MAVLink standard, the system state is mainly
    /// defined by three orthogonal states/modes: The system mode, which is either LOCKED (motors shut down and locked),
    /// MANUAL (system under RC control), GUIDED (system with autonomous position control, position setpoint
    /// controlled manually) or AUTO (system guided by path/waypoint planner). The NAV_MODE defined the current
    /// flight state: LIFTOFF (often an open-loop maneuver), LANDING, WAYPOINTS or VECTOR. This represents the
    /// internal navigation state machine. The system status shows whether the system is currently active or not
    /// and if an emergency occurred. During the CRITICAL and EMERGENCY states the MAV is still considered to be
    /// active, but should start emergency procedures autonomously. After a failure occurred it should first move
    /// from active to critical to allow manual intervention and then move to emergency after a certain timeout.
    /// </summary>
    public class SysStatus : Message
    {
        /// <summary>
        /// Bitmask showing which onboard controllers and sensors are present. Value of 0: not present. Value of 1: present. Indices defined by ENUM MAV_SYS_STATUS_SENSOR
        /// </summary>
        [Metadata]
        public MavSysStatusSensor OnboardControlSensorsPresent { get; set; }

        /// <summary>
        /// Bitmask showing which onboard controllers and sensors are enabled:  Value of 0: not enabled. Value of 1: enabled. Indices defined by ENUM MAV_SYS_STATUS_SENSOR
        /// </summary>
        [Metadata]
        public MavSysStatusSensor OnboardControlSensorsEnabled { get; set; }

        /// <summary>
        /// Bitmask showing which onboard controllers and sensors are operational or have an error:  Value of 0: not enabled. Value of 1: enabled. Indices defined by ENUM MAV_SYS_STATUS_SENSOR
        /// </summary>
        [Metadata]
        public MavSysStatusSensor OnboardControlSensorsHealth { get; set; }

        /// <summary>
        /// Maximum usage in percent of the mainloop time, (0%: 0, 100%: 1000) should be always below 1000
        /// </summary>
        [Metadata(Unit = "d%")]
        public ushort Load { get; set; }

        /// <summary>
        /// Battery voltage, in millivolts (1 = 1 millivolt)
        /// </summary>
        [Metadata(Unit = "mV")]
        public ushort VoltageBattery { get; set; }

        /// <summary>
        /// Battery current, in 10*milliamperes (1 = 10 milliampere), -1: autopilot does not measure the current
        /// </summary>
        [Metadata(Unit = "cA")]
        public short CurrentBattery { get; set; }

        /// <summary>
        /// Communication drops in percent, (0%: 0, 100%: 10'000), (UART, I2C, SPI, CAN), dropped packets on all links (packets that were corrupted on reception on the MAV)
        /// </summary>
        [Metadata(Unit = "c%")]
        public ushort DropRateComm { get; set; }

        /// <summary>
        /// Communication errors (UART, I2C, SPI, CAN), dropped packets on all links (packets that were corrupted on reception on the MAV)
        /// </summary>
        [Metadata]
        public ushort ErrorsComm { get; set; }

        /// <summary>
        /// Autopilot-specific errors
        /// </summary>
        [Metadata]
        public ushort ErrorsCount1 { get; set; }

        /// <summary>
        /// Autopilot-specific errors
        /// </summary>
        [Metadata]
        public ushort ErrorsCount2 { get; set; }

        /// <summary>
        /// Autopilot-specific errors
        /// </summary>
        [Metadata]
        public ushort ErrorsCount3 { get; set; }

        /// <summary>
        /// Autopilot-specific errors
        /// </summary>
        [Metadata]
        public ushort ErrorsCount4 { get; set; }

        /// <summary>
        /// Remaining battery energy: (0%: 0, 100%: 100), -1: autopilot estimate the remaining battery
        /// </summary>
        [Metadata(Unit = "%")]
        public sbyte BatteryRemaining { get; set; }

        public SysStatus()
        {
            Id = 1;
            Crc = 124;
            PayloadLength = 43 - 12;
        }

        public override void Deserialize(BinaryReader br)
        {
            OnboardControlSensorsPresent = (MavSysStatusSensor)br.ReadUInt32();
            OnboardControlSensorsEnabled = (MavSysStatusSensor)br.ReadUInt32();
            OnboardControlSensorsHealth = (MavSysStatusSensor)br.ReadUInt32();
            Load = br.ReadUInt16();
            VoltageBattery = br.ReadUInt16();
            CurrentBattery = br.ReadInt16();
            DropRateComm = br.ReadUInt16();
            ErrorsComm = br.ReadUInt16();
            ErrorsCount1 = br.ReadUInt16();
            ErrorsCount2 = br.ReadUInt16();
            ErrorsCount3 = br.ReadUInt16();
            ErrorsCount4 = br.ReadUInt16();
            BatteryRemaining = br.ReadSByte();
            // +12 extended
        }

        public override void Serialize(BinaryWriter bw)
        {
            bw.Write((uint)OnboardControlSensorsPresent);
            bw.Write((uint)OnboardControlSensorsEnabled);
            bw.Write((uint)OnboardControlSensorsHealth);
            bw.Write(Load);
            bw.Write(VoltageBattery);
            bw.Write(CurrentBattery);
            bw.Write(DropRateComm);
            bw.Write(ErrorsComm);
            bw.Write(ErrorsCount1);
            bw.Write(ErrorsCount2);
            bw.Write(ErrorsCount3);
            bw.Write(ErrorsCount4);
            bw.Write(BatteryRemaining);
        }
    }
}