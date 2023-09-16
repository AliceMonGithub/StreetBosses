using UnityEngine.SceneManagement;
using UnityEngine;

internal sealed class SceneLoader
{
    private readonly LoadCurtain _curtain;

    public SceneLoader(LoadCurtain curtain)
    {
        _curtain = curtain;
    }

    public void LoadScene(string name)
    {
        _curtain.Show(() => Load(name));
    }

    private void Load(string name)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(name);

        while (asyncLoad.isDone == false)
        {
            // yield return null;
        }
    }
}
