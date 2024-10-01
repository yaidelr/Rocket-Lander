using UnityEngine.SceneManagement;
using UnityEngine;

public class CollisionHanfler : MonoBehaviour
{

    [SerializeField] float reloadDelay = 1f;
    [SerializeField] AudioClip crash;
    [SerializeField] AudioClip landed;

    AudioSource  audioSource;



    private void Start() {
        audioSource = GetComponent<AudioSource>();
    }

   private void OnCollisionEnter(Collision other) 
   {

        switch(other.gameObject.tag)
        {
            case "Enemy":
            audioSource.PlayOneShot(crash);
            CrashSecuence();
            
            break;

            case "Finish":
            audioSource.PlayOneShot(landed);
            Invoke("Nextlevel", reloadDelay);
            break;

        }

   }
    void CrashSecuence(){
        GetComponent<Movement>().enabled = false;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        Invoke("Reloadlevel" , reloadDelay);
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
