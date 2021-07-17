
using UnityEngine;

public class AudioSettings : MonoBehaviour
{

    private static string MusicPref = "MusicPref";
    private static string SoundEffectsPref = "SoundPref";
    private float musicFloat, soundEffectsFloat;
    public AudioSource[] musicAudio;
    public AudioSource[] soundEffectsAudio;

    // Start is called before the first frame update
    void Awake()
    {
        ContinueSettings();
    }

    private void ContinueSettings() {

        musicFloat = PlayerPrefs.GetFloat(MusicPref);
        soundEffectsFloat = PlayerPrefs.GetFloat(SoundEffectsPref);


        for (int i = 0; i < musicAudio.Length; i++)
        {
            musicAudio[i].volume = musicFloat;
        }

        for (int i = 0; i < soundEffectsAudio.Length; i++)
        {
            soundEffectsAudio[i].volume = soundEffectsFloat;
        }
    }
}
