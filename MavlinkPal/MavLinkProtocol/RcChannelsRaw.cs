using MavLinkPal.Attributes;

namespace MavLinkPal.MavLinkProtocol
{
    /// <summary>
    /// The RAW values of the RC channels received. The standard PPM modulation is as follows:
    /// 1000 microseconds: 0%, 2000 microseconds: 100%.
    /// Individual receivers/transmitters might violate this specification.
    /// </summary>
    public class RcChannelsRaw : Message
    {
        /// <summary>
        /// Timestamp (milliseconds since system boot)
        /// </summary>
        [Metadata(Unit = "ms")]
        public UInt32 TimeBootMs { get; set; }

        /// <summary>
        /// RC channel 1 value, in microseconds. A value of UINT16_MAX implies the channel is unused.
        /// </summary>
        [Metadata(Unit = "us")]
        public UInt16 Chan1Raw { get; set; }

        /// <summary>
        /// RC channel 2 value, in microseconds. A value of UINT16_MAX implies the channel is unused.
        /// </summary>
        [Metadata(Unit = "us")]
        public UInt16 Chan2Raw { get; set; }

        /// <summary>
        /// RC channel 3 value, in microseconds. A value of UINT16_MAX implies the channel is unused.
        /// </summary>
        [Metadata(Unit = "us")]
        public UInt16 Chan3Raw { get; set; }

        /// <summary>
        /// RC channel 4 value, in microseconds. A value of UINT16_MAX implies the channel is unused.
        /// </summary>
        [Metadata(Unit = "us")]
        public UInt16 Chan4Raw { get; set; }

        /// <summary>
        /// RC channel 5 value, in microseconds. A value of UINT16_MAX implies the channel is unused.
        /// </summary>
        [Metadata(Unit = "us")]
        public UInt16 Chan5Raw { get; set; }

        /// <summary>
        /// RC channel 6 value, in microseconds. A value of UINT16_MAX implies the channel is unused.
        /// </summary>
        [Metadata(Unit = "us")]
        public UInt16 Chan6Raw { get; set; }

        /// <summary>
        /// RC channel 7 value, in microseconds. A value of UINT16_MAX implies the channel is unused.
        /// </summary>
        [Metadata(Unit = "us")]
        public UInt16 Chan7Raw { get; set; }

        /// <summary>
        /// RC channel 8 value, in microseconds. A value of UINT16_MAX implies the channel is unused.
        /// </summary>
        [Metadata(Unit = "us")]
        public UInt16 Chan8Raw { get; set; }

        /// <summary>
        /// Servo output port (set of 8 outputs = 1 port). Most MAVs will just use one, but this allows for more than 8 servobw.
        /// </summary>
        [Metadata]
        public byte Port { get; set; }

        /// <summary>
        /// Receive signal strength indicator, 0: 0%, 100: 100%, 255: invalid/unknown.
        /// </summary>
        [Metadata]
        public byte Rssi { get; set; }

        public RcChannelsRaw()
        {
            Id = 35;
            Crc = 244;
            PayloadLength = 22;
        }

        public override void Deserialize(BinaryReader br)
        {
            TimeBootMs = br.ReadUInt32();
            Chan1Raw = br.ReadUInt16();
            Chan2Raw = br.ReadUInt16();
            Chan3Raw = br.ReadUInt16();
            Chan4Raw = br.ReadUInt16();
            Chan5Raw = br.ReadUInt16();
            Chan6Raw = br.ReadUInt16();
            Chan7Raw = br.ReadUInt16();
            Chan8Raw = br.ReadUInt16();
            Port = br.ReadByte();
            Rssi = br.ReadByte();
        }

        public override void Serialize(BinaryWriter bw)
        {
            bw.Write(TimeBootMs);
            bw.Write(Chan1Raw);
            bw.Write(Chan2Raw);
            bw.Write(Chan3Raw);
            bw.Write(Chan4Raw);
            bw.Write(Chan5Raw);
            bw.Write(Chan6Raw);
            bw.Write(Chan7Raw);
            bw.Write(Chan8Raw);
            bw.Write(Port);
            bw.Write(Rssi);
        }
    }
}