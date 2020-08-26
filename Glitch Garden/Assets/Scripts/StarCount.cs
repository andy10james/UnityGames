using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class StarCount : MonoBehaviour {

    private Text _text;
    private static int Count = 4;

    void Start () {
        this._text = this.GetComponent <Text>();
        this._text.text = "0";
    }

    public static bool UseStars(int stars) {
        if (Count < stars) return false;
        Count -= stars;
        return true;
    }

    public static void AddStars (int stars) {
        Count += stars;
    }

    void Update () {
        this._text.text = Count.ToString();
    }

}
