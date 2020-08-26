using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public Attacker[] Attackers;

    public void Spawn (Attacker attacker) {
        Instantiate(attacker, new Vector3(this.transform.position.x, this.transform.position.y, -1), Quaternion.identity).transform.parent = this.transform;
    }

    void Update () {
        foreach (var attacker in this.Attackers) {
            var chanceToSpawn = (Time.deltaTime / 5 / attacker.SpawnRarity) * PlayerPrefsManager.GetDefaultDifficulty();
            var choice = Random.Range(.0f, 1.0f);
            if (choice < chanceToSpawn) {
                this.Spawn(attacker);
            }
        }
    }

}
