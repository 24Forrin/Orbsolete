using UnityEngine;

public class Server : MonoBehaviour
{
    public GameObject[] ListOrbs = new GameObject[0];  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    public void addOrb(GameObject orb)
    {
        // rename the orb to orb + the current length of the list
        GameObject[] newList = new GameObject[ListOrbs.Length + 1];
        for (int i = 0; i < ListOrbs.Length; i++)
        {
            newList[i] = ListOrbs[i];
        }
        newList[ListOrbs.Length] = orb;
        ListOrbs = newList;
    }
    public void removeOrb(GameObject orb)
    {
        // remove all game objects from the list that are equal to the orb, WITHOUT creating a new list.
        for (int i = 0; i < ListOrbs.Length; i++)
        {
            if (ListOrbs[i] == orb)
            {
                Debug.Log("Removing orb: " + orb.name);
                ListOrbs[i] = null;
            }
        }
    }
}
