using System.Collections.Generic;
using Aggressors.Utils;

namespace Aggressors.Resources
{
    public interface IResourcesManager
    {
        IResources AddResource();
    }

    public class ResourcesManager : Singleton<ResourcesManager>, IResourcesManager
    {
        private List<Resources> resources = new List<Resources>();

        public IResources AddResource()
        {
            var resource = new Resources();
            resources.Add(resource);
            return resource;
        }
    }
}