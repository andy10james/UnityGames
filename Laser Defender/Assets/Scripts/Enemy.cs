using UnityEngine;

public class Enemy : MonoBehaviour {

    public GameObject Projectile;
    public float ProjectileSpeed = 10;
    public float ProjectileCooldown = 2;
    public float Health = 200;
    public AudioClip ImpactSound;
    public float ImpactSoundVolume;
    public int KillPoints = 5;
    public AudioClip KillSound;
    public float KillSoundVolume = 0.5f;

    void Start () {
        this.InvokeRepeating("Fire", Random.Range(0.1f, this.ProjectileCooldown), this.ProjectileCooldown);
    }

    void Fire () {
        var go = Instantiate(this.Projectile, this.gameObject.transform.position + new Vector3(0, -1), Quaternion.identity) as GameObject;
        go.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -this.ProjectileSpeed);
    }

    void OnTriggerEnter2D (Collider2D collider2D) {
        var laser = collider2D.gameObject.GetComponent <Projectile>();
        if (laser) {
            if (this.ImpactSound != null) {
                AudioClipHelper.PlayClipAt(this.ImpactSound, this.transform.position, this.ImpactSoundVolume);
            }
            laser.Hit();
            this.Health -= laser.GetDamage();
            if (this.Health <= 0) {
                var scoreKeeper = FindObjectOfType <ScoreKeeper>();
                if (scoreKeeper != null) {
                    scoreKeeper.IncrementScore(this.KillPoints);
                }
                if (this.KillSound != null) {
                    AudioClipHelper.PlayClipAt(this.KillSound, this.transform.position, this.KillSoundVolume);
                }
                Destroy(this.gameObject);
            }
        }
    }

    public void Stop () {
        this.CancelInvoke("Fire");
    }

}
