namespace KamiKana.TenPinBowling.Assets.GameObjects.BowlingBall {

    using UnityEngine;
    using Frame;

    [RequireComponent(typeof(Rigidbody), typeof(AudioSource))]
    public class BowlingBall : MonoBehaviour {

        public BowlingBall BowlingBallPrefab;
        public bool InPlay { get; private set; }

        private Rigidbody _rigidbody;
        private AudioSource _audio;

        public static BowlingBall ActiveBall;
        public delegate void OnBallLaunchedDelegate(BowlingBall ball);
        public static event OnBallLaunchedDelegate OnBallLaunched;

        private void Start () {
            ActiveBall = this.GetComponent<BowlingBall>();
            this._rigidbody = this.GetComponent <Rigidbody>();
            this._audio = this.GetComponent <AudioSource>();
            Frame.OnNewFrame += this.OnNewFrame;
        }

        public void Launch (Vector3 velocity) {
            if (this.InPlay) return;
            InPlay = true;
            this._audio.pitch = velocity.z/1300;
            this._audio.volume = 1300 / 2/ velocity.z;
            this._audio.Play();
            this._rigidbody.useGravity = true;
            this._rigidbody.velocity = velocity;
            OnBallLaunched.Invoke(this);
        }

        public void SetStart (float x) {
            if (this.InPlay) return;
            this.transform.position = new Vector3(x, this.transform.position.y, this.transform.position.z);
        }

        private void OnNewFrame() {
            Destroy(this.gameObject);
        }

        public void OnDestroy() {
            Frame.OnNewFrame -= this.OnNewFrame;
        }

    }

}