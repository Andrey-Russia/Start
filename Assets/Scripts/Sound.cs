using UnityEngine;
using UnityEngine.UI;

public class Sound : MonoBehaviour
{
    public Button Click;
    public AudioClip Soundeffect;

    public AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = Soundeffect;
        audioSource.playOnAwake = false;
        
        if (Click != null)
        {
            Click.onClick.AddListener(OnButtonPressed);
        }
    }

    void OnButtonPressed()
    {
        audioSource.Play();
    }
}
