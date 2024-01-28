using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class timer : MonoBehaviour
{
    public TextMeshProUGUI timer_text;
    private float timeElapsed = 100;
    public share s;
    public player p;
    public SpriteRenderer clear;
    public SpriteRenderer over;

    void Start()
    {
        s.startPlaying();
        clear.gameObject.SetActive(false);
        over.gameObject.SetActive(false);

    }
    // Update is called once per frame
    void Update()
    {
        if (s.getPlaying() == 0) return;
        if(s.getPlaying() > 1)
        {
            //clear.gameObject.SetActive(false);
            //over.gameObject.SetActive(false);
            //s.resetPlayTime();
            //p.ResetPlayer();
            //s.stopPlaying();
            SceneManager.LoadScene("title");
        }
        if (s.now_sec >= 0)
        {
            timeElapsed += Time.deltaTime;
            if (timeElapsed > 1.0f)
            {
                timer_text.text = "" + s.getPlayTime();
                timeElapsed = 0.0f;
                s.downPlayTime();
            }
        }
        else
        {
            // ゲーム画面終わり。 クリアかオーバーに移動
            s.stopPlaying();
            s.resetPlayTime();
            timeElapsed = 1;      //テキスト更新。1以上で更新される
            //p.ResetPlayer();
            if(p.getPlayerPos() <= -3)
            {
                clear.gameObject.SetActive(true);
            }
            else
            {
                over.gameObject.SetActive(true);
            }
        }
    }
}
