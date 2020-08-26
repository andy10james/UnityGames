using UnityEngine;

public class AttackerBody : MonoBehaviour {

    private GameTimer _gameTimer;

    void Start () {
        this._gameTimer = FindObjectOfType <GameTimer>();
    }

    // To note:
    // Is call when the main camera becomes null (scene unloading)
    // When attacker leaves the camera view
    // Just before the attacker is destroyed
    void OnBecameInvisible() {
        var parent = this.gameObject.transform.parent;
        var parentHealth = parent.GetComponent <Health>();
        if (Camera.allCameras.Length != 0 && !this._gameTimer.IsEndOfLevel && parentHealth && parentHealth.HealthPoints > 0) {
            FindObjectOfType<LevelManager>().LoadLevel("Lose");
        }
    }

}
