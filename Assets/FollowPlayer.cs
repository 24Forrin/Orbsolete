using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public bool isRotatingWithPlayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x+1, player.transform.position.y, -20f);
        if (isRotatingWithPlayer)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, player.transform.rotation.eulerAngles.y);
        }
    }
}
