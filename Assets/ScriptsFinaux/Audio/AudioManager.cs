using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;

    public void SetMasterVolume(float volume)
    {
        mixer.SetFloat("masterVolume", volume);
    }

    public void SetMusicVolume(float volume)
    {
        mixer.SetFloat("musiqueVolume", volume);
    }

    public void SetAmbianceVolume(float volume)
    {
        mixer.SetFloat("ambianceVolume", volume);
    }
}
