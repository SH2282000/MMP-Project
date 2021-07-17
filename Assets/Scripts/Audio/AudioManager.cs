using UnityEngine.UI;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static string FirstPlay = "FirstPlay";
    private static string MusicPref = "MusicPref";
    private static string SoundEffectsPref = "SoundPref";
    private int firstPlayInt;
    public Slider musicSlider, soundEffectsSlider;
    private float musicFloat, soundEffectsFloat;
    public AudioSource [] musicAudio;
    public AudioSource [] soundEffectsAudio;


    // Start is called before the first frame updated
    void Start()
    {
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);

        if (firstPlayInt == 0)
        {
            // when user does adjustments
            musicFloat = 0.25f;
            soundEffectsFloat = 0.75f;
            musicSlider.value = musicFloat;
            soundEffectsSlider.value = soundEffectsFloat;
            PlayerPrefs.SetFloat(MusicPref, musicFloat);
            PlayerPrefs.SetFloat(SoundEffectsPref, soundEffectsFloat);
            PlayerPrefs.SetInt(FirstPlay, -1);
        }
        else {
            // when player enters settings again - set slider to Pref-Value
            musicFloat = PlayerPrefs.GetFloat(MusicPref);
            musicSlider.value = musicFloat;
            soundEffectsFloat = PlayerPrefs.GetFloat(SoundEffectsPref);
            soundEffectsSlider.value = soundEffectsFloat;
        }
    }

    public void SaveSoundSettings() {
        PlayerPrefs.SetFloat(MusicPref, musicSlider.value);
        PlayerPrefs.SetFloat(SoundEffectsPref, soundEffectsSlider.value);
    }

    void OnApplicationFocus(bool inFocus)
    {
        if (!inFocus) {
            SaveSoundSettings();
        }
    }

    public void UpdateSound() {

        for (int i = 0; i < musicAudio.Length; i++) {
            musicAudio[i].volume = musicSlider.value;
        }

        for (int i = 0; i < soundEffectsAudio.Length; i++)
        {
            soundEffectsAudio[i].volume = soundEffectsSlider.value;
        }

    }

}
