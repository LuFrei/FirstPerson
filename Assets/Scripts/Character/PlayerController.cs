using UnityEngine;
using UnityEngine.InputSystem;

namespace TWG.Character {
    public class PlayerController: MonoBehaviour {

        private int speed;
        private int lookSense;
        private Transform characterTransform;

        [SerializeField] private Transform headTransform;

        void Move(Vector2 direction) {
            direction *= Time.deltaTime * speed;
            characterTransform.Translate(direction.x, 0, direction.y);
        }

        void TurnCamera(Vector2 direction) {
            direction *= Time.deltaTime * lookSense;

            headTransform.Rotate(Vector3.up, direction.x, Space.World);
            headTransform.Rotate(Vector3.right, -direction.y);
        }

        private void Awake() {
            characterTransform = this.gameObject.transform;
            // TODO: Link speed with Character Stats.
            speed = 5;
            // TODO: Link sensitivity with Player Options.
            lookSense = 5;
        }

        private void Update() {
            // TODO: Implement proper Input System Events once we have the basics working.
            // These are test inputs.
            if(Keyboard.current.wKey.isPressed) {
                Move(new Vector2(0, 1));
            }
            if(Keyboard.current.sKey.isPressed) {
                Move(new Vector2(0, -1));
            }
            if(Keyboard.current.aKey.isPressed) {
                Move(new Vector2(-1, 0));
            }
            if(Keyboard.current.dKey.isPressed) {
                Move(new Vector2(1, 0));
            }
            TurnCamera(Mouse.current.delta.value);
        }
    }
}
