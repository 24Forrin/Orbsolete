using UnityEngine;
public class MuralRead : MonoBehaviour
{
    public GameObject MuralText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MuralText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            MuralText.SetActive(true);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            MuralText.SetActive(false);
        }
    }
}
