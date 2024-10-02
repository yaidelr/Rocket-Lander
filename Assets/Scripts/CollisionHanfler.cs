using UnityEngine.SceneManagement;
using UnityEngine;

public class CollisionHanfler : MonoBehaviour
{

    [SerializeField] float reloadDelay = 2f;
    [SerializeField] AudioClip crash;
    [SerializeField] AudioClip landed;

    [SerializeField] ParticleSystem crashParticle;
    [SerializeField] ParticleSystem landedParticle;
    AudioSource  audioSource;
    public bool collisionDisabled = false;

    void Start() {
        audioSource = GetComponent<AudioSource>();

        crashParticle = GameObject.Find("explosion particle").GetComponent<ParticleSystem>();
        landedParticle = GameObject.Find("landing particle").GetComponent<ParticleSystem>();  
  
    }

    void Update() 
    {
        Debugkeys();
    }


    
    private void OnCollisionEnter(Collision other) 
   {

        switch(other.gameObject.tag)
        {
            case "Enemy":
            audioSource.PlayOneShot(crash);
            crashParticle.Play();
            CrashSecuence();
            break;

            case "Finish":
            audioSource.PlayOneShot(landed);
            landedParticle.Play();
            LandSecuence();
            break;

        }

   }
    
        void CrashSecuence(){
            if(!collisionDisabled){
                GetComponent<Movement>().enabled = false;
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                Invoke("Reloadlevel" , reloadDelay);
            }
            
        }

        void LandSecuence(){
            if(!collisionDisabled)
            {
                GetComponent<Movement>().enabled = false;
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                Invoke("Nextlevel", reloadDelay);
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

    void Debugkeys()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("Level Skipped!");
            Nextlevel();
        }

        else if(Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log("Collision: "+ collisionDisabled);
            collisionDisabled = !collisionDisabled;
        }
    
    
    }
}
