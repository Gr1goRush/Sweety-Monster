using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AnimatedImage : Image
{
    [SerializeField, HideInInspector] private Image _imageUI;

    public void ToggleActiveSmooth(bool state)
    {

        if (state == true)
        {
            gameObject.SetActive(true);
            Color newcolor = color;
            newcolor.a = 0;
            color = newcolor;
        }
        if (!gameObject.activeInHierarchy && state == false) return;
        StartCoroutine(SmoothHideAndShow(state));
    }

    private IEnumerator SmoothHideAndShow(bool State)
    {
        raycastTarget = false;
        Color newcolor = color;
        for (int i = 0; i < 100; i++)
        {
            newcolor.a = State ? newcolor.a + 0.01f : newcolor.a - 0.01f;
            color = newcolor;
            yield return new WaitForSeconds(Time.deltaTime / 2);
        }
        gameObject.SetActive(State);
        raycastTarget = true;
    }
}
