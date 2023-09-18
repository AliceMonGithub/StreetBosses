using System.Collections;
using UnityEngine;

namespace DI
{
    internal interface ICoroutineRunner
    {
        Coroutine RunCoroutine(IEnumerator coroutine);
    }
}