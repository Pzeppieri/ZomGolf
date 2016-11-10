//A Dewey
//Navigation Script
//Script to link each button with the Scene.

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NavigationScript : MonoBehaviour {


    #region Club Members
    //The Golf Club Canvas Option
    public GameObject GolfCanvas;

    //Bool for switching Canvas On/Off
    public bool CanvasISOn = false;

    #endregion


    #region Skill Members
    //SKILLS
    //The Skill Canvas Option
    public GameObject SkillCanvas;

    //Bool for switching Canvas On/Off
    public bool SkillISOn = false;

    #endregion

    #region ExitScreen Canvas
    public GameObject ExitScreenCanvas;

    #endregion

    //Please note that Levels are numbered in the Build Option, but the actual number that LoadScene partains to is the number on the far right.

    public void MainMenuToGame()
	{
        print("Die Pietro");
        //Goes to the Game Scene;
        //Application.LoadLevel("Game Scene (1)");
        SceneManager.LoadScene(0);

    }

    public void CharacterToMenu()
    {
        SceneManager.LoadScene(1);

    }


    
    public void ActivateGolfClubs()
    {
        GolfCanvas.SetActive(true);
        SkillCanvas.SetActive(false);

        //Left here just in case.
        //if (SkillISOn == true)
        //{
        //    SkillCanvas.SetActive(false);
        //}
        ////Press to toggle ClubCanvas on/off
        //CanvasISOn = !CanvasISOn;
        //if (CanvasISOn == true)
        //{
        //    //Will turn on Golf Canvas
        //    GolfCanvas.SetActive(true);
        //}
        //else
        //{
        //    //Will turn on Golf Canvas
        //    GolfCanvas.SetActive(false);
        //}

    }

    public void ActivateSkillScreen()
    {
        GolfCanvas.SetActive(false);
        SkillCanvas.SetActive(true);

        //if(CanvasISOn==true)
        //{
        //    GolfCanvas.SetActive(false);
        //}

        ////Press to toggle ClubCanvas on/off
        //SkillISOn = !SkillISOn;
        //if (SkillISOn == true)
        //{
        //    //Will turn on Golf Canvas
        //    SkillCanvas.SetActive(true);
        //}
        //else
        //{
        //    //Will turn on Golf Canvas
        //    SkillCanvas.SetActive(false);
        //}

    }


    public void MainMenuToCharacter()
	{
		//Goes to the Character Scene
		SceneManager.LoadScene(2);
	}
    public void ExitGameConfirmNoButtoN()
    {
        ExitScreenCanvas.SetActive(false);
    }

    public void ExitGameConfirmPopup()
    {
        ExitScreenCanvas.SetActive(true);
    }

	public void ExitGame()
	{
        print("QUIT");
		//Will quit program, right away.
		Application.Quit();
	}

	/* public void MainMenuToPurchase()
	{
		//Incase for purchasable
		Application.LoadLevel("Market Scene (4)");
	}
 */



	}

