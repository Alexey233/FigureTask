using System.Text.Json.Serialization;

namespace FigureTask.Data.Models
{
    public class GeometricFigure
    {
        public int Id { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("sides")]
        public string Sides { get; set; }
        public DateOnly CreateDate { get; set; }

    }
}
