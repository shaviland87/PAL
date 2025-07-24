using MavLinkPal.Attributes;

namespace MavLinkPal.MavLinkProtocol
{
    /// <summary>
    /// EKF Status message including flags and variances.
    /// </summary>
    public class EkfStatusReport : Message
    {
        /// <summary>
        /// Velocity variance
        /// </summary>
        [Metadata]
        public float VelocityVariance { get; set; }

        /// <summary>
        /// Horizontal Position variance
        /// </summary>
        [Metadata]
        public float PosHorizVariance { get; set; }

        /// <summary>
        /// Vertical Position variance
        /// </summary>
        [Metadata]
        public float PosVertVariance { get; set; }

        /// <summary>
        /// Compass variance
        /// </summary>
        [Metadata]
        public float CompassVariance { get; set; }

        /// <summary>
        /// Terrain Altitude variance
        /// </summary>
        [Metadata]
        public float TerrainAltVariance { get; set; }

        /// <summary>
        /// Flags
        /// </summary>
        [Metadata]
        public UInt16 Flags { get; set; }

        public EkfStatusReport()
        {
            Id = 193;
            Crc = 71;
            PayloadLength = 26 - 4;
        }

        public override void Deserialize(BinaryReader br)
        {
            VelocityVariance = br.ReadSingle();
            PosHorizVariance = br.ReadSingle();
            PosVertVariance = br.ReadSingle();
            CompassVariance = br.ReadSingle();
            TerrainAltVariance = br.ReadSingle();
            Flags = br.ReadUInt16();
            // +4 extended
        }

        public override void Serialize(BinaryWriter bw)
        {
            bw.Write(VelocityVariance);
            bw.Write(PosHorizVariance);
            bw.Write(PosVertVariance);
            bw.Write(CompassVariance);
            bw.Write(TerrainAltVariance);
            bw.Write(Flags);
        }
    }
}