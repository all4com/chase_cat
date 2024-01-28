using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class obstacle : MonoBehaviour
{


    private GameObject obj;
    public float timeout;
    private float timeElapsed;
    public int rnd;
    public int percent = 50;

    public share s;

    // Start is called before the first frame update
    void Start()
    {
        obj = (GameObject)Resources.Load("young_man");
    }

    // Update is called once per frame
    void Update()
    {
        if (s.getPlaying() == 0) return;
        if (s.getPlayTime() <= 2) return;
        timeElapsed += Time.deltaTime;
        if (timeElapsed > timeout)
        {
            
            rnd = Random.Range(1, 100); 
            if(s.getPlayTime() <= 3)
            {
                rnd = 100;
            }
            if (rnd < percent)
            {
                Instantiate(obj, new Vector3(-13.0f, -3.3f, 0.0f), Quaternion.identity);
            }
            
            timeElapsed = 0.0f;
        }
    }
}
