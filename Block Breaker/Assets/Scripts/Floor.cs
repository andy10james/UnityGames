using UnityEngine;

public class Floor : MonoBehaviour {

    public LevelManager LevelManager;

    private void Start () {
        this.LevelManager = this.LevelManager ?? FindObjectOfType <LevelManager>();
    }

    private void OnCollisionEnter2D (Collision2D collision) {
        BreakableBrick.BreakableCount = 0;
        this.LevelManager.LoadLevel("Lose");
    }

    private void OnTriggerEnter2D (Collider2D collider) {
        print("Trigger");
    }

}