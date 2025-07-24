using Humanizer;
using MavLinkPal.Attributes;

namespace MavLinkPal.MavLinkProtocol
{
    /// <summary>
    /// Send a key-value pair as float. The use of this message is discouraged for normal packets, 
    /// but a quite efficient way for testing new messages and getting experimental debug output.
    /// </summary>
    public class NamedValueFloat : Message
    {
        /// <summary>
        /// Timestamp (milliseconds since system boot)
        /// </summary>
        [Metadata(Unit = "ms")]
        public uint TimeBootMs { get; set; }

        /// <summary>
        /// Floating point value
        /// </summary>
        [Metadata(Unit = "n/a")]
        public float Value { get; set; }

        /// <summary>
        /// Name of the debug variable
        /// </summary>
        [Metadata(Unit = "n/a")]
        public byte[] Name { get; set; }

        public NamedValueFloat()
        {
            Id = 251;
            Crc = 170;
            PayloadLength = 18;

            Name = new byte[10];
        }

        public override void Deserialize(BinaryReader br)
        {
            TimeBootMs = br.ReadUInt32();
            Value = br.ReadSingle();
            Name = br.ReadBytes(10);
        }

        public override void Serialize(BinaryWriter bw)
        {
            bw.Write(TimeBootMs);
            bw.Write(Value);
            bw.Write(Name);
        }

        public override List<string> GetNames()
        {
            return new List<string>
            {
                nameof(Timestamp).Underscore(),
                nameof(TimeBootMs).Underscore(),
                nameof(Value).Underscore(),
            };
        }

        public override List<string> GetUnits()
        {
            return new List<string>
            {
                "n/a",
                "ms",
                "n/a",
            };
        }

        public override List<object> GetValues()
        {
            return new List<object>
            {
                $"{Timestamp:yyyy-MM-dd HH:mm:ss.fff}",
                $"{TimeBootMs}",
                $"{Value}",
            };
        }
    }
}