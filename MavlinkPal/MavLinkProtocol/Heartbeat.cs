using MavLinkPal.Attributes;

namespace MavLinkPal.MavLinkProtocol
{
    /// <summary>
    /// The heartbeat message shows that a system is present and responding.
    /// The type of the MAV and Autopilot hardware allow the receiving system 
    /// to treat further messages from this system appropriate 
    /// (e.g. by laying out the user interface based on the autopilot).
    /// </summary>
    public class Heartbeat : Message
    {
        /// <summary>
        /// A bit field for use for autopilot-specific flags.
        /// </summary>
        [Metadata]
        public UInt32 CustomMode { get; set; }

        /// <summary>
        /// Type of the MAV, e.g. quadrotor, helicopter, etc., up to 15 types.
        /// </summary>
        [Metadata]
        public MavType Type { get; set; }

        /// <summary>
        /// Autopilot type/class.
        /// </summary>
        [Metadata]
        public MavAutopilot Autopilot { get; set; }

        /// <summary>
        /// System mode bit field.
        /// </summary>
        [Metadata]
        public MavModeFlag BaseMode { get; set; }

        /// <summary>
        /// System status flag.
        /// </summary>
        [Metadata]
        public MavState SystemStatus { get; set; }

        /// <summary>
        /// MAVLink version, not writable by user, gets added by protocol because of magic data type.
        /// </summary>
        [Metadata]
        public byte MavlinkVersion { get; set; }

        public Heartbeat()
        {
            Id = 0;
            Crc = 50;
            PayloadLength = 9;
        }

        public override void Serialize(BinaryWriter bw)
        {
            bw.Write(CustomMode);
            bw.Write((byte)Type);
            bw.Write((byte)Autopilot);
            bw.Write((byte)BaseMode);
            bw.Write((byte)SystemStatus);
            bw.Write(MavlinkVersion);
        }

        public override void Deserialize(BinaryReader br)
        {
            CustomMode = br.ReadUInt32();
            Type = (MavType)br.ReadByte();
            Autopilot = (MavAutopilot)br.ReadByte();
            BaseMode = (MavModeFlag)br.ReadByte();
            SystemStatus = (MavState)br.ReadByte();
            MavlinkVersion = br.ReadByte();
        }
    }
}
