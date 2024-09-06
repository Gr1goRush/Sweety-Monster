using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(LoadAwait());
    }
    private IEnumerator LoadAwait()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("Game");
    }
}
