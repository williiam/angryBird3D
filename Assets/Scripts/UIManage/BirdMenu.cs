using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMenu : MonoBehaviour
{
    public static BirdMenu Instance;
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        int stage = ShootController.Instance.GetStage();
        if(stage == 0 || stage == 1) {
            this.gameObject.SetActive(true);
        }
        else if(stage == 2){
            this.gameObject.SetActive(false);
        }
    }
}
