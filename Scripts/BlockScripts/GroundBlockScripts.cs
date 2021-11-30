using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundBlockScripts : MonoBehaviour
{
    public Transform otherBlock;
    public float halfLenght = 100f;
    private Transform player;
    private float endOffset = 10f;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        MoveGround();
    }

    void MoveGround()
    {
        if (transform.position.z + halfLenght < player.transform.position.z - endOffset)//игрок заехал на другую платформу! если 194 меньше 205 по игроку
        {
            transform.position = new Vector3(otherBlock.position.x, otherBlock.position.y,
                otherBlock.position.z + halfLenght * 2);
        }
    }
}
