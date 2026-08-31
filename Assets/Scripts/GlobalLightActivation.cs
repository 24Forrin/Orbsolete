using System.Collections;
using UnityEngine;

public class GlobalLightActivation : MonoBehaviour
{
    public bool Sunlight = true;
    public Light lightProperties;
    
    [Header("Transition Settings")]
    public float transitionDuration = 2.0f; // How long the transition takes in seconds
    
    private Quaternion dayRotation;
    private Quaternion nightRotation;
    public TriggerRelay LightTrigger;

    void Start()
    {
        // Save the starting "Day" rotation
        dayRotation = transform.rotation;
        
        // Calculate the "Night" rotation (adding 144 degrees on the X axis)
        nightRotation = dayRotation * Quaternion.Euler(144, 0, 0); 
    }

    // Call this method from your triggers or buttons!
    public void ActivateSun()
    {
        // Stop any currently running transitions so they don't fight each other if pressed twice quickly
        StopAllCoroutines(); 
        StartCoroutine(SunlightGradient());
    }

    private IEnumerator SunlightGradient()
    {
        float elapsedTime = 0f;
        
        // Figure out where we are starting and where we want to end up
        Quaternion startRot = transform.rotation;
        Quaternion targetRot = Sunlight ? nightRotation : dayRotation;
        
        Color startColor = lightProperties.color;
        Color targetColor = Sunlight ? Color.black : Color.white;

        // Loop until our timer reaches the desired duration
        while (elapsedTime < transitionDuration)
        {
            // Calculate completion percentage (0.0 to 1.0)
            float t = elapsedTime / transitionDuration;

            // Smoothly transition rotation and color
            transform.rotation = Quaternion.Slerp(startRot, targetRot, t);
            lightProperties.color = Color.Lerp(startColor, targetColor, t);

            elapsedTime += Time.deltaTime;
            yield return null; // Wait until next frame
        }

        // Force it to snap exactly to the target values at the very end to prevent floating-point errors
        transform.rotation = targetRot;
        lightProperties.color = targetColor;
        Sunlight = !Sunlight;
    }
}