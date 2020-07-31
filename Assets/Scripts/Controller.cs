using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public GameObject Player;
    Player playerSrc;
    public List<KeyCode> key;

    private void Start()
    {
        playerSrc = GetComponent<Player>();
    }
    private void FixedUpdate()
    {
        if (Input.GetKey(key[1]))
        {
            playerSrc.Flip = true;
            playerSrc.Move(-1f);
        }

        else if (Input.GetKey(key[2]))
        {
            playerSrc.Flip = false;
            playerSrc.Move(1f);
        }
        else
        {
            playerSrc.anim.SetBool("isRun", false);
        }

        if (Input.GetKeyDown(key[0]))
        {
            playerSrc.Jump();
            playerSrc.canJump = false;
        }
        
    }
}
