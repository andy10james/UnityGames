using UnityEngine;

public class Health : MonoBehaviour {

    public float HealthPoints = 30;

    public bool Deduct (float damage) {
        this.HealthPoints -= damage;
        if (this.HealthPoints < 0) {
            Destroy(this.gameObject);
            return true;
        }
        return false;
    }

}
