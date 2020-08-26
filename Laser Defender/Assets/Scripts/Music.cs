using UnityEngine;
using UnityEngine.SceneManagement;

public class Music : MonoBehaviour {

    private static Music _instance;
    private AudioSource _audioSource;

    void Awake () {
        if (_instance != null) {
            var audio = _instance.GetComponent <AudioSource>();
            if (!audio.isPlaying) {
                audio.Play();
            }
            Destroy(this.gameObject);
            return;
        }
        _instance = this;
    }

    void Start () {
        DontDestroyOnLoad(this.gameObject);
        this._audioSource = this.GetComponent<AudioSource>();
        SceneManager.sceneLoaded += (scene, loadSceneMode) => {
            Debug.Log("Music state: " + (this._audioSource.isPlaying ? "Playing" : "Stopped"));
        };
    }

    public void Stop () {
        this._audioSource.Stop();
    }

    // depreciated
    void OnLevelWasLoaded (int level) {
    }

}
