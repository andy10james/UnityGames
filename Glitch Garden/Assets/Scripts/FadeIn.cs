using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour {

    public float FadeInTime = 1;
    public float Performance = 30;

    private Image _fadePanel;
    private Color _currentColour = Color.white;

    void Start () {
        this._fadePanel = this.GetComponent <Image>();
        this._fadePanel.color = this._currentColour;
        this.InvokeRepeating("FadeDown", 1 / this.Performance, 1 / this.Performance);
    }

    void FadeDown () {
        if (this._fadePanel == null) return;
        if (Time.timeSinceLevelLoad < this.FadeInTime) {
	        this._currentColour.a = 1-Time.timeSinceLevelLoad/this.FadeInTime;
	        this._fadePanel.color = this._currentColour;
	    }
	    else {
	        this._fadePanel.enabled = false;
	        this.CancelInvoke("FadeDown");
	    }
	}

}
