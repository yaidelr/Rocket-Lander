using UnityEngine.SceneManagement;
using UnityEngine;

public class CollisionHanfler : MonoBehaviour
{
   private void OnCollisionEnter(Collision other) 
   {
        switch(other.gameObject.tag)
        {
            case "Enemy":
            Reloadlevel();
            Debug.Log("You hit a wall!");
            break;

            case "Finish":
            Nextlevel();
            Debug.Log("Congrats you landed! ");
            break;

        }

   }

    private void Reloadlevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }

    private void Nextlevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;


       if(currentScene +1 == SceneManager.sceneCountInBuildSettings)
       {
            SceneManager.LoadScene(0);
       }
       else
       {
            SceneManager.LoadScene(currentScene + 1);
       }
            
    }

}
