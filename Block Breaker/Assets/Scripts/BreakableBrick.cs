using UnityEngine;

public class BreakableBrick : MonoBehaviour {

    public LevelManager LevelManager;
    public Sprite[] HitPointSprites;
    public AudioClip HitSound;
    public AudioClip DestroySound;
    public GameObject Smoke;
    public static int BreakableCount;

    private ScoreKeeper _scoreKeeper;
    private int _timesHit;

    void Start () {
        BreakableCount++;
        this._scoreKeeper = this._scoreKeeper ?? FindObjectOfType<ScoreKeeper>();        
        this.LevelManager = this.LevelManager ?? FindObjectOfType <LevelManager>();
	}

    private void OnCollisionEnter2D (Collision2D collision) {
        if (!this._scoreKeeper.GameStarted) return;
        this._scoreKeeper.IncrementScore();
        this._timesHit++;
        if (this._timesHit > this.HitPointSprites.Length) {
            this.PlayClipAt(this.DestroySound, this.transform.position, 0.5f);
            var smoke = Instantiate(this.Smoke, this.gameObject.transform.position, new Quaternion(0, -180, 0, 0));
            BreakableCount--;
            if (BreakableCount <= 0) {
                this.LevelManager.LoadNextLevel();
            }
            Destroy(this.gameObject);
            return;
        }
        this.PlayClipAt(this.HitSound, this.transform.position, 0.5f);
        var newSprite = this.HitPointSprites[this._timesHit - 1];
        if (newSprite != null) {
            this.GetComponent <SpriteRenderer>().sprite = this.HitPointSprites[this._timesHit - 1];
        }
        else {
            Debug.LogError("Breakable brick sprite is missing.");
        }
    }

    private void PlayClipAt (AudioClip clip, Vector3 pos, float volume = 1.0f) {
        var tempGO = new GameObject("TempAudio");
        tempGO.transform.position = pos;
        var aSource = tempGO.AddComponent <AudioSource>();
        aSource.clip = clip;
        aSource.volume = volume;
        aSource.Play();
        Destroy(tempGO, clip.length);
    }

}
