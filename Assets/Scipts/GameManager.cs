using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject enemy; // pirest

    private AudioSource _playerAudio;
    private Animator _playerAnim;
    private AudioSource _enemyAudio;
    private Animator _enemyAnim;

    private void Awake()
    {
        _playerAudio = player.GetComponent<AudioSource>();
        _playerAnim = player.GetComponent<Animator>();
        _enemyAnim = enemy.GetComponent<Animator>();
        _enemyAudio = enemy.GetComponent<AudioSource>();
    }
    void Update()
    {
        if (_playerAnim.GetBool("isWalk") ) // player가 걷고 있으면 true
        {
            _enemyAudio.enabled = false; // player가 걷고 있을땐 살인마 발소리가 안들림
        }
        else
        {
            _enemyAudio.enabled = true;
        }
    }
}
