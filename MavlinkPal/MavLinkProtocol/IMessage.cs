namespace MavLinkPal.MavLinkProtocol
{
    public interface IMessage
    {
        public int PayloadLength { get; }
        public DateTime Timestamp { get; }
        public byte Id { get; }

        public void Serialize(BinaryWriter bw);
        public void Deserialize(BinaryReader br);

        public string GetFileName();
        public List<string> GetNames();
        public List<string> GetUnits();
        public List<object> GetValues();
    }
}