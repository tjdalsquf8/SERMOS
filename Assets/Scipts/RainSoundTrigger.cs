using UnityEngine;

public class RainAudioPlayer : MonoBehaviour
{
    [SerializeField]
    private AudioClip rainDropClip; // �ν����Ϳ��� �Ҵ��� RainDrop ����� Ŭ��

    private AudioSource audioSource;

    void Awake()
    {
        // AudioSource ������Ʈ�� �������ų� ������ �߰��մϴ�.
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Start()
    {
        // AudioSource�� Ŭ���� �Ҵ��ϰ� �⺻ ������ �մϴ�.
        audioSource.clip = rainDropClip;
        audioSource.playOnAwake = false; // ���� ���� �� �ڵ� ����� ��Ȱ��ȭ�մϴ�.
    }

    // �÷��̾� �Ǵ� �ٸ� ��ü�� �� ������ �����ϸ� �� �Ҹ��� ����մϴ�.
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // 'Player' �±׸� ���� ��ü�� Ʈ���ſ� ������
        {
            audioSource.Play(); // �� �Ҹ� ���
        }
    }
}
