using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class GrabElig : MonoBehaviour
{
    public Transform playerDepth;
    public Collider cl;
    public bool Grabbed;
    public PlayerControls player;
    public GameObject gb;
    public GameObject GrabbedObject;
    private GameObject PotentialTarget = null;
    public GameObject orbPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cl = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = playerDepth.position;
        transform.position = new Vector3(playerPos.x+player.direct, playerPos.y, playerPos.z);
        if (Input.GetMouseButtonDown(0))
        {
            if (GrabbedObject == null){
                grabOrb(PotentialTarget);
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            releaseOrb();
        }
    }
    void OnTriggerEnter(Collider other)
    {   
        if (GrabbedObject == null&&other.GetComponent<MERORB>()!=null)
        {
            if (PotentialTarget == null)
            {
                PotentialTarget = other.gameObject;
            }
        } 
    } 
    void OnTriggerExit(Collider other)
    {  
        if (other.gameObject == PotentialTarget)
        {
            PotentialTarget = null;
        } 
    }
    void grabOrb(GameObject other)
    {
        if (other == null){return;}
        MERORB othertarget = other.GetComponent<MERORB>();
        if (othertarget == null || othertarget.Objectypes != MERORB.ObjectType.Orb){return;}
        GrabbedObject = other;
        Rigidbody rb = GrabbedObject.GetComponent<Rigidbody>();
        GrabbedObject.transform.position = transform.position;
        GrabbedObject.transform.SetParent(gb.transform);
        rb.useGravity = false;
        rb.isKinematic = true;
        rb.interpolation = RigidbodyInterpolation.None;
        Grabbed = true;
    }
    void releaseOrb()
    {
    if (GrabbedObject == null){return;}
    Rigidbody rb = GrabbedObject.GetComponent<Rigidbody>();
    GrabbedObject.transform.SetParent(null);
    rb.useGravity = true;
    rb.isKinematic = false;
    GrabbedObject = null;
    Grabbed = false;
    }
    public void flipOrbDirection()
    {
        Debug.Log("flipOrbDirection");
        transform.Rotate(0,180,0);
    }
}
