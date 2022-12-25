using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreenManager : MonoBehaviour
{
   public void ExitGame() {
    Application.Quit();
   }

   public void ReplayLevel() {
    SceneManager.LoadSceneAsync(SceneIDS.levelSceneID);
   }




}
