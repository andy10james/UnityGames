using UnityEngine;
using UnityEngine.UI;

public class LoseText : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    this.GetComponent <Text>().text = "You achieved " + ScoreKeeper.Score + " points in";
	}
	
}
