using UnityEngine;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Animator))]
public class Attacker : MonoBehaviour {

    [Range(0f, 1f)]
    public float CurrentSpeed = 0.5f;

    [Tooltip ("How often, on average, this attacker will spawn.")]
    [Range(1, 100)]
    public float SpawnRarity = 5;

    private Defender _currentTarget;
    private Health _health;

    private Animator _animator;

    void Update () {
        this._animator = this.GetComponent <Animator>();
        this._health = this.GetComponent <Health>();
	    this.transform.Translate(Vector3.left * this.CurrentSpeed * Time.deltaTime);
	}

    public void SetSpeed (float speed) {
        this.CurrentSpeed = speed;
    }

    public bool TakeDamage(float damage) {
        if (!this._animator) return false;
        return this._health.Deduct(damage);
    }

    public void DealDamage (float damage) {
        var finishingHit = this._currentTarget.TakeDamage(damage);
        if (finishingHit && this._animator) {
            this._animator.SetBool("isAttacking", false);
        }
    }

    public void Attack (GameObject target) {
        var defender = target.GetComponent <Defender>();
        if (defender) {
            this._currentTarget = defender;
        }
    }

}
