using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace voodooTest
{
    public class SceneManager : Singleton<SceneManager>
    {
        [SerializeField, Scene] private List<string> additiveScenes;

        protected override void Awake()
        {
            base.Awake();

            LoadAdditiveScenes();
        }

        public void LoadAdditiveScenes()
        {
            foreach(string scene in additiveScenes)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(scene, UnityEngine.SceneManagement.LoadSceneMode.Additive);
            }
        }
    }
}
