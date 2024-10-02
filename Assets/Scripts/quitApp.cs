using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quitApp : MonoBehaviour
{ 

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Quiting Application");
            Application.Quit();
            
        }
    }
}
