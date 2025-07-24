using MavLinkPal.Attributes;

namespace MavLinkPal.MavLinkProtocol
{
    /// <summary>
    /// Metrics typically displayed on a HUD for fixed wing aircraft.
    /// </summary>
    public class VfrHud : Message
    {
        /// <summary>
        /// Current air speed in m/s
        /// </summary>
        [Metadata(Unit = "m/s")]
        public float AirSpeed { get; set; }

        /// <summary>
        /// Current ground speed in m/s
        /// </summary>
        [Metadata(Unit = "m/s")]
        public float GroundSpeed { get; set; }

        /// <summary>
        /// Current altitude (MSL), in meters
        /// </summary>
        [Metadata(Unit = "m")]
        public float Alt { get; set; }

        /// <summary>
        /// Current climb rate in meters/second
        /// </summary>
        [Metadata(Unit = "m/s")]
        public float Climb { get; set; }

        /// <summary>
        /// Current heading in degrees, in compass units (0..360, 0=north)
        /// </summary>
        [Metadata(Unit = "deg")]
        public Int16 Heading { get; set; }

        /// <summary>
        /// Current throttle setting in integer percent, 0 to 100
        /// </summary>
        [Metadata(Unit = "%")]
        public UInt16 Throttle { get; set; }

        public VfrHud()
        {
            Id = 74;
            Crc = 20;
            PayloadLength = 20;
        }

        public override void Deserialize(BinaryReader br)
        {
            AirSpeed = br.ReadSingle();
            GroundSpeed = br.ReadSingle();
            Alt = br.ReadSingle();
            Climb = br.ReadSingle();
            Heading = br.ReadInt16();
            Throttle = br.ReadUInt16();
        }

        public override void Serialize(BinaryWriter bw)
        {
            bw.Write(AirSpeed);
            bw.Write(GroundSpeed);
            bw.Write(Alt);
            bw.Write(Climb);
            bw.Write(Heading);
            bw.Write(Throttle);
        }
    }
}