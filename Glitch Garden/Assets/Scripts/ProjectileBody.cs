using UnityEngine;

public class ProjectileBody : MonoBehaviour {

    // Only applicable on objects with a Sprite renderer component
    void OnBecameInvisible() {
        Destroy(this.transform.parent.gameObject);
    }

}
