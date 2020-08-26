using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {

    public AudioClip[] LevelMusic;
    public float[] LevelMusicVolume;
    public float MasterVolume; // A player set modifier for the CurMusicVolume set from Inspector

    private float CurMusicVolume;
    void Awake () {
        DontDestroyOnLoad(this.gameObject);
    }

	void Start () {
	    this.CurMusicVolume = 1;
	    this.MasterVolume = PlayerPrefsManager.GetMasterVolume();
        this.SceneManagerOnSceneLoaded(SceneManager.GetActiveScene(), LoadSceneMode.Single);
	    SceneManager.sceneLoaded += SceneManagerOnSceneLoaded;
	}

    private void SceneManagerOnSceneLoaded (Scene scene, LoadSceneMode loadSceneMode) {
        var audioSource = this.GetComponent<AudioSource>();
        if (this.LevelMusicVolume != null
                && this.LevelMusicVolume.Length > scene.buildIndex
                && this.LevelMusicVolume[scene.buildIndex] > 0) {
            this.CurMusicVolume = this.LevelMusicVolume[scene.buildIndex];
            audioSource.volume = this.CurMusicVolume * this.MasterVolume;
        }
        if (this.LevelMusic != null
            && this.LevelMusic.Length > scene.buildIndex
            && this.LevelMusic[scene.buildIndex] != null
            && audioSource.clip != this.LevelMusic[scene.buildIndex]) {
            audioSource.volume = this.CurMusicVolume * this.MasterVolume;
            audioSource.clip = this.LevelMusic[scene.buildIndex];
            audioSource.Play();
        }
    }

    public void ChangeVolume (float vol) {
        vol = vol < 0 ? 0 : vol > 1 ? 1 : vol;
        this.MasterVolume = vol;
        var audioSource = this.GetComponent<AudioSource>();
        audioSource.volume = this.CurMusicVolume * this.MasterVolume;
    }

}
