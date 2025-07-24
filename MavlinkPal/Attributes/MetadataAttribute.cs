namespace MavLinkPal.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MetadataAttribute : Attribute
    {
        public string Unit { get; set; }

        public MetadataAttribute(string unit = "n/a")
        {
            Unit = unit;
        }
    }
}
