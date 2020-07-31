using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float camRange, camHeight;
    Vector2 startPos;

    private void Start()
    {
        startPos = transform.position;
    }
    private void FixedUpdate()
    {
        if (player != null)
        {
            transform.position = new Vector3(Mathf.Clamp(player.transform.position.x, startPos.x, camRange),
                Mathf.Clamp(player.transform.position.y, startPos.y, camHeight), -10);
        }
    }
}
