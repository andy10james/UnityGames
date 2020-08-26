using UnityEngine;

public class Projectile : MonoBehaviour {

    [Range(0, 20)]
    public float Speed = 5;

    [Range(0, 50)]
    public float Damage = 10;

	void Update () {
	    this.transform.Translate(Vector3.right * this.Speed * Time.deltaTime);
	}

    void OnTriggerEnter2D (Collider2D collider) {
        var attacker = collider.gameObject.GetComponent <Attacker>();
        if (attacker) {
            attacker.TakeDamage(this.Damage);
            Destroy(this.gameObject);
        }
    }

}
