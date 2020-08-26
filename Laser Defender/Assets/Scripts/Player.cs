using UnityEngine;

public class Player : MonoBehaviour {

    public GameObject Projectile;
    public float ProjectileSpeed = 20;
    public float ProjectileCooldown = 1;

    public Sprite LeftSprite;
    public Sprite RightSprite;

    // Units per second
    public float Speed = 10;
    public float Padding = 1;
    public float Health = 150;

    public AudioClip ImpactSound;
    public float ImpactSoundVolume;
    public AudioClip KillSound;
    public float KillSoundVolume = 0.5f;
    public float KillDelay = 1;
    public float GameOverDelay = 3;


    private Sprite _initialSprite;
    private bool _onCooldown;
    private float _maxX;
    private float _minX;

	void Start () {
	    this._initialSprite = this.GetComponent <SpriteRenderer>().sprite;
	    this._minX = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + this.Padding;
	    this._maxX = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - this.Padding;
	}
	
	void Update () {
	    if (this.Health <= 0) return;
	    if (!this._onCooldown && Input.GetKey(KeyCode.Space)) {
            var go = Instantiate(this.Projectile, this.transform.position + new Vector3(0, 1), Quaternion.identity) as GameObject;
            go.GetComponent<Rigidbody2D>().velocity = new Vector2(0, this.ProjectileSpeed);
	        this._onCooldown = true;
            this.Invoke("Cooldown", this.ProjectileCooldown);
	    }
	    if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) {
	        var newX = Mathf.Clamp(this.gameObject.transform.position.x - (this.Speed * Time.deltaTime), this._minX, this._maxX);
            this.gameObject.transform.position = new Vector3(newX, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
            if (this.LeftSprite != null) this.GetComponent<SpriteRenderer>().sprite = this.LeftSprite;
	    } else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) {
            var newX = Mathf.Clamp(this.gameObject.transform.position.x + (this.Speed * Time.deltaTime), this._minX, this._maxX);
            this.gameObject.transform.position = new Vector3(newX, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
            if (this.RightSprite != null) this.GetComponent<SpriteRenderer>().sprite = this.RightSprite;
        } else this.GetComponent<SpriteRenderer>().sprite = this._initialSprite;
    }

    void Cooldown () {
        this._onCooldown = false;
    }

    void OnTriggerEnter2D (Collider2D collider) {
        var laser = collider.gameObject.GetComponent <Projectile>();
        if (laser != null) {
            if (this.ImpactSound != null) {
                AudioClipHelper.PlayClipAt(this.ImpactSound, this.transform.position, this.ImpactSoundVolume);
            }
            laser.Hit();
            this.Health -= laser.GetDamage();
            if (this.Health <= 0) {
                var music = FindObjectOfType<Music>();
                if (music != null) {
                    music.Stop();
                }
                foreach (var system in FindObjectsOfType <ParticleSystem>()) {
                    if (system.startSpeed > 1) {
                        system.Stop();
                        system.Clear();
                    }
                }
                FindObjectOfType<EnemySpawner>().Stop();
                this.Invoke("Destroy", this.KillDelay);
            }
        }
    }

    void Destroy () {
        if (this.KillSound != null) {
            AudioClipHelper.PlayClipAt(this.KillSound, this.transform.position, this.KillSoundVolume);
        }
        var levelManager = FindObjectOfType <LevelManager>();
        levelManager.LoadLevel("Game Over", this.GameOverDelay);
        Destroy(this.gameObject);
    }

}
