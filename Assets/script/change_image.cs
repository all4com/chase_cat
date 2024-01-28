using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class change_image : MonoBehaviour
{

    public Sprite cat1;
    public Sprite cat2;

    public int cnt;
    [SerializeField] SpriteRenderer img;
    static int img_num = 2;

    public float timeout;
    private float timeElapsed;

    public share s;



    // Update is called once per frame
    void Update()
    {
        if (s.getPlaying() == 0) return;
        timeElapsed += Time.deltaTime;
        if (timeElapsed > timeout)
        {
            switch (cnt % img_num)
            {
                case 0:
                    img.sprite = cat1;
                    break;
                case 1:
                    img.sprite = cat2;
                    break;
            }
            cnt++;
            timeElapsed = 0.0f;
        }
    }
}
