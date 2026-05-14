using System;
using System.Collections;

using _Project.Develop.Runtime.Utilities.CoroutinesManagement;

using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Logic.KeyInputManagement
{
    public class WaitForKeyService
    {
        private readonly ICoroutinesPerformer _coroutinesPerformer;

        public WaitForKeyService(ICoroutinesPerformer coroutinesPerformer)
        {
            _coroutinesPerformer = coroutinesPerformer;
        }

        public void ListenForKeyCodeOnce(KeyCode keyCode, Action callback)
        {
            _coroutinesPerformer.StartPerform(Listen(keyCode, callback));
        }

        private static IEnumerator Listen(KeyCode keyCode, Action callback)
        {
            yield return new WaitUntil(() => Input.GetKeyDown(keyCode));
            callback();
        }
    }
}