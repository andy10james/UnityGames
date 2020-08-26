namespace KamiKana.TenPinBowling.Assets.GameObjects.BowlingPinSet {

    using UnityEngine;

    [RequireComponent(typeof(Animator))]
    public class BowlingPinSet : MonoBehaviour {

        private Animator _animator;

        private void Start() {
            this._animator = this.GetComponent<Animator>();
        }

        public void RaisePins() {
            if (!this._animator) return;
            this._animator.SetTrigger("raise");
            // Change this to raise each individual pin that is standing
        }

        public void LowerPins() {
            if (!this._animator) return;
            this._animator.SetTrigger("lower");
        }

        public void RenewPins() {
            Debug.Log("Renewing pins");
        }

    }

}

