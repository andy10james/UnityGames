using UnityEngine;

[RequireComponent(typeof(Attacker))]
[RequireComponent(typeof(Animator))]
public class Lizard : MonoBehaviour {

    private Attacker _attacker;

    void Start() {
        this._attacker = this.GetComponent<Attacker>();
    }

    public void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.GetComponent<Defender>()) {
            this.GetComponent<Animator>().SetBool("isAttacking", true);
            this._attacker.Attack(collider.gameObject);
        }
    }

}
