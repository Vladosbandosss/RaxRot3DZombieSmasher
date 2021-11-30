using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : BaseController
{
    private Rigidbody _rb;

    public Transform bulletStartPoint;
    public GameObject bulletPrefab;
    public ParticleSystem shootFX;

    private Animator shootSliderAnim;

    [HideInInspector] public bool canShoot;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        shootSliderAnim = GameObject.Find("FireBar").GetComponent<Animator>();
        
        GameObject.Find("ShootBtn").GetComponent<Button>().onClick.AddListener(ShootingControll);//находим нашу кнопку и на нее шут контролл
        canShoot = true;
    }

    void Update()
    {
       ControlMovement();
       ChangeRotation();
       //ShootingControll();
    }

    private void FixedUpdate()
    {
        MoveTank();
    }

    void MoveTank()
    {
        _rb.MovePosition(_rb.position+speed*Time.deltaTime);//двигает с нашей поз по вектору speed
    }

    void ControlMovement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            MoveLeft();
        }
        if (Input.GetKey(KeyCode.D))
        {
            MoveRight();
        }
        if (Input.GetKey(KeyCode.W))
        {
            MoveFast();
        }
        if (Input.GetKey(KeyCode.S))
        {
            MoveSlow();
        }

        
        if (Input.GetKeyUp(KeyCode.A))
        {
            MoveStraight();
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            MoveStraight();
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            MoveNormal();
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            MoveNormal();
        }
       
        
    }

    void ChangeRotation()
    {
        if (speed.x>0)
        {
            transform.rotation=
                Quaternion.Slerp(transform.rotation,Quaternion.Euler(0f,maxAngle,0f),Time.deltaTime*rotationSpeed );
        }else if (speed.x<0)
        {
            transform.rotation=
                Quaternion.Slerp(transform.rotation,Quaternion.Euler(0f,-maxAngle,0f),Time.deltaTime*rotationSpeed );
        }
        else
        {
            transform.rotation=
                Quaternion.Slerp(transform.rotation,Quaternion.Euler(0f,0f,0f),Time.deltaTime*rotationSpeed );
        }
    }

    public void ShootingControll()
    {

        if (Time.timeScale != 0)
        {
            if (canShoot)
            {
                GameObject bullet = Instantiate(bulletPrefab, bulletStartPoint.position, Quaternion.identity);
                bullet.GetComponent<BulletScript>().Move(2000);
                shootFX.Play();

                canShoot = false;
                shootSliderAnim.Play("FadeIn");
            }
        }
        
    }
}
