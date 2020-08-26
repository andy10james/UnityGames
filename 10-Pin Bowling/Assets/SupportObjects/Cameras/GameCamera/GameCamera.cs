using UnityEngine;

namespace KamiKana.TenPinBowling.Assets.SupportObjects.Cameras.GameCamera {

    public class GameCamera : MonoBehaviour {

        public bool FollowZ = false;
        public float ZBoundary = 1500;
        public float ZDelta = -275;

        private void Update () {
            if (!this.FollowZ) return;
            if (!GameObjects.BowlingBall.BowlingBall.ActiveBall) return;
            if (GameObjects.BowlingBall.BowlingBall.ActiveBall.transform.position.z + this.ZDelta > this.ZBoundary) return;
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, GameObjects.BowlingBall.BowlingBall.ActiveBall.transform.position.z + this.ZDelta);
        }

    }

}