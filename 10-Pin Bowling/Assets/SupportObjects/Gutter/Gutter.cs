using UnityEngine;

namespace KamiKana.TenPinBowling.Assets.SupportObjects.Gutter {

    using GameObjects.BowlingBall;

    public class Gutter : MonoBehaviour {

        public delegate void OnBallGutteredDelegate(BowlingBall ball);
        public static event OnBallGutteredDelegate OnBallGuttered;

        private void OnTriggerEnter (Collider collider) {
            var bowlingBall = collider.gameObject.GetComponent<BowlingBall>();
            if (bowlingBall) {
                OnBallGuttered.Invoke(bowlingBall);
                return;
            }
            Destroy(collider.gameObject);
        }

    }

}