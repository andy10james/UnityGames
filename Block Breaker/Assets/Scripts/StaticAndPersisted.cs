using UnityEngine;

public class StaticAndPersisted : MonoBehaviour {

    private static StaticAndPersisted _instance;

    private void Awake () {
        if (_instance != null) {
            Destroy(this.gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

}