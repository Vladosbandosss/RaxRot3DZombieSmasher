using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    private PlayerController _playerController;
    private Animator _anim;
    void Start()
    {
        _playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        _anim = GetComponent<Animator>();
    }

    void ResetShooting()
    {
        _playerController.canShoot = true;
        _anim.Play("Idle");
    }
}
