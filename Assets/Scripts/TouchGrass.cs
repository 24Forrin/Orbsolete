using UnityEngine;

public class TouchGrass : MonoBehaviour
{
    public Collider cl;
    public bool hasJumped = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cl = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Floor"))
        {
            hasJumped = false;
        }
    }
}
