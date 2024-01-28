using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    public float human_speed = 0.4f;
    //走る用の関数
    public Sprite human_run1;
    public Sprite human_run2;
    public Sprite human_run3;

    //ぶつかる用の関数
    public Sprite human_freeze1;
    public bool collition_flg;
    public bool freeze_flg;
    private float freeze_time;
    static float freeze_limit = 0.4f;

    //ジャンプする用の関数
    private bool depression_flg;
    public bool flying_flg;
    public float flying_time;
    private bool landing_flg;

    // 回避用の判定
    public Sprite human_dodge;
    private bool dodge_flg;
    public float dodge_time;
    private float dodging_time;

    private int cnt;

    static int run_img_num = 4;

    public float timeout;
    private float timeElapsed;
    public share s;


    public float fly_time = 0.25f;
    [SerializeField] SpriteRenderer img;

    void Start()
    {
        flying_flg = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (s.getPlaying() == 0) return;
        timeElapsed += Time.deltaTime;
        //プレイヤーが進む処理
        if (!freeze_flg && !flying_flg)
        {
            transform.position += new Vector3(Time.deltaTime * human_speed * -1, 0, 0);
        }

        //プレイヤーが走る動き
        if (timeElapsed > timeout && freeze_flg != true)
        {

            switch (cnt % run_img_num)
            {
                case 0:
                    img.sprite = human_run1;
                    break;
                case 1:
                    img.sprite = human_run2;
                    break;
                case 2:
                    img.sprite = human_run3;
                    break;
                case 3:
                    img.sprite = human_run2;
                    break;
            }
            cnt++;
            timeElapsed = 0.0f;
        }
        //プレイヤーがぶつかったとき
        if (collition_flg == true)
        {
            freeze_time = 0;
            freeze_flg = true;
            collition_flg = false;
        }
        // ジャンプ！
        if (flying_flg == true)
        {
            flying_time += Time.deltaTime;
            if (flying_time > fly_time)
            {
                transform.position += new Vector3(0, -3, 0);
                flying_flg = false;
            }
        }
        //プレイヤーが止まる動き
        if (freeze_flg == true)
        {

            freeze_time += Time.deltaTime;
            img.sprite = human_freeze1;

            if (freeze_time > freeze_limit)
            {
                freeze_flg = false;
            }
        }
        // 回避処理
        if (dodge_flg)
        {
            dodging_time += Time.deltaTime;
            img.sprite = human_dodge;
            if (dodging_time > dodge_time)
            {
                dodge_flg = false;
                human_speed = 0.6f;
            }
        }

        //キー操作
        if (!freeze_flg && !flying_flg)
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                flying_flg = true;
                flying_time = 0;
                transform.position += new Vector3(0, 3, 0);
            }
            else if (Input.GetKeyDown(KeyCode.Return))
            {
                dodge_flg = true;
                dodging_time = 0;
                human_speed = 0.8f;
            }

        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (dodge_flg == true) return;
        transform.position += new Vector3(Time.deltaTime * 15.0f, 0, 0);
        collition_flg = true;
    }

    public void ResetPlayer()
    {
        transform.position = new Vector3(7, -2.25f, 0);
    }

    public float getPlayerPos()
    {
        return transform.position.x;
    }
}
