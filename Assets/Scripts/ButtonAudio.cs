using UnityEngine;

public class ButtonAudio : MonoBehaviour
{
    public AudioClip hoverSound;
    public AudioClip clickSound;

    public void HoverSound()
    {
        AudioManager.instance.PlaySoundFXClip(hoverSound, transform, 1f);
    }

    public void ClickSound()
    {
        AudioManager.instance.PlaySoundFXClip(clickSound, transform, 1f);
    }
}
