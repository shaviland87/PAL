using MavLinkPal.Attributes;

namespace MavLinkPal.MavLinkProtocol
{
    /// <summary>
    /// Wind estimation.
    /// </summary>
    public class Wind : Message
    {
        /// <summary>
        /// wind direction that wind is coming from (degrees)
        /// </summary>
        [Metadata(Unit = "deg")]
        public float Direction { get; set; }

        /// <summary>
        /// wind speed in ground plane (m/s)
        /// </summary>
        [Metadata(Unit = "m/s")]
        public float Speed { get; set; }

        /// <summary>
        /// vertical wind speed (m/s)
        /// </summary>
        [Metadata(Unit = "m/s")]
        public float SpeedZ { get; set; }

        public Wind()
        {
            Id = 168;
            Crc = 1;
            PayloadLength = 12;
        }

        public override void Deserialize(BinaryReader br)
        {
            Direction = br.ReadSingle();
            Speed = br.ReadSingle();
            SpeedZ = br.ReadSingle();
        }

        public override void Serialize(BinaryWriter bw)
        {
            bw.Write(Direction);
            bw.Write(Speed);
            bw.Write(SpeedZ);
        }
    }
}