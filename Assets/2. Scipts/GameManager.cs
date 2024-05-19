using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject enemy; // pirest

    public static GameManager instance;

    [Header("SystemMessage UI")]
    [SerializeField]
    private TextMeshProUGUI text;

    [Header("Player UI")]
    [SerializeField]
    private TextMeshProUGUI _text;

    public bool gameOver = false;


    private AudioSource _playerAudio;
    private Animator _playerAnim;
    private AudioSource _enemyAudio;
    private Animator _enemyAnim;

    private void Awake()
    {
        GameManager.instance = this;
        _playerAudio = player.GetComponent<AudioSource>();
        _playerAnim = player.GetComponent<Animator>();
        _enemyAnim = enemy.GetComponent<Animator>();
        _enemyAudio = enemy.GetComponent<AudioSource>();
    }
    void Update()
    {
        if (_playerAnim.GetBool("isWalk")) // player�� �Ȱ� ������ true
        {
            _enemyAudio.enabled = false; // player�� �Ȱ� ������ ���θ� �߼Ҹ��� �ȵ鸲
        }
        else
        {
            _enemyAudio.enabled = true;
        }
    }

    public TextMeshProUGUI GetPlayerGUI()
    {
        return _text;
    }
    

   
}
