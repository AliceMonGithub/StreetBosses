using UnityEngine.SceneManagement;
using UnityEngine;
using DI;
using System.Collections;
using System;

namespace Client.SceneLoading
{
    internal sealed class SceneLoader
    {
        private readonly LoadCurtain _curtain;
        //private readonly ICoroutineRunner _coroutineRunner;

        public SceneLoader(LoadCurtain curtain)//, ICoroutineRunner coroutineRunner)
        {
            _curtain = curtain;
            //_coroutineRunner = coroutineRunner;
        }

        public void LoadScene(string name, Action onComplete = null)
        {
            //_curtain.Show(() => _coroutineRunner.RunCoroutine(Load(name, onComplete)));
            _curtain.Show(() => Load(name, onComplete));
        }

        private void Load(string name, Action onComplete)
        {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(name);

            asyncLoad.completed += (_) => EndLoad(onComplete);
        }

        private void EndLoad(Action onComplete)
        {
            _curtain.Hide();
            onComplete?.Invoke();
        }
    }
}