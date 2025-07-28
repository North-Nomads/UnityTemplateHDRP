using UnityEngine;
using UnityEngine.SceneManagement;

namespace Template._Project.Scripts.Infrastructure
{
    public class Bootstrapper : MonoBehaviour
    {
        private void Start()
        {
            var scene = SceneManager.LoadScene("Main", new LoadSceneParameters(LoadSceneMode.Single));
        }
    }
}