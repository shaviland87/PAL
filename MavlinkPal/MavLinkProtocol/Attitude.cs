using MavLinkPal.Attributes;

namespace MavLinkPal.MavLinkProtocol
{
    /// <summary>
    /// The attitude in the aeronautical frame (right-handed, Z-down, X-front, Y-right).
    /// </summary>
    public class Attitude : Message
    {
        /// <summary>
        /// Timestamp (milliseconds since system boot)
        /// </summary>
        [Metadata(Unit = "ms")]
        public uint TimeBootMs { get; set; }

        /// <summary>
        /// Roll angle (rad, -pi..+pi)
        /// </summary>
        [Metadata(Unit = "rad")]
        public float Roll { get; set; }

        /// <summary>
        /// Pitch angle (rad, -pi..+pi)
        /// </summary>
        [Metadata(Unit = "rad")]
        public float Pitch { get; set; }

        /// <summary>
        /// Yaw angle (rad, -pi..+pi)
        /// </summary>
        [Metadata(Unit = "rad")]
        public float Yaw { get; set; }

        /// <summary>
        /// Roll angular speed (rad/s)
        /// </summary>
        [Metadata(Unit = "rad/s")]
        public float RollSpeed { get; set; }

        /// <summary>
        /// Pitch angular speed (rad/s)
        /// </summary>
        [Metadata(Unit = "rad/s")]
        public float PitchSpeed { get; set; }

        /// <summary>
        /// Yaw angular speed (rad/s)
        /// </summary>
        [Metadata(Unit = "rad/s")]
        public float YawSpeed { get; set; }

        public Attitude()
        {
            Id = 30;
            Crc = 39;
            PayloadLength = 28;
        }

        public override void Deserialize(BinaryReader br)
        {
            TimeBootMs = br.ReadUInt32();
            Roll = br.ReadSingle();
            Pitch = br.ReadSingle();
            Yaw = br.ReadSingle();
            RollSpeed = br.ReadSingle();
            PitchSpeed = br.ReadSingle();
            YawSpeed = br.ReadSingle();
        }

        public override void Serialize(BinaryWriter bw)
        {
            bw.Write(TimeBootMs);
            bw.Write(Roll);
            bw.Write(Pitch);
            bw.Write(Yaw);
            bw.Write(RollSpeed);
            bw.Write(PitchSpeed);
            bw.Write(YawSpeed);
        }
    }
}