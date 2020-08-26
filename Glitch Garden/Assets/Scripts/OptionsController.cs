using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour {

    public Slider VolumeSlider;
    public Slider DifficultySlider;

    private MusicManager MusicManager;

    void Start () {
        this.MusicManager = FindObjectOfType <MusicManager>();
        if (this.MusicManager != null) {
            this.VolumeSlider.onValueChanged.AddListener(this.MusicManager.ChangeVolume);
        }
        this.VolumeSlider.value = PlayerPrefsManager.GetMasterVolume();
        this.DifficultySlider.value = PlayerPrefsManager.GetDifficulty();
    }

    public void Save () {
        PlayerPrefsManager.SetMasterVolume(this.VolumeSlider.value);
        PlayerPrefsManager.SetDifficulty((int) this.DifficultySlider.value);
    }

    public void SetDefaults () {
        this.VolumeSlider.value = PlayerPrefsManager.GetDefaultMasterVolume();
        this.DifficultySlider.value = PlayerPrefsManager.GetDefaultDifficulty();
    }

}
