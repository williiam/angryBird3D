using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skillBtn : MonoBehaviour
{
    BirdManager birdManager;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(onClick);
    }

    public void onClick(){
        birdManager.CastSpell();
    }
}

