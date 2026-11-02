using UnityEngine;

public class ActiveDarkBlocks : MonoBehaviour
{
    public SphereCollider cl;
    public LevelManager lm;
    public GameObject[] db;
    public BoxCollider bc;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void WhenSpawn()
    {
        cl = GetComponent<SphereCollider>();    
        lm = GetComponent<LevelManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other == null) return;
        bc = other.GetComponent<BoxCollider>();
        db = lm.darkBlocks; 
        for (int i = 0; i < lm.darkBlocks.Length; i++)
        {
            other.enabled = true;
            Debug.Log("Can Collide");

        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other == null) return;
        bc = other.GetComponent<BoxCollider>();
        db = lm.darkBlocks; 
        for (int i = 0; i < lm.darkBlocks.Length; i++)
        {
            other.enabled = false;
            Debug.Log("Cannot Collide");
        }
    }

}
