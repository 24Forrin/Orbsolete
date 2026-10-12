using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GlobalLightActivation Sunlight;
    public GameObject[] darkBlocks;
    // The darkBlocks will have a rigid body when light is near it.
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < darkBlocks.Length; i++)
        {
            darkBlocks[i].GetComponent<Collider>().enabled = false;
            darkBlocks[i].GetComponent<MeshRenderer>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}