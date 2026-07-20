using UnityEngine;
using UnityEngine.UIElements;

public class FollowLightDir : MonoBehaviour
{
    private PlayerControls PC;
    public bool LightDir;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
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
