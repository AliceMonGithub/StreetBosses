using UnityEngine;

internal sealed class Test : MonoBehaviour
{
    [SerializeField] private LoadCurtain _curtain;

    private SceneLoader _loader;

    private void Start()
    {
        _loader = new(_curtain);

        _loader.LoadScene("Street");
    }
}