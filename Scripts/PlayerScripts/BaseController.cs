using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    public Vector3 speed;//скорость транспорта направление

    public float xSpeed = 8f, zSpeed = 15f;//лево право вперед назад скорость

    public float accelerated = 15f, deccelerated = 10f;//ускорение и замедление

    protected float rotationSpeed = 10f;//скорость вращения
    protected float maxAngle = 10f;//макс поворот

    public float lowSoundPitch, normalSoundPitch, hightSoundPitch;//громкость музыки

    public AudioClip engineOnSound, engineOffSound;//звук движка
    private bool isSlow;//медленно едем или нет

    private AudioSource _soundManger;
    private void Awake()
    {
        _soundManger = GetComponent<AudioSource>();
        speed = new Vector3(0f, 0f, zSpeed);
    }

    protected void MoveLeft()//двигаем влево
    {
        speed = new Vector3(-xSpeed / 2f, 0f, speed.z);
    }
    protected void MoveRight()//двигаем вправо
    {
        speed = new Vector3(xSpeed / 2f, 0f, speed.z);
    }
    protected void MoveStraight()//двигаем прямо
    {
        speed = new Vector3(0f, 0f, speed.z);
    }

    protected void MoveNormal()
    {
        if (isSlow)
        {
            isSlow = false;
            _soundManger.Stop();
            _soundManger.clip = engineOnSound;
            _soundManger.volume = 0.3f;
            _soundManger.Play();

        }

        speed = new Vector3(speed.x, 0f, zSpeed);
    }

    protected void MoveSlow()
    {
        if (!isSlow)
        {
            isSlow = true;
            _soundManger.Stop();
            _soundManger.clip = engineOffSound;
            _soundManger.volume = 0.5f;
            _soundManger.Play();
        }

        speed = new Vector3(speed.x, 0, deccelerated);
    }
    
    protected void MoveFast()
    {
        
        speed = new Vector3(speed.x, 0, accelerated);
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
