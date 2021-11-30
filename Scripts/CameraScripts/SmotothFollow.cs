using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmotothFollow : MonoBehaviour
{
    private string TANKPLAYER = "Player";
    
    public Transform target;

    public float distace = 6.3f;//по z растояние будет
    public  float height=3.5f;

    public float heightDamping = 3.25f;
    public float rotationDamping = 0.27f;
    
    
    void Start()
    {
        target = GameObject.FindGameObjectWithTag(TANKPLAYER).transform;
    }
    
    void LateUpdate()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        float wantedRotationAngle = target.eulerAngles.y;
        float wantedHeight = target.position.y + height;

        float currentRotationAngle = transform.eulerAngles.y;
        float currentHeight = transform.position.y;

        currentRotationAngle =
            Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);
        
        currentHeight =
            Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);
        
        Quaternion currentRotation=Quaternion.Euler(0f,currentRotationAngle,0f);

        transform.position = target.position;
        transform.position -= currentRotation * Vector3.forward * distace;
        transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);
    }
}
