using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangerScript : MonoBehaviour
{
    public void LoadWithDelay(string sceneName)
    {
        StartCoroutine(LoadSceneAfterDelay(sceneName));
    }

    private IEnumerator LoadSceneAfterDelay(string sceneName)
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    public void QuitApplication()
    {
       /* if(UnityEditor.EditorApplication.isPlaying)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        
        } else*/
            Application.Quit();
    }
}
