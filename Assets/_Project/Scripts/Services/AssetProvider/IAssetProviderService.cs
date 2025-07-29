using UnityEngine;

namespace Template._Project.Scripts.Services.AssetProvider
{
    public interface IAssetProviderService
    {
        public T Instantiate<T>(string pathToPrefab) where T : MonoBehaviour;
        public T Instantiate<T>(string pathToPrefab, Vector3 position) where T : MonoBehaviour;
        public T Instantiate<T>(string pathToPrefab, Vector3 position, Transform parent) where T : MonoBehaviour;
        public T Instantiate<T>(string pathToPrefab, Vector3 position, Transform parent, Quaternion rotation)
            where T : MonoBehaviour;
        public T Instantiate<T>(T prefab) where T : MonoBehaviour;
        public T Instantiate<T>(T prefab, Vector3 position) where T : MonoBehaviour;
        public T Instantiate<T>(T prefab, Vector3 position, Transform parent) where T : MonoBehaviour;
        public T Instantiate<T>(T prefab, Vector3 position, Transform parent, Quaternion rotation)
            where T : MonoBehaviour;
    }
}