using Newtonsoft.Json;
using System;
using System.Diagnostics;

namespace DigitalOcean.API.Models.Responses {
    [DebuggerDisplay("Tag = {Tag}, Repository = {Repository}, RegistryName = {RegistryName}")]
    public class ContainerRegistryTag {
        [JsonProperty("registry_name")]
        public string RegistryName { get; set; }

        public string Repository { get; set; }

        public string Tag { get; set; }

        [JsonProperty("manifest_digest")]
        public string ManifestDigest { get; set; }

        [JsonProperty("compressed_size_bytes")]
        public int CompressedSizeBytes { get; set; }

        [JsonProperty("size_bytes")]
        public int SizeBytes { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
