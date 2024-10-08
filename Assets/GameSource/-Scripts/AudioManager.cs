using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;

    [SerializeField] private AudioClip _clickSound;
    [SerializeField] private AudioClip _collisionSound;
    [SerializeField] private AudioClip _basketSound;
    [SerializeField] private AudioClip _winSound;
    [SerializeField] private AudioClip _loseSound;
    [SerializeField] private AudioClip _launchSound;
    private AudioSource _audioSource;
    private CustomHapticManager _customHapticManager;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _customHapticManager = GetComponent<CustomHapticManager>();
    }

    public void PlayClickSound()
    {
        _audioSource.PlayOneShot(_clickSound);
        _customHapticManager.TriggerLightVibration();
    }
    public void PlayCollisionSound()
    {
        _audioSource.PlayOneShot(_collisionSound);
        _customHapticManager.TriggerLightVibration();
    }
    public void PlayBasketSound()
    {
        _audioSource.PlayOneShot(_basketSound);
        _customHapticManager.TriggerMediumVibration();
    }
    public void PlayWinSound()
    {
        _audioSource.PlayOneShot(_winSound);
        _customHapticManager.TriggerHeavyVibration();
    }
    public void PlayLoseSound()
    {
        _audioSource.PlayOneShot(_loseSound);
        _customHapticManager.TriggerErrorVibration();
    }
    public void PlayLaunchSound()
    {
        _audioSource.PlayOneShot(_launchSound);
        _customHapticManager.TriggerLightVibration();
    }
}