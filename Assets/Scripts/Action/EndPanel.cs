using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPanel : MonoBehaviour
{
   public void Exit()
   {
        Application.Quit();
   }

    public void Restsrt()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
