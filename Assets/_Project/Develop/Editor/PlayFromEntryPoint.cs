using UnityEditor;
using UnityEditor.SceneManagement;

namespace _Project.Develop.Editor
{
    [InitializeOnLoad]
    public static class PlayFromEntryPoint
    {
        private const string EntryPointScene    = "Assets/_Project/Scenes/GameEntryPoint.unity";
        private const string PreviousSceneKey   = "PlayFromEntryPoint.PreviousScene";
        private const string WasRedirectedKey   = "PlayFromEntryPoint.WasRedirected";

        static PlayFromEntryPoint()
        {
            EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
        }

        private static void OnPlayModeStateChanged(PlayModeStateChange state)
        {
            if (state == PlayModeStateChange.ExitingEditMode)
            {
                string current = EditorSceneManager.GetActiveScene().path;

                if (current == EntryPointScene)
                {
                    EditorPrefs.SetBool(WasRedirectedKey, false);
                    return;
                }

                if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
                {
                    EditorPrefs.SetString(PreviousSceneKey, current);
                    EditorPrefs.SetBool(WasRedirectedKey, true);
                    EditorSceneManager.OpenScene(EntryPointScene);
                }
                else
                {
                    EditorApplication.isPlaying = false;
                }
            }
            else if (state == PlayModeStateChange.EnteredEditMode)
            {
                if (!EditorPrefs.GetBool(WasRedirectedKey, false))
                    return;

                EditorPrefs.SetBool(WasRedirectedKey, false);
                string previous = EditorPrefs.GetString(PreviousSceneKey, string.Empty);

                if (!string.IsNullOrEmpty(previous))
                    EditorSceneManager.OpenScene(previous);
            }
        }
    }
}
