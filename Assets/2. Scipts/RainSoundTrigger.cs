using UnityEngine;

public class RainAudioPlayer : MonoBehaviour
{
    [SerializeField]
    private AudioClip rainDropClip; // 인스펙터에서 할당할 RainDrop 오디오 클립

    private AudioSource audioSource;

    void Awake()
    {
        // AudioSource 컴포넌트를 가져오거나 없으면 추가합니다.
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Start()
    {
        // AudioSource의 클립을 할당하고 기본 설정을 합니다.
        audioSource.clip = rainDropClip;
        audioSource.playOnAwake = false; // 게임 시작 시 자동 재생을 비활성화합니다.
    }

    // 플레이어 또는 다른 객체가 이 영역에 진입하면 비 소리를 재생합니다.
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // 'Player' 태그를 가진 객체가 트리거에 들어오면
        {
            audioSource.Play(); // 비 소리 재생
        }
    }
}
