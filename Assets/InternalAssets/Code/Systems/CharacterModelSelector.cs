using UnityEngine;

public class CharacterModelSelector : MonoBehaviour
{
    [SerializeField] private GameObject[] _modelArray;

    public void SelectModel(int modelID)
    {
        modelID = Mathf.Clamp(modelID, 0, _modelArray.Length - 1);

        foreach (var model in _modelArray)
        {
            model.gameObject.SetActive(false);
        }
        _modelArray[modelID].SetActive(true);
    }
}
