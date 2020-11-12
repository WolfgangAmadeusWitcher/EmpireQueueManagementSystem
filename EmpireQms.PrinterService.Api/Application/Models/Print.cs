using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EmpireQms.PrintService.Api.Application.Models
{
    public enum DataType
    {
        str = 1,
        pic = 2
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

        public Print(string FontName, float FontSize)
        {
            Font = new Font(FontName, FontSize);
            StringFormat = new StringFormat() { Alignment = StringAlignment.Near };
        }
        public Print()
        {
            Font = new Font("Arial", 12);
            StringFormat = new StringFormat() { Alignment = StringAlignment.Near };
        }

    }
}
