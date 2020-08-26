using UnityEngine;

public class Projectile : MonoBehaviour {

    public float Damage = 100f;
    
    public void Hit () {
        Destroy(this.gameObject);
    }

    public float GetDamage () {
        return this.Damage;
    }

}
