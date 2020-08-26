using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    private string _levelName;

    public void LoadLevel (string name) {
        SceneManager.LoadScene(name);
    }

    public void LoadNextLevel () {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadLevel (string name, float delay) {
        this._levelName = name;
        this.CancelInvoke("LoadLevelAfterDelay");
        this.Invoke("LoadLevelAfterDelay", delay);
    }

    private void LoadLevelAfterDelay () {
        this.LoadLevel(this._levelName);
    }

    public void Quit () {
        Application.Quit();
    }

}