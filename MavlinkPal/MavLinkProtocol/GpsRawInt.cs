using MavLinkPal.Attributes;

namespace MavLinkPal.MavLinkProtocol
{
    /// <summary>
    /// The global position, as returned by the Global Positioning System (GPS). This is NOT the global position
    /// estimate of the system, but rather a RAW sensor value. See message GLOBAL_POSITION for the global position
    /// estimate. Coordinate frame is right-handed, Z-axis up (GPS frame).
    /// </summary>
    public class GpsRawInt : Message
    {
        /// <summary>
        /// Timestamp (microseconds since UNIX epoch or microseconds since system boot)
        /// </summary>
        [Metadata(Unit = "us")]
        public UInt64 TimeUsec { get; set; }

        /// <summary>
        /// Latitude (WGS84), in degrees * 1E7
        /// </summary>
        [Metadata(Unit = "degE7")]
        public Int32 Lat { get; set; }

        /// <summary>
        /// Longitude (WGS84), in degrees * 1E7
        /// </summary>
        [Metadata(Unit = "degE7")]
        public Int32 Lon { get; set; }

        /// <summary>
        /// Altitude (AMSL, NOT WGS84), in meters * 1000 (positive for up). Note that virtually all GPS modules provide the AMSL altitude in addition to the WGS84 altitude.
        /// </summary>
        [Metadata(Unit = "mm")]
        public Int32 Alt { get; set; }

        /// <summary>
        /// GPS HDOP horizontal dilution of position (unitless). If unknown, set to: UINT16_MAX
        /// </summary>
        [Metadata]
        public UInt16 Eph { get; set; }

        /// <summary>
        /// GPS VDOP vertical dilution of position (unitless). If unknown, set to: UINT16_MAX
        /// </summary>
        [Metadata]
        public UInt16 Epv { get; set; }

        /// <summary>
        /// GPS ground speed (m/s * 100). If unknown, set to: UINT16_MAX
        /// </summary>
        [Metadata(Unit = "cm/s")]
        public UInt16 Vel { get; set; }

        /// <summary>
        /// Course over ground (NOT heading, but direction of movement) in degrees * 100, 0.0..359.99 degreebw. If unknown, set to: UINT16_MAX
        /// </summary>
        [Metadata(Unit = "cdeg")]
        public UInt16 Cog { get; set; }

        /// <summary>
        /// 0-1: no fix, 2: 2D fix, 3: 3D fix, 4: DGPS, 5: RTK. Some applications will not use the value of this field unless it is at least two, so always correctly fill in the fix.
        /// </summary>
        [Metadata]
        public byte FixType { get; set; }

        /// <summary>
        /// Number of satellites visible. If unknown, set to 255
        /// </summary>
        [Metadata]
        public byte SatellitesVisible { get; set; }

        public GpsRawInt()
        {
            Id = 24;
            Crc = 24;
            PayloadLength = 52 - 22;
        }
        public override void Deserialize(BinaryReader br)
        {
            TimeUsec = br.ReadUInt64();
            Lat = br.ReadInt32();
            Lon = br.ReadInt32();
            Alt = br.ReadInt32();
            Eph = br.ReadUInt16();
            Epv = br.ReadUInt16();
            Vel = br.ReadUInt16();
            Cog = br.ReadUInt16();
            FixType = br.ReadByte();
            SatellitesVisible = br.ReadByte();
            // +22 extended
        }

        public override void Serialize(BinaryWriter bw)
        {
            bw.Write(TimeUsec);
            bw.Write(Lat);
            bw.Write(Lon);
            bw.Write(Alt);
            bw.Write(Eph);
            bw.Write(Epv);
            bw.Write(Vel);
            bw.Write(Cog);
            bw.Write(FixType);
            bw.Write(SatellitesVisible);
        }
    }
}