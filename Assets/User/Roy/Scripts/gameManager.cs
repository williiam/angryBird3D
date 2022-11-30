using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public GameObject sp;
    
    // Start is called before the first frame update
    void Start()
    {
        sp.GetComponent<shootPointController>().setNewBird();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}