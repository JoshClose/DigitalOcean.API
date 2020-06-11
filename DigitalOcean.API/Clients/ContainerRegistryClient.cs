using DigitalOcean.API.Http;
using DigitalOcean.API.Models.Requests;
using DigitalOcean.API.Models.Responses;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalOcean.API.Clients {
    public class ContainerRegistryClient : IContainerRegistryClient {
        private readonly IConnection _connection;

        public ContainerRegistryClient(IConnection connection) {
            _connection = connection;
        }

        public Task<ContainerRegistry> Get() {
            return _connection.ExecuteRequest<ContainerRegistry>("registry", null, null, "registry");
        }

        public Task<JObject> GetDockerCredentials() {
            return _connection.ExecuteRequest<JObject>("registry/docker-credentials", null, null, "auths");
        }

        public Task Delete() {
            return _connection.ExecuteRaw("registry", null, null, Method.DELETE);
        }

        public Task ValidateName(string name) {
            var data = new ContainerRegistryValidateName {
                Name = name,
            };

            return _connection.ExecuteRaw("registry/validate-name", null, data, Method.POST);
        }

        public Task<List<ContainerRegistryRepository>> ListRepositories(string registryName) {
            var endpoint = $"registry/{registryName}/repositories";

            return _connection.ExecuteRequest<List<ContainerRegistryRepository>>(endpoint, null, null, "repositories");
        }

        public Task<List<ContainerRegistryTag>> ListTags(string registryName, string repositoryName) {
            var endpoint = $"registry/{registryName}/repositories/{repositoryName}/tags";

            return _connection.ExecuteRequest<List<ContainerRegistryTag>>(endpoint, null, null, "tags");
        }

        public Task DeleteTag(string registryName, string repositoryName, string tag) {
            var endpoint = $"registry/{registryName}/repositories/{repositoryName}/tags/{tag}";

            return _connection.ExecuteRaw(endpoint, null, null, Method.DELETE);
        }

        public Task DeleteManifest(string registryName, string repositoryName, string manifestDigest) {
            var endpoint = $"registry/{registryName}/repositories/{repositoryName}/digests/{manifestDigest}";

            return _connection.ExecuteRaw(endpoint, null, null, Method.DELETE);
        }
    }
}
