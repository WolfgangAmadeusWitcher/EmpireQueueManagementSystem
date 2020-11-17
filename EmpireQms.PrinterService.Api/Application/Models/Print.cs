using System.Drawing;
using System.Text.Json.Serialization;

namespace EmpireQms.PrintService.Api.Application.Models
{
    public enum DataType
    {
        Str = 1,
        Pic = 2
    }
    public class Print
    {

        public string Name { get; set; }
        public Font Font { get; set; }
        public StringFormat StringFormat { get; set; }
        public byte DataType { get; set; }
        [JsonIgnore]
        public float RealFontSize { get; set; }
        [JsonIgnore]
        public Image Image { get; set; }

        public Print(string fontName, float fontSize)
        {
            Font = new Font(fontName, fontSize);
            StringFormat = new StringFormat() { Alignment = StringAlignment.Near };
        }
        public Print()
        {
            Font = new Font("Arial", 12);
            StringFormat = new StringFormat() { Alignment = StringAlignment.Near };
        }

    }
}
