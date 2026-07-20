using JetBrains.Annotations;
using UnityEditor.Rendering;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public GameObject BallSpawn;
    public Transform playerDepth;
    public PlayerControls player;
    public GrabElig grabRange;
    public bool spawning = false;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = playerDepth.position;
        if (Input.GetMouseButton(1)&&(!grabRange.Grabbed)&&!spawning)
        {
            spawning = true;
            Instantiate(BallSpawn, new Vector3(playerPos.x+player.direct/2, playerPos.y+0.5f, playerPos.z), Quaternion.identity);
        }else if (!Input.GetMouseButton(1)){
            spawning = false;
        }
    }
}
