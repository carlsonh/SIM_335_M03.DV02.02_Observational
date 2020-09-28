using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class end_trigger : MonoBehaviour
{
    public game_manager gm;
    List<string> videos = new List<string>();
    // Start is called before the first frame update

    private void Awake()
    {
        videos.Add("https://player.vimeo.com/video/349658557?background=1");
        videos.Add("https://player.vimeo.com/video/348882771?background=1");
        videos.Add("https://player.vimeo.com/video/441339532?background=1");
    }
    void OnTriggerEnter()
    {

        Application.OpenURL(videos[Random.Range(0, videos.Count)]);
        gm.LevelComplete();
    }
}
