using Reflex.Core;
using Template._Project.Scripts.IdentificationService;
using UnityEngine;

namespace Template._Project.Scripts.Infrastructure
{
    /// <summary>
    /// Defines the bindings to the root global container
    /// </summary>
    public class ProjectInstaller : MonoBehaviour, IInstaller
    {
        /// <summary>
        /// Reflex looks for & uses IInstaller instance to build a container
        /// </summary>
        public void InstallBindings(ContainerBuilder containerBuilder)
        {
            containerBuilder.AddSingleton(new IdentificationService.IdentificationService(), typeof(IIdentificationService));
        }
    }
}