using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapScript : MonoBehaviour
{
    private bool SoundOn = false;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            GetComponent<MeshRenderer>().material.color = Color.red;
            gameObject.tag = "Trap";

            if (!SoundOn)
            {
                GetComponent<AudioSource>().Play();
                SoundOn = true;
            }
            
        }
    }
}
