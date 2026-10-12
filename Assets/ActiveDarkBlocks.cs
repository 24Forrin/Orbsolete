using UnityEngine;

public class ActiveDarkBlocks : MonoBehaviour
{
    public CircleCollider2D cl;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cl = GetComponent<CircleCollider2D>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
