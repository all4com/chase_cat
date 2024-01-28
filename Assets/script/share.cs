using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class share : MonoBehaviour
{
    public int game = 0;
    public int max_sec = 60;
    public int now_sec = 0;

    // Start is called before the first frame update
    void Start()
    {
        now_sec = max_sec;
    }
    public int getPlaying()
    {
        return game;
    }

    public void stopPlaying()
    {
        game = 0;
    }

    public void startPlaying()
    {
        game = 1;
        resetPlayTime();
    }

    public int getPlayTime()
    {
        return now_sec;
    }
    public void resetPlayTime()
    {
        now_sec = max_sec;
    }
    public void downPlayTime()
    {
        now_sec -= 1;
    }
}
