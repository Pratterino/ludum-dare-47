﻿using System.Linq;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private float minSizeY = 10;
    private float maxSizeY = 50;
    private GameObject[] players;
    private float playerWidth;
    private float timeElapsed;
    const int xValueTrigger = 134;

    void Start()
    {
        minSizeY = Camera.main.orthographicSize;
        players = GameObject.FindGameObjectsWithTag("Player");
        playerWidth = players[0].GetComponentInChildren<SpriteRenderer>().bounds.size.x;
    }

    void SetCameraPos()
    {
        Vector3 middle = (players[0].transform.position + players[1].transform.position) * 0.5f;
       
        transform.position = new Vector3(
            middle.x,
            middle.y,
            transform.position.z
        );
    }

    void SetCameraSize()
    {
        //horizontal size is based on actual screen ratio
        float minSizeX = minSizeY * Screen.width / Screen.height;

        //multiplying by 0.5, because the ortographicSize is actually half the height
        float width = Mathf.Abs(players[0].transform.position.x - players[1].transform.position.x) * 0.5f;
        float height = Mathf.Abs(players[0].transform.position.y - players[1].transform.position.y) * 0.5f;

        //computing the size
        float camSizeX = Mathf.Max(width, minSizeX) + playerWidth;

        Camera.main.orthographicSize = Mathf.Clamp(Mathf.Max(height, camSizeX * Screen.height / Screen.width, minSizeY), minSizeY, maxSizeY);
    }

    void Update()
    {


        if (players[0].transform.position.x >= xValueTrigger || players[1].transform.position.x >= xValueTrigger)
        {
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, 95, 10f / timeElapsed);
            Camera.main.transform.position = new Vector3(150f, -81f, Camera.main.transform.position.z);

            timeElapsed += Time.deltaTime;
        }
        else
        {
            SetCameraPos();
            SetCameraSize();
        }
    }
}