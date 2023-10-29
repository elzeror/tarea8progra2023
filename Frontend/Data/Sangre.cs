namespace Frontend.Data;
using System.Text.Json.Serialization; 

public class Sangre
    {
        [JsonPropertyName("id_tipo_sangre")]
        public Int32 Id_tipo_sangre { get; set; }

        [JsonPropertyName("sangre")]
        public string? Sangres { get; set; }
    } 