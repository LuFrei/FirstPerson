using UnityEngine;

namespace TWG {
    public class CharacterController3D: MonoBehaviour {

        private Transform characterTransform;

        void Move(Vector2 direction) {
            direction *= Time.deltaTime;
            characterTransform.Translate(direction.x, 0, direction.y);
        }

        private void Awake() {
            characterTransform = this.gameObject.transform;
        }

        private void Update() {
            Move(new Vector2(1, 1));
        }
    }
}
