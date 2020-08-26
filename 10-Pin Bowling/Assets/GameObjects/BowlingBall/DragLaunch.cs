using UnityEngine;

namespace KamiKana.TenPinBowling.Assets.GameObjects.BowlingBall {

    public class DragLaunch : MonoBehaviour {

        private float _dragStartTime;
        private Vector2 _dragStartPosition;

        public void DragStart () {
            this._dragStartTime = Time.time;
            this._dragStartPosition = Input.mousePosition;
        }

        public void DragEnd () {
            var time = Time.time - this._dragStartTime;
            Vector2 curPosition = Input.mousePosition;
            var offset = curPosition - this._dragStartPosition;
            var velocity = new Vector3(offset.x, 0, offset.y / 1.5f / time);
            if (BowlingBall.ActiveBall) BowlingBall.ActiveBall.Launch(velocity);
        }

    }

}