using JetBrains.Annotations;
using UnityEngine;

public class GlobalLightActivation : MonoBehaviour
{
    public bool Sunlight=true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void ActivateSun()
    {
        if (Sunlight)
        {
            transform.Rotate(144,00,0);
            Sunlight = false;
        }
        else if (!Sunlight)
        {
            transform.Rotate(-144,0,0);
            Sunlight = true;
        }
    }
}
