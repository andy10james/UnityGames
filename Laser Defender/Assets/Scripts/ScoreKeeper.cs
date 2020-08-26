using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

    public Text ScoreUI;
    public Text HighScoreUI;

    private static int _score;
    private static int _highScore;

	// Use this for initialization
	void Start () {
	    if (this.ScoreUI != null) {
            this.ScoreUI.text = _score.ToString();
	    }
	    if (this.HighScoreUI != null) {
            this.HighScoreUI.text = _highScore.ToString();
	    }
    }

    public void Reset () {
        _score = 0;
    }

    public void IncrementScore (int score) {
        _score += score;
        if (_score > _highScore) _highScore = _score;
        if (this.ScoreUI != null) {
            this.ScoreUI.text = _score.ToString();
        }
        if (this.HighScoreUI != null) {
            this.HighScoreUI.text = _highScore.ToString();
        }
    }
    
}
