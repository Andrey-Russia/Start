using UnityEngine;

public class GunMove : MonoBehaviour
{
    public GameObject weapon;           
    public AudioClip shootSoundClip;
    public float movementSpeed = 5f;
    public float minVolume = 0.5f;
    public float maxVolume = 1.0f;
    public float stereoPanRange = 1.0f;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }

    void Update()
    {
        HandleWeaponRotation();
        CheckForFire();
    }

    void HandleWeaponRotation()
    {
        if (Input.GetKey(KeyCode.Q)) // Двигает оружие влево
        {
            weapon.transform.Translate(-Vector2.right * movementSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            weapon.transform.Translate(Vector2.right * movementSpeed * Time.deltaTime);
        }
    }

    void CheckForFire()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PlayShootSound();
        }
    }

    void PlayShootSound()
    {
        if (shootSoundClip && audioSource)
        {
            Vector3 center = Camera.main.WorldToScreenPoint(Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f)));
            Vector3 posOnScreen = Camera.main.WorldToScreenPoint(weapon.transform.position);

            float relPosX = Mathf.InverseLerp(center.x - Screen.width / 2, center.x + Screen.width / 2, posOnScreen.x);

            float panStereo = Mathf.Clamp(relPosX * stereoPanRange, -1f, 1f);
            audioSource.panStereo = panStereo;

            float volume = Mathf.Lerp(minVolume, maxVolume, Mathf.Abs(panStereo));
            audioSource.volume = volume;

            audioSource.PlayOneShot(shootSoundClip);
        }
    }
}
