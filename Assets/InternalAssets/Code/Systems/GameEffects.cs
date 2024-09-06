using System.Collections;
using UnityEngine;

public class GameEffects : MonoBehaviour
{
    [SerializeField] private Transform CharTransform;
    [SerializeField] private Camera _camera;

    private bool _effectIsActive;

    public void StartLoadEffect()
    {
        if (_effectIsActive) return;
        _effectIsActive = true;
        StartCoroutine(StartGameEffect());
    }
    public void StopLoadEffect()
    {
        if (!_effectIsActive) return;
        _effectIsActive = false;
        StartCoroutine(StopGameEffect());
    }

    private IEnumerator StartGameEffect()
    {
        for (int i = 0; i < 200; i++)
        {
            CharTransform.position -= Vector3.right * Time.fixedDeltaTime;
            _camera.orthographicSize += 0.1f * Time.fixedDeltaTime;
            yield return new WaitForEndOfFrame();
        }
        yield return null;
    }

    private IEnumerator StopGameEffect()
    {
        for (int i = 0; i < 400; i++)
        {
            CharTransform.position += Vector3.right/2 * Time.fixedDeltaTime;
            _camera.orthographicSize -= 0.1f/2 * Time.fixedDeltaTime;
            yield return new WaitForEndOfFrame();
        }
        yield return null;
    }
}
