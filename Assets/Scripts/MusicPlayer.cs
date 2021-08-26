using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour {
  

    private void Awake()
    {
        int NumberOfMusicPlayer=FindObjectsOfType<MusicPlayer>().Length;
        if (NumberOfMusicPlayer > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
        
    }

   
    
    
    
    
    
    
    // Use this for initialization
    void Start () {
        Invoke("LoadlevelFirst", 2f);
	}
	
	void LoadlevelFirst()
    {
        SceneManager.LoadScene(2);
    }
}
