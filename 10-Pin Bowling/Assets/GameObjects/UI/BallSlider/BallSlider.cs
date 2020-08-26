using UnityEngine;
namespace KamiKana.TenPinBowling.Assets.GameObjects.UI.BallSlider {

    using UnityEngine.UI;
    using BowlingBall;

    [RequireComponent (typeof (Slider))]
    public class BallSlider : MonoBehaviour {

        private Slider _slider;

        private void Start () {
            this._slider = this.GetComponent <Slider>();
            this._slider.onValueChanged.AddListener(this.OnChange);
        }

        public void OnChange (float newVal) {
            if (!BowlingBall.ActiveBall) return;
            BowlingBall.ActiveBall.SetStart(newVal);
        }        

    }

}