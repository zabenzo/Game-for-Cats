using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure.SceneLoader
{
    public class SceneLoader : ISceneLoader
    {
        private readonly ICoroutineRunner _coroutineRunner;

        public SceneLoader(ICoroutineRunner coroutineRunner) => 
            _coroutineRunner = coroutineRunner;

        public void Load(string sceneName, Action onLoaded = null) => 
            _coroutineRunner.StartCoroutine(LoadLevelRoutine(sceneName, onLoaded));

        public void Unload(string sceneName, Action onLoaded = null) => 
            _coroutineRunner.StartCoroutine(UnloadLevelRoutine(sceneName, onLoaded));

        private IEnumerator UnloadLevelRoutine(string sceneName, Action onLoaded)
        {
            if (sceneName == SceneManager.GetActiveScene().name)
            {
                yield break;
            }
            
            AsyncOperation loadSceneAsync = SceneManager.UnloadSceneAsync(sceneName);

            while (!loadSceneAsync.isDone)
            {
                yield return null;
            }
            
            onLoaded?.Invoke();
        }

        private IEnumerator LoadLevelRoutine(string sceneName, Action onLoaded = null)
        {
            if (sceneName == SceneManager.GetActiveScene().name)
            {
                yield break;
            }
            
            AsyncOperation loadSceneAsync = SceneManager.LoadSceneAsync(sceneName);

            while (!loadSceneAsync.isDone)
            {
                yield return null;
            }
            
            onLoaded?.Invoke();
        }
    }
}