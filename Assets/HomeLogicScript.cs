using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeLogicScript : MonoBehaviour
{
    public Text gameName;
    public GameObject sound;

    public void startGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
