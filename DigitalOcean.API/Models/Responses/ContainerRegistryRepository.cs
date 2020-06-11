using Newtonsoft.Json;
using System.Diagnostics;

namespace DigitalOcean.API.Models.Responses {
    [DebuggerDisplay("Name = {Name}, RegistryName = {Registryname}, TagCount = {TagCount}")]
    public class ContainerRegistryRepository {
        [JsonProperty("registry_name")]
        public string RegistryName { get; set; }

        public string Name { get; set; }

        [JsonProperty("tag_count")]
        public int TagCount { get; set; }

        [JsonProperty("latest_tag")]
        public ContainerRegistryTag LatestTag { get; set; }
    }
}
