using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float X_Speed, Y_Speed;
    GameObject Cam;
    float Length;
    float Height;
    float startPosX, startPosY;

    private void Awake()
    {
        Height = GetComponent<SpriteRenderer>().bounds.size.y;
        Length = GetComponent<SpriteRenderer>().bounds.size.x;
        
        transform.position = Camera.main.ViewportToWorldPoint(Vector2.zero) + new Vector3(Length/2, Height/2, 10);
        transform.GetChild(0).transform.position = transform.position + new Vector3(Length, 0, 0);
        transform.GetChild(1).transform.position = transform.position - new Vector3(Length, 0, 0);

    }
    private void Start()
    {
        startPosX = transform.position.x;
        startPosY = transform.position.y;
    }


    private void FixedUpdate()
    {

        float dist = Camera.main.transform.position.x * X_Speed;
        float distY = Camera.main.transform.position.y * Y_Speed;

        transform.position = new Vector2(startPosX + dist, startPosY + distY);

        transform.rotation = Quaternion.identity;

        ParallaxEffect();
    }

    void ParallaxEffect()
    {
        float temp = (Camera.main.transform.position.x * (1 - X_Speed));
        if (temp > startPosX + Length)
        {
            startPosX += Length;
            print("fuck");
        }
        else if (temp < startPosX - Length)
        {
            startPosX -= Length;
        }
    }
}
