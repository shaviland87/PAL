using MavLinkPal.Attributes;

namespace MavLinkPal.MavLinkProtocol
{
    /// <summary>
    /// PID tuning information.
    /// </summary>
    public class PidTuning : Message
    {
        /// <summary>
        /// desired rate (degrees/s)
        /// </summary>
        [Metadata]
        public float Desired { get; set; }

        /// <summary>
        /// achieved rate (degrees/s)
        /// </summary>
        [Metadata]
        public float Achieved { get; set; }

        /// <summary>
        /// FF component
        /// </summary>
        [Metadata]
        public float Ff { get; set; }

        /// <summary>
        /// P component
        /// </summary>
        [Metadata]
        public float P { get; set; }

        /// <summary>
        /// I component
        /// </summary>
        [Metadata]
        public float I { get; set; }

        /// <summary>
        /// D component
        /// </summary>
        [Metadata]
        public float D { get; set; }

        /// <summary>
        /// axis
        /// </summary>
        [Metadata]
        public byte Axis { get; set; }

        public PidTuning()
        {
            Id = 194;
            Crc = 98;
            PayloadLength = 33 - 8;
        }

        public override void Deserialize(BinaryReader br)
        {
            Desired = br.ReadSingle();
            Achieved = br.ReadSingle();
            Ff = br.ReadSingle();
            P = br.ReadSingle();
            I = br.ReadSingle();
            D = br.ReadSingle();
            Axis = br.ReadByte();
            // +8 extended
        }

        public override void Serialize(BinaryWriter bw)
        {
            bw.Write(Desired);
            bw.Write(Achieved);
            bw.Write(Ff);
            bw.Write(P);
            bw.Write(I);
            bw.Write(D);
            bw.Write(Axis);
        }
    }
}