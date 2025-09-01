using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    [SerializeField] private GameObject hiveCam;
    [SerializeField] private GameObject fieldCam;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            hiveCam.SetActive(!hiveCam.activeSelf);
            fieldCam.SetActive(!fieldCam.activeSelf);
        }
    }
}

