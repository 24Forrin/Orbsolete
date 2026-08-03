using System.Collections;
using UnityEngine;

public class GlobalLightActivation : MonoBehaviour
{
    public bool Sunlight=true;
    public Light lightProperties;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public IEnumerator sunlightGradient()
    {
        transform.Rotate(144,00,0);
        Sunlight = false;
        lightProperties.color = Color.black;
        for (float i = 0; i < 5; i += Time.deltaTime)
        {
            lightProperties.color = Color.Lerp(Color.black, Color.white, i);
            transform.Rotate(-2,00,0);
            yield return null;
        }
        transform.Rotate(-144,0,0);
        Sunlight = true;
        lightProperties.color = Color.white;
    }

    public void ActivateSun()
    {
        if (Sunlight)
        {
            transform.Rotate(144,00,0);
            Sunlight = false;
            lightProperties.color = Color.black;
        }
        else if (!Sunlight)
        {
            transform.Rotate(-144,0,0);
            Sunlight = true;
            lightProperties.color = Color.white;
        }
    }
}
