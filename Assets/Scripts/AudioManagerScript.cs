using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.mute = GlobalVars.Mute;
    }

    public void Mute()
    {
        GlobalVars.Mute = !GlobalVars.Mute;
        audioSource.mute = GlobalVars.Mute;
    }

    public void CollisionAudioPlay(GameObject collision)
    {
        audioSource.clip = collision.gameObject.GetComponent<AudioSource>().clip;
        audioSource.Play();
    }
}
