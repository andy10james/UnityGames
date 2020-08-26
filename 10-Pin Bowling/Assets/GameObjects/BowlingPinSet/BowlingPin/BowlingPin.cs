namespace KamiKana.TenPinBowling.Assets.GameObjects.BowlingPinSet.BowlingPin {

    using UnityEngine;

    public class BowlingPin : MonoBehaviour {

        private Vector3 _previousPosition;
        private Vector3 _previousRotation;

        [HideInInspector]
        public bool Settled = true;

        [Tooltip ("The maximum square magnitude delta for the pin to be considered settled")]
        public float SettledThreshold = 10;

        [Tooltip ("The euler angle threshold for the pin to be considered standing")]
        public float StandingThreshold = 45;

        public bool IsStanding
            =>
                (this.transform.rotation.eulerAngles.x <= 270 + this.StandingThreshold
                && this.transform.rotation.eulerAngles.x >= 270 - this.StandingThreshold);

        private void Update () {}

        private void OnCollisionEnter (Collision collision) {
            this.Settled = false;
            this._previousPosition = this.transform.position;
            this._previousRotation = this.transform.rotation.eulerAngles;
            this.InvokeRepeating(nameof(this.Settling), 1, 1);
            this.Invoke(nameof(this.SettlingTimeout), 7.5f);
        }

        public void Settling () {
            if (Mathf.Abs(this._previousPosition.sqrMagnitude - this.transform.position.sqrMagnitude) > 10
                || Mathf.Abs(this._previousRotation.sqrMagnitude - this.transform.rotation.eulerAngles.sqrMagnitude)
                > 10) {
                this._previousPosition = this.transform.position;
                this._previousRotation = this.transform.rotation.eulerAngles;
                return;
            }
            this.Settled = true;
            this.CancelInvoke(nameof(this.Settling));
        }

        public void SettlingTimeout() {

        } 

    }

}