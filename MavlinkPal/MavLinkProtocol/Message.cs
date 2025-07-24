using Humanizer;
using MavLinkPal.Attributes;
using System.Reflection;
using System.Text;

namespace MavLinkPal.MavLinkProtocol
{
    public abstract class Message : IMessage
    {
        public const int LengthMin = 12;
        public const int LengthMax = 280;

        public const int HeaderLength = 10;
        public const int CrcLength = 2;

        public const int OffsetStartMarker = 0;
        public const int OffsetPayloadLength = 1;
        public const int OffsetIncompatibilityFlags = 2;
        public const int OffsetCompatibilityFlags = 3;
        public const int OffsetPacketSequence = 4;
        public const int OffsetSystemId = 5;
        public const int OffsetComponentId = 6;
        public const int OffsetMessageId = 7;
        public const int OffsetPayload = 10;

        public const byte StartMarker = 0xFD;

        [NotPayload] public DateTime Timestamp { get; protected set; }
        [NotPayload] public byte Id { get; protected set; }
        [NotPayload] public byte Crc { get; protected set; }
        [NotPayload] public int PayloadLength { get; protected set; }
        [NotPayload] public List<PropertyInfo> PayloadProperties =>
            GetType().GetProperties()
                .Where(x => x.GetCustomAttributes(typeof(NotPayloadAttribute), false).Length == 0)
                .ToList();

        public Message()
        {
            Timestamp = DateTime.UtcNow;
        }

        public virtual void Serialize(BinaryWriter bw) { }

        public virtual void Deserialize(BinaryReader br) { }

        public virtual string GetFileName()
        {
            var ext = ".csv";

            if (GetType().Name.StartsWith("NamedValue"))
            {
                var bytes = (byte[])PayloadProperties.Find(x => x.Name == "Name").GetValue(this);

                var count = bytes.TakeWhile(x => x != 0).Count();

                var name = Encoding.ASCII.GetString(bytes, 0, count);

                ext = $"_{name}.csv";
            }

            var filename = $"{GetType().Name.Underscore()}{ext}";

            return filename;
        }

        public virtual List<string> GetNames()
        {
            var names = new List<string>
            {
                $"{nameof(Timestamp)}{GetType().Name}".Underscore().ToLower()
            };

            foreach (var pi in PayloadProperties)
            {
                names.Add(pi.Name.Underscore());
            }

            return names;
        }

        public virtual List<string> GetUnits()
        {
            var units = new List<string>
            {
                "n/a"
            };

            foreach (var pi in PayloadProperties)
            {
                var attrib = pi.GetCustomAttribute<MetadataAttribute>();

                units.Add(attrib.Unit);
            }

            return units;
        }

        public virtual List<object> GetValues()
        {
            var values = new List<object>
            {
                $"{Timestamp:yyyy-MM-dd HH:mm:ss.fff}"
            };

            foreach (var pi in PayloadProperties)
            {
                values.Add($"{pi.GetValue(this)}");
            }

            return values;
        }
    }
}
