using UnityEngine;

public class GoToScene : MonoBehaviour {

    public LevelManager LevelManager;
    public string SceneName = "Menu";
    public int Delay = 3;

	void Start () {
	    if (this.LevelManager == null) return;
	    this.LevelManager.LoadLevel(this.SceneName, this.Delay);
	}
	
}
