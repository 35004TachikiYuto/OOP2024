using System.Runtime.Serialization;
using System.Text.Json.Serialization;

public class Employee {
    [JsonIgnore]
    public int Id { get; set; }
    public string Name { get; set; }
    public System.DateTime HireDate { get; set; }
}