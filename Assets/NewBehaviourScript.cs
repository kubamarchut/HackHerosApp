using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject loadingScreen;
    public Text progressInfo;

    public void PlayGame (int SceneIndex)
    {
        StartCoroutine(LoadAsynchronously(SceneIndex));
    }
    IEnumerator LoadAsynchronously(int SceneIndex)
    {
        if(SceneIndex == 3) { Screen.orientation = ScreenOrientation.Portrait;}
        loadingScreen.SetActive(true);

        float i = 0f;
        while (i < 3f)
        {
            i += Time.deltaTime;

            yield return null;
        }
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneIndex);
       
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            progressInfo.text = progress * 100f + "%";
            yield return null;
        }
    }
}
