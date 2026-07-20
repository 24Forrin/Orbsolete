using UnityEngine;
public class BouncerActive : MonoBehaviour
{
    public Collider bc;
    public Transform playerDepth;
    public PlayerControls player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bc = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = playerDepth.position;
        transform.position = new Vector3(playerPos.x+player.direct, 0.14f, playerPos.z);
        if(Input.GetMouseButton(0))
        {
            bc.isTrigger = false;
        }
        else
        {
            bc.isTrigger = true;
        }
    }
}
