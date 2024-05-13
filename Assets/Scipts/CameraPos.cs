using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPos : MonoBehaviour
{
    
    public static CameraPos Instance { get; private set; }
    
    [Header("following Pos")]
    [SerializeField]
    private Transform followingPos;

    [SerializeField]
    private Transform EnemyHead;

    private bool PlayerDiedLookAtEnemy = false;

    [SerializeField]
    private Transform PlayerHead;
    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
              Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        // transform.parent = followingPos;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (PlayerDiedLookAtEnemy)
        {
            PlayerHead.transform.LookAt(EnemyHead);
        }
    }
    public void SetPlayerDiedLookAtEnemy(bool value)
    {
        Debug.Log(value);
        PlayerDiedLookAtEnemy = value;
    }
}
