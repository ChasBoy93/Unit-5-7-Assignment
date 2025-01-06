using UnityEngine;

public class AnyKeyStart : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject text;

    void Update()
    {
        if(Input.anyKeyDown)
        {
            mainMenu.SetActive(true);
            text.SetActive(false);
        }
    }
}
