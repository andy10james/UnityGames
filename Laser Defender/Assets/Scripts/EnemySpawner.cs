using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour {

    public GameObject EnemyPrefab;
    public float Speed = 5;
    public float Padding;
    public float Height;
    public float Width;
    public float SpawnDelay = 1f;
    public float SpawnRate = 0.5f;

    private bool _spawning;
    private float _minX;
    private float _maxX;
    
	void Start () {
	    this._minX = Camera.main.ViewportToWorldPoint(new Vector3(0, 0)).x + this.Width / 2 + this.Padding;
	    this._maxX = Camera.main.ViewportToWorldPoint(new Vector3(1, 0)).x - this.Width / 2 - this.Padding;
	    this.SpawnEnemies();
	}
	
	void Update () {
	    var newX = Mathf.Clamp(this.transform.position.x + (this.Speed * Time.deltaTime), this._minX, this._maxX);
	    this.transform.position = new Vector3(newX, this.transform.position.y, this.transform.position.z);
        if (newX == this._minX || newX == this._maxX) this.Speed = -this.Speed;
        if (!this._spawning && this.AllMembersDead()) this.SpawnEnemies();
    }

    void OnDrawGizmos () {
        Gizmos.DrawWireCube(this.transform.position, new Vector3(this.Width, this.Height));
    }

    void SpawnEnemies () {
        this._spawning = true;
        this.InvokeRepeating("SpawnEnemy", this.SpawnDelay, this.SpawnRate);
    }

    void SpawnEnemy () {
        var position = this.GetRandomFreePosition();
        if (position != null) {
            var go = Instantiate(this.EnemyPrefab, position.transform.position, Quaternion.identity) as GameObject;
            go.transform.parent = position;
            return;
        }
        this._spawning = false;
        this.CancelInvoke("SpawnEnemy");
    }

    bool AllMembersDead () {
        foreach (Transform child in this.transform) {
            if (child.childCount > 0) {
                return false;
            }
        }
        return true;
    }

    List<Transform> GetFreePositions () {
        var list = new List<Transform>();
        foreach (Transform child in this.transform) {
            if (child.childCount == 0) {
                list.Add(child);
            }
        }
        return list;
    }

    Transform GetRandomFreePosition () {
        var freePositions = this.GetFreePositions();
        var selection = Random.Range(1, freePositions.Count);
        return freePositions.Skip(selection - 1).FirstOrDefault();
    }

    public void Stop () {
        this.Speed = 0.1f;
        foreach (var child in this.gameObject.GetComponentsInChildren <Enemy>()) {
            child.Stop();
        }
    }

}
