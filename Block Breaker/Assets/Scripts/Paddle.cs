using UnityEngine;

public class Paddle : MonoBehaviour {

    public bool Autoplay;

    private Ball _ball;
    private float _leftBound;
    private float _rightBound;

    void Awake () {
        var paddlePivot = this.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        this._ball = FindObjectOfType <Ball>();
        this._leftBound = paddlePivot;
        this._rightBound = 1920 - paddlePivot;
        Cursor.visible = false;
	}

	void Update () {
	    var mousePosInBlocks = Input.mousePosition.x/Screen.width*1920;
	    if (this.Autoplay) {
	        mousePosInBlocks = this._ball.transform.position.x;
	    }
	    this.transform.position = new Vector3(Mathf.Clamp(mousePosInBlocks, this._leftBound, this._rightBound), this.transform.position.y, 5);
	}
        
    void OnDestroy () {
        Cursor.visible = true;
    }

}
