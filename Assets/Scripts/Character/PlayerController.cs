using UnityEngine;
using UnityEngine.InputSystem;

namespace TWG.Character {
    /// <summary>
    /// Class reflecting functions and properties for players to interface with a Character entity.
    /// </summary>
    public class PlayerController: MonoBehaviour {

        // Stats (To be moved out)
        private int speed;

        // Player Settings (To be moved out)
        private int lookSpeed;

        // locals

        private float pitch = 0;
        private int maxLookPitch = 75;
        private int minLookPitch = -55;

        // Dependencies
        private Transform characterTransform;

        [SerializeField] private Transform headTransform;

        private void Awake() {
            characterTransform = this.gameObject.transform;
            // TODO: Link speed with Character Stats.
            speed = 5;
            // TODO: Link sensitivity with Player Options.
            lookSpeed = 5;
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

        void Move(Vector2 direction) {
            direction *= Time.deltaTime * speed;
            characterTransform.Translate(direction.x, 0, direction.y);
        }

        void TurnCamera(Vector2 direction) {
            direction *= Time.deltaTime * lookSpeed;

            characterTransform.Rotate(Vector3.up, direction.x, Space.World);

            pitch = Mathf.Clamp(pitch + direction.y,
                                minLookPitch,
                                maxLookPitch);

            headTransform.localRotation = Quaternion.Euler(-pitch, 0, 0);
        }
    }
}
