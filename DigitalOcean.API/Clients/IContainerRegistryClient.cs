using DigitalOcean.API.Http;
using DigitalOcean.API.Models.Responses;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalOcean.API.Clients {
    public interface IContainerRegistryClient {
        Task<ContainerRegistry> Get();

        Task<JObject> GetDockerCredentials();

        Task Delete();

        Task ValidateName(string name);

        Task<List<ContainerRegistryRepository>> ListRepositories(string registryName);

        Task<List<ContainerRegistryTag>> ListTags(string registryName, string repositoryName);

        Task DeleteTag(string registryName, string repositoryName, string tag);

        Task DeleteManifest(string registryName, string repositoryName, string manifestDigest);
    }
}
