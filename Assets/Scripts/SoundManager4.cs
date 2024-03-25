using UnityEngine;

public class SoundManager4 : MonoBehaviour
{
    public static SoundManager4 Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [SerializeField] private AudioSource _effectSource4;

    public void PlaySound4(AudioClip clip)
    {
        _effectSource4.PlayOneShot(clip);
    }
}
