using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour {
    
         

    private static bool musicControllerExist;
    public AudioSource[] musicTracks;

    public int currentTrack;
    public bool musicCanPlay;

	// Use this for initialization
	
        void Start () {
        if (!musicControllerExist)
        {
            musicControllerExist = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    // Update is called once per frame
    void Update () {
        if (musicCanPlay)
        {
            if(musicTracks[currentTrack].isPlaying) {
                musicTracks[currentTrack].Play();
            }
        }
        else {
            musicTracks[currentTrack].Stop();
        }
	}
}
