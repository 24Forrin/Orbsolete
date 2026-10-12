using UnityEngine;
using UnityEngine.SceneManagement;

public class BallKiller : MonoBehaviour
{
    public Transform respawnPoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
    if (other.CompareTag("LightOrb")||other.CompareTag("FireOrb"))
        {
        Destroy(other.gameObject);
        }
    if (other.CompareTag("Player"))
        {
        Debug.Log("Player has been Respawned");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
