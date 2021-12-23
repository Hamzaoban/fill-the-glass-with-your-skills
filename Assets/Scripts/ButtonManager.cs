using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// Happy Glass 
/// Credit: Satyam Parkhi
/// Email: satyamparkhi@gmail.com
/// Facebook : https://www.facebook.com/satyamparkhi
/// Instagram : https://www.instagram.com/satyamparkhi/
/// Whatsapp : +91 7050225661
/// </summary>
public class ButtonManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Home()
    {
        SceneManager.LoadScene("MainMenu");
    }
    int contc;
    public void Play()
    {
        //if (contc == 0)
        //{
        //    transform.parent.GetChild(2).gameObject.SetActive(true);
        //    contc++;
        //}
        //else
        //{
            SceneManager.LoadScene("LevelMenu");
        //}
    }
    public void Hint()
    {
        FindObjectOfType<AdMobManager>().Hint = true;
        FindObjectOfType<AdMobManager>().showInterstitial();
    }
    public void NextLevel()
    {
        if (FindObjectOfType<AdMobManager>())
        {
            FindObjectOfType<AdMobManager>().showInterstitial();
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Close()
    {
        transform.parent.gameObject.SetActive(false);
    }
    public void Ad()
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.TapGamesFever.KnockDownHit");
    }
}
