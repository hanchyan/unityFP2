using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ProximitySound : MonoBehaviour
{
    AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger enter by: " + other.name);

        if (other.CompareTag("Player"))
        {
            Debug.Log("Player detected — playing sound");
            audioSource.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioSource.Stop();
        }
    }
}
