using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerV2 : MonoBehaviour
{

    public static GameManagerV2 Instance;

    public GameObject sp;

    public GameObject StillBird;

    public int RemainingBirds = 3;
    
    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        int level = SceneManager.GetActiveScene().buildIndex;
        SetNewBird();
    }

    // Update is called once per frame
    void Update()
    {
    
    }

     public void SetNewBird()
     {
        RemainingBirds--;
        if (RemainingBirds >= 0)
        {
            sp.GetComponent<shootPointController>().setNewBird();

            foreach (StillBird stillBird in FindObjectsOfType<StillBird>())
            {
                Destroy(stillBird.gameObject);
            }

            if (RemainingBirds > 0)
            {
                for (int i = 0; i < RemainingBirds; i++)
                {
                    GameObject stillBird = Instantiate(StillBird, new Vector3(0, 0, 0), Quaternion.identity);
                    stillBird.transform.Find("Bird Body").transform.position = new Vector3(-2.5f * (i + 1), 0, -3.19f);
                    if (i % 2 == 0)
                    {
                        stillBird.GetComponent<StillBird>().WaitForSeconds = 0.45f;
                    }
                }
            }
        }
     }
}