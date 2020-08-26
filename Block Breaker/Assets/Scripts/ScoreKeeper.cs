using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

    public Text ScoreUI;
    public static int Score { get; private set; }
    public bool GameStarted { get; set; }

	// Use this for initialization
	void Start () {
	    if (this.ScoreUI != null) {
            this.ScoreUI.text = Score.ToString();
	    }
    }

    public void Reset () {
        Score = 0;
    }

    public void IncrementScore () {
        if (!this.GameStarted) return;
        Score++;
        if (this.ScoreUI != null) {
            this.ScoreUI.text = Score.ToString();
        }
    }

}
