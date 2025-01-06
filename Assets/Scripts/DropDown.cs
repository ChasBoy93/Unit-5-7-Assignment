using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DropDown : MonoBehaviour
{
    public TMP_Dropdown dropdown;

    string prefName = "optionvalue";

    void Awake()
    {

        dropdown.onValueChanged.AddListener(new UnityEngine.Events.UnityAction<int>(index =>
        {
            PlayerPrefs.SetInt(prefName, dropdown.value);
            PlayerPrefs.Save();
        }));
    }

    void Start()
    {
        dropdown.value = PlayerPrefs.GetInt(prefName);
    }

}

