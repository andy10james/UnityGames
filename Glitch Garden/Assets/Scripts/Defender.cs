using UnityEngine;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Animator ))]
public class Defender : MonoBehaviour {

    public bool CanAttack;

    private Health _health;
    private Animator _animator;
    private EnemySpawner _spawner;

    void Start () {
        var defenders = GameObject.Find("Defenders");
        if (!defenders) {
            defenders = new GameObject("Defenders");
            defenders.transform.position = new Vector3(0, 0, -1);
        }
        this.transform.parent = defenders.transform;
        this._animator = this.GetComponent <Animator>();
        this._health = this.GetComponent <Health>();
        this._spawner = this.GetSpawner();
    }

    void Update () {
        if (this.CanAttack) this._animator.SetBool("isAttacking", this.IsAttackerAheadInLane());
    }

    private bool IsAttackerAheadInLane () {
        if (!this._spawner) return false;
        if (this._spawner.transform.childCount == 0) return false;
        foreach (Transform attacker in this._spawner.transform) {
            if (attacker.transform.position.x > this.transform.position.x + 0.25) return true;
        }
        return false;
    }

    private EnemySpawner GetSpawner () {
        var spawners = GameObject.FindObjectsOfType <EnemySpawner>();
        foreach (var spawner in spawners) {
            if (spawner.transform.position.y == this.transform.position.y) {
                return spawner;
            }
        }
        return null;
    }

    public bool TakeDamage (float damage) {
        if (this.gameObject == null) return false;
        this._animator.SetTrigger("attacked");
        if (this._health) return this._health.Deduct(damage);
        return false;
    }

    public void FireProjectile (GameObject prefab) {
        var projectile = GameObject.Find("Projectiles");
        if (!projectile) projectile = new GameObject("Projectiles");
        var go = Instantiate(prefab, projectile.transform) as GameObject;
        go.transform.position = this.transform.position;
    }

}
