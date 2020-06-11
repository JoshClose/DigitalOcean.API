using System.Diagnostics;

namespace DigitalOcean.API.Models.Responses {
    [DebuggerDisplay("Name = {Name}")]
    public class ContainerRegistry {
        public string Name { get; set; }
    }
}
