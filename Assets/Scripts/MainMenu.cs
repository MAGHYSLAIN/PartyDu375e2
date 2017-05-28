using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public  Canvas mainMenu;
    public  Canvas credit;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

     public void Quit()
    {
        Application.Quit();
           
    }
    public void StartGame()
    {
        SceneManager.LoadScene("MTL2");
    }
    public void Back()
    {
        mainMenu.gameObject.SetActive(true);
        credit.gameObject.SetActive(false);
    
    }
    public void Credit()
    {
        mainMenu.gameObject.SetActive(false);
        credit.gameObject.SetActive(true);
    }
}
