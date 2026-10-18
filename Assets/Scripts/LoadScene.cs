using UnityEngine;
using UnityEngine.SceneManagement; // Required for loading scenes

public class LoadScene : MonoBehaviour
{
    public void LoadSceneByName(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

}
