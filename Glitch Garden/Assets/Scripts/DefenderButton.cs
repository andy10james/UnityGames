using UnityEngine;
using UnityEngine.UI;

public class DefenderButton : MonoBehaviour {

    public SpriteRenderer[] Sprites;
    public Defender Defender;
    public int Price;

    private DefenderButton[] _defenderButtons;
    private Text _text;

    public static DefenderButton SelectedDefenderButton;

    void Start () {
        this._defenderButtons = FindObjectsOfType <DefenderButton>();
        this._text = this.GetComponentInChildren <Text>();
        this._text.text = this.Price.ToString();
    }

    void OnMouseUp() {
        this.Select();
    }

    public void Select () {
        DefenderButton.SelectedDefenderButton = this;
        foreach (var button in this._defenderButtons) {
            button.Unselect();
        }
        foreach (var sprite in this.Sprites) {
            sprite.color = Color.white;
        } 
    }

    public void Unselect () {
        foreach (var sprite in this.Sprites) {
            sprite.color = Color.black;
        }
    }

    public void SpawnAt (Vector3 gridPoint) {
        if (StarCount.UseStars(this.Price)) {
            Instantiate(this.Defender, gridPoint, Quaternion.identity);
        }
    }

}
