using UnityEngine;

namespace Template._Project.Scripts.Services.AssetProvider
{
    public class AssetProviderService : IAssetProviderService
    {
        public T Instantiate<T>(string pathToPrefab) where T : MonoBehaviour 
            => Object.Instantiate(Resources.Load<T>(pathToPrefab));

        public T Instantiate<T>(string pathToPrefab, Vector3 position) where T : MonoBehaviour 
            => Object.Instantiate(Resources.Load<T>(pathToPrefab), position, Quaternion.identity);

        public T Instantiate<T>(string pathToPrefab, Vector3 position, Transform parent) where T : MonoBehaviour
            => Object.Instantiate(Resources.Load<T>(pathToPrefab), position, Quaternion.identity, parent);

        public T Instantiate<T>(string pathToPrefab, Vector3 position, Transform parent, Quaternion rotation) where T : MonoBehaviour
            => Object.Instantiate(Resources.Load<T>(pathToPrefab), position, rotation, parent);

        public T Instantiate<T>(T prefab) where T : MonoBehaviour
            => Object.Instantiate(prefab);

        public T Instantiate<T>(T prefab, Vector3 position) where T : MonoBehaviour
            => Object.Instantiate(prefab, position, Quaternion.identity);

        public T Instantiate<T>(T prefab, Vector3 position, Transform parent) where T : MonoBehaviour
            => Object.Instantiate(prefab, position, Quaternion.identity, parent);

        public T Instantiate<T>(T prefab, Vector3 position, Transform parent, Quaternion rotation) where T : MonoBehaviour
            => Object.Instantiate(prefab, position, rotation, parent);
    }
}