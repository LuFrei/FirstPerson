using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController3D : MonoBehaviour
{
    [SerializeField] private PlayableCharacter playerData;
    [SerializeField] private Rigidbody rigidBody;
    
    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        Vector2 testDir = new Vector2(1, 0);
        Move(testDir);
    }

    void Move(Vector2 direction){
        rigidBody.AddForce(direction, ForceMode.Acceleration);
    }
}
