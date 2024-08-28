using System.Runtime.Serialization;
using System.Text.Json.Serialization;

public class Employee {
    [JsonIgnore]
    public int Id { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("hiredate")]
    public System.DateTime HireDate { get; set; }
}