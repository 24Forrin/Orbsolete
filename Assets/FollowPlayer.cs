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
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -21f);
        if (isRotatingWithPlayer)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, player.transform.rotation.eulerAngles.y);
        }
    }
}
