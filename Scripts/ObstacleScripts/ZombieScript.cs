using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieScript : MonoBehaviour
{
    public GameObject bloodFXPrefabs;
    public float speed = 1f;

    private Rigidbody rb;

    private bool isAlive;
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (isAlive)
        {
            rb.velocity = new Vector3(0f, 0f, -speed);
        }
        
        if (transform.position.y < -10f)
        {
            gameObject.SetActive(false);
        }
    }

    void Die()
    {
        isAlive = false; 
        
        rb.velocity=Vector3.zero;
        GetComponent<Collider>().enabled = false;
        GetComponentInChildren<Animator>().Play("Idle");
        
        transform.rotation=Quaternion.Euler(90f,0f,0f);
        transform.localScale = new Vector3(1f, 1f, 0.2f);
        transform.position = new Vector3(transform.position.x, 0.2f, transform.position.z);
    }

    void DeactivateGameObject()
    {
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Bullet")
        {
            Instantiate(bloodFXPrefabs, transform.position, Quaternion.identity);
            
            Invoke(nameof(DeactivateGameObject),3f);
            GamePlayController.instance.IncreaseScore();
            Die();
        }
    }
}
