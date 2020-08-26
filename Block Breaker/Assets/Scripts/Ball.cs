using UnityEngine;

public class Ball : MonoBehaviour {

    public Paddle Paddle;

    private ScoreKeeper _scoreKeeper;
    private Vector3 _paddleToBallVector;
    private AudioSource _bounceSound;
    private Rigidbody2D _rigidbody2D;

	// Use this for initialization
	void Start () {
	    this._scoreKeeper = FindObjectOfType <ScoreKeeper>();
	    this.Paddle = this.Paddle ?? FindObjectOfType <Paddle>();
	    this._paddleToBallVector = this.transform.position - this.Paddle.transform.position;
	    this._bounceSound = this.GetComponent <AudioSource>();
	    this._rigidbody2D = this.GetComponent <Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (!this._scoreKeeper.GameStarted) {
	        if (Input.GetMouseButtonDown(0)) {
	            this._scoreKeeper.GameStarted = true;
                this._rigidbody2D.velocity = new Vector2(Random.Range(-240, 240), 1080);
	        }
            this.transform.position = new Vector3(this.Paddle.transform.position.x + this._paddleToBallVector.x, this.Paddle.transform.position.y + this._paddleToBallVector.y, this.transform.position.z);
	    }
	}

    void OnCollisionEnter2D (Collision2D collision) {
        if (!this._scoreKeeper.GameStarted) return;
        this._bounceSound.Play();
    }

}
