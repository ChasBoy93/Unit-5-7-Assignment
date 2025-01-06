using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    public string newSceneLevel = "Level Name";
    public void ChangeTheScene()
    {
        SceneManager.LoadScene(newSceneLevel);
    }


}
