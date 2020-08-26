using UnityEngine;

public class PlaySpace : MonoBehaviour {

    void OnMouseUp () {
        if (!DefenderButton.SelectedDefenderButton) return;
        var worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var gridPoint = new Vector3(Mathf.Round(worldPoint.x), Mathf.Round(worldPoint.y) ,-1);
        DefenderButton.SelectedDefenderButton.SpawnAt(gridPoint);
    }

}
