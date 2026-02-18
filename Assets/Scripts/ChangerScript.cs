using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangerScript : MonoBehaviour
{
    public void LoadWithDelay(string scenename)
    {
        StartCoroutine(LoadSceneAfterDelay(scenename));
    }
    private IEnumerator LoadSceneAfterDelay(string scenename)
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(scenename, LoadSceneMode.Single);
    }

    public void QuitApplication()
    {
        /*if(UnityEditor.EditorApplication.isPlaying)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }else*/
        Application.Quit();
    }
}
