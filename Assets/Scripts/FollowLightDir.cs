using UnityEngine;
using UnityEngine.UIElements;

public class FollowLightDir : MonoBehaviour
{
    private PlayerControls PC;
    public bool LightDir;
    public Transform orbLight;
    public GrabElig GE;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
    }

    void Update()
    {
        if (GE.CurrentlyHeldOrb == this.gameObject)
        {
            orbLight.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            orbLight.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }
    // Update is called once per frame
    public void FlipDirection(bool Lightdir)
    {
        if (Lightdir)
        {
            transform.Rotate(-25,90,0);
        }
        else if (!Lightdir)
        {
            transform.Rotate(-25,270,0);
        }
    }
}
