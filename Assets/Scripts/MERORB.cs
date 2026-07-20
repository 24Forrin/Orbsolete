using System;
using UnityEngine;

public class MERORB : MonoBehaviour
{
    public GameObject NewOrb;
    public enum Orb
    {
        LightOrb, WaterOrb, SeedOrb, GroundOrb,
        FireOrb, AshOrb

    }
    public enum ObjectType
    {
        Orb,
        MossyDoor   
    }

    public bool isHeld = false;
    public Orb type;
    public ObjectType Objectypes ;
    public GameObject AshOrbPrefab;
    public GameObject FireOrbPrefab;
    public GameObject mossyDoor;
    public GameObject particleFire;
    public virtual void useAbility()
    {
        Debug.Log("HA");
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public Boolean TwinBall(MERORB orb1, MERORB orb2)
    {
        if (orb1.type == orb2.type)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    void OnCollisionEnter(Collision other)
    {
        MERORB OtherOrbs = other.gameObject.GetComponent<MERORB>();
        if (OtherOrbs != null)
        {
            Cook(this, OtherOrbs);
        }
    }
    public void Cook(MERORB orb1, MERORB orb2)
    {
        if (orb1.GetInstanceID() > orb2.GetInstanceID())
        {
            return;
        }
        
        if (orb1.type == Orb.LightOrb && orb2.type == Orb.LightOrb)
        {
            Vector3 PrioOrbPos = (orb1.transform.position + orb2.transform.position)/2f;
            Instantiate(NewOrb, PrioOrbPos, Quaternion.identity);
            Destroy(orb1.gameObject);
            Destroy(orb2.gameObject);
        }else if (orb1.type == Orb.FireOrb && orb2.Objectypes == ObjectType.MossyDoor){
            Destroy(orb1.gameObject);
            Destroy(orb2.gameObject);
        }
    }
}
