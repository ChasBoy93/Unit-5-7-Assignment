using UnityEngine;

public class QuitGame : MonoBehaviour
{

    public void LeaveGame()
    {
        Application.Quit();
        print("Quit Game");
    }
}
