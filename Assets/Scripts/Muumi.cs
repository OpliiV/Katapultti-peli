using UnityEngine;
using UnityEngine.SceneManagement;

public class Muumi : MonoBehaviour
{
   public void Startgame()
   {
    SceneManager.LoadScene("Game");
   }

   public void QuitGame()
   {
      Application.Quit();
      
   }
}
