namespace KamiKana.TenPinBowling.Assets.GameObjects.Frame {

    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;
    using UnityEngine.UI;
    using BowlingBall;
    using BowlingPinSet.BowlingPin;
    using BowlingPinSet;
    using SupportObjects.Gutter;

    public class Frame : MonoBehaviour {

        public delegate void OnNewFrameDelegate();
        public static event OnNewFrameDelegate OnNewFrame;

        public Text BlownAwayText;
        public Text RemainingText;
        public Text TakenOutText;
        public BowlingBall BowlingBall;
        public BowlingPinSet BowlingPinSet;
        public float RaiseDistance;

        public bool AllSettled => this._pins.All(x => x.Settled);
        public int StandingCount => this._pins.Count(x => x.IsStanding);

        private readonly List <BowlingPin> _pins;
        private BowlingBall _ballEntered;

        public Frame () {
            this._pins = new List <BowlingPin>();
        }

        private void Start() {
            Gutter.OnBallGuttered += this.OnBallGuttered;
        }

        private void OnTriggerEnter (Collider collider) {
            var pin = collider.gameObject.GetComponent <BowlingPin>();
            if (pin) {
                this._pins.Add(pin);
                return;
            }
            var ball = collider.gameObject.GetComponent <BowlingBall>();
            if (ball) {
                this._ballEntered = ball;
                this.InvokeRepeating(nameof(this.FrameSettling), 5, 1);
            }
        }

        private void OnTriggerExit (Collider collider) {
            var pin = collider.gameObject.GetComponent <BowlingPin>();
            if (pin) this._pins.Remove(pin);
        }

        private void Update () {
            if (!this._ballEntered) return;
            var standingCount = this.StandingCount;
            if (this.BlownAwayText) this.BlownAwayText.text = (10 - this._pins.Count).ToString();
            if (this.RemainingText) this.RemainingText.text = standingCount.ToString();
            if (this.TakenOutText) this.TakenOutText.text = (10 - standingCount).ToString();

        }

        private void FrameSettling() {
            if (!this.AllSettled) return;
            this.CancelInvoke(nameof(this.FrameSettling));
            this.OnFrameSettled();
        }

        private void OnFrameSettled () {
            if (this.RemainingText) this.RemainingText.color = Color.green;
            this.Invoke(nameof(NewFrame), 2);
        }

        public void OnBallGuttered (BowlingBall ball) {
            if (this._ballEntered) return;
            this.NewFrame();
        }

        public void RaisePins() {
            if (!this.BowlingPinSet) return;
            this.BowlingPinSet.RaisePins();
        }

        public void LowerPins() {
            if (!this.BowlingPinSet) return;
            this.BowlingPinSet.RaisePins();
        }

        public void RenewPins() {
            if (!this.BowlingPinSet) return;
            this.BowlingPinSet.RenewPins();
        }

        private void NewFrame() {
            this._ballEntered = null;
            Instantiate(this.BowlingBall);
            OnNewFrame.Invoke();
        }

        private void OnDestroy() {
            Gutter.OnBallGuttered -= this.OnBallGuttered;
        }

    }

}