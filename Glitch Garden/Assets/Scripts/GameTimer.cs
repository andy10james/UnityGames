using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

    [Tooltip("How long until the level is won.")]
    public int TotalSeconds = 180;

    private Slider _slider;
    private AudioSource _audioSource;
    private MusicManager _musicManager;
    private LevelManager _levelManager;
    public bool IsEndOfLevel = false;

    void Start () {
        this._slider = this.GetComponent <Slider>();
        this._levelManager = FindObjectOfType <LevelManager>();
        this._audioSource= FindObjectOfType <AudioSource>();
        this._musicManager = FindObjectOfType<MusicManager>();
    }

	void Update () {
	    this._slider.value = Time.timeSinceLevelLoad / this.TotalSeconds;
	    if (!this.IsEndOfLevel && this._slider.value >= this._slider.maxValue) {
            this.IsEndOfLevel = true;
	        if (this._musicManager) {
	            this._audioSource.volume *= this._musicManager.MasterVolume;
	        }
            this._audioSource.Play();
            this.Invoke("LoadNextLevel", this._audioSource.clip.length);
	    }
	}

    void LoadNextLevel () {
        this._levelManager.LoadNextLevel();
    }

}
