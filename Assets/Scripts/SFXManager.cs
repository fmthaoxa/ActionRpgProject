using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour {
    public AudioSource playerHurt;
    public AudioSource playerAttack;

    private static bool sfxManagerExist;
	// Use this for initialization
	void Start () {

        if (!sfxManagerExist)
        {
            sfxManagerExist = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    // Update is called once per frame
    void Update () {
		
	}
}
