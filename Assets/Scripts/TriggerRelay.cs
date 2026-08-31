using UnityEngine;

public class TriggerRelay : MonoBehaviour
{
    public LevelManager LM;
    public bool inSide;
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
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player has entered the trigger");
            LM.Sunlight.ActivateSun();
            inSide = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player has exited the trigger");
            LM.Sunlight.ActivateSun();
            inSide = false;
        }
    }
}
