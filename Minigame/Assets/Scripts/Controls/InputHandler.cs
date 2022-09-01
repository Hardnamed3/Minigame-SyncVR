using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public Vector2 InputVector2 { get; private set; }//only 2d movement
    
    public Vector3 MousePosition { get; private set; }//in case of aiming implementation

    public bool sprint = false; 

    // Update is called once per frame
    void Update()
    {
        var x = Input.GetAxisRaw("Horizontal");
        var y = Input.GetAxisRaw("Vertical");
        sprint = Input.GetButton("Fire3");
        InputVector2 = new Vector2(x, y);
        //aiming
        //MousePosition = Input.mousePosition;
    }
}
