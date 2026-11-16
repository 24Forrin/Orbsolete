using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GlobalLightActivation Sunlight;
    public GrabElig GrabbedOrb;
    public GameObject[] darkBlocks;
    // The darkBlocks will have a rigid body when light is near it.
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < darkBlocks.Length; i++)
        {
            darkBlocks[i].GetComponent<Collider>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GrabbedOrb.GrabbedObject != null)
        {
            if (GrabbedOrb.GetComponent<MERORB>().Objectypes == MERORB.ObjectType.Orb)
            {
                EnableDarkBlocks();
            }
        }
    }

    public void EnableDarkBlocks()
    {
        for (int i = 0; i < darkBlocks.Length; i++)
        {
            darkBlocks[i].GetComponent<Collider>().enabled = true;
        }
    }
}