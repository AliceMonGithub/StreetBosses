using System;
using UnityEngine;

internal sealed class LoadCurtain : MonoBehaviour
{
    public void Show(Action onShowed)
    {
        Debug.Log("Start showing curtain");

        onShowed?.Invoke();
    }

    public void Hide()
    {
        Debug.Log("Curtain hiden");
    }
}