namespace KamiKana.TenPinBowling.Assets.GameObjects.UI {

    using UnityEngine;
    using BowlingBall;
    using Frame;
    using _BallSlider = BallSlider.BallSlider;

    public class UI : MonoBehaviour {

        private _BallSlider _ballSlider; 

        void Start() {
            this._ballSlider = this.GetComponentInChildren<_BallSlider>();
            BowlingBall.OnBallLaunched += this.OnBallLaunched;
            Frame.OnNewFrame += this.OnNewFrame;
        }

        private void OnBallLaunched(BowlingBall ball) {
            if (this._ballSlider) this._ballSlider.gameObject.SetActive(false);
        }

        public void OnNewFrame() {
            if (this._ballSlider) this._ballSlider.gameObject.SetActive(true);
        }

        void OnDestroy() {
            BowlingBall.OnBallLaunched -= this.OnBallLaunched;
            Frame.OnNewFrame -= this.OnNewFrame;
        }

    }

}
