using UnityEngine;

public class BallKiller : MonoBehaviour
{
    public Collider cl;
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
    if (other.CompareTag("LightOrb")||other.CompareTag("FireOrb"))
        {
        Destroy(other.gameObject);
        }
    if (other.CompareTag("Player"))
        {
        other.gameObject.transform.position = new Vector3(-15, -1, 0);
        }
    }
}
