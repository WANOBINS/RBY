using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Switch : MonoBehaviour {

    public Wall wall;
    public AudioClip boom;
    public Text Prompt;

    void OnTriggerEnter(Collider aCol)
    {
        Prompt.text.Equals("Press E to Activate Switch");
    }

    void OnTriggerStay(Collider aCol)
    {
        print("Player in trigger");


        if(Input.GetKeyDown(KeyCode.E))
        {
            AudioSource.PlayClipAtPoint(boom, wall.transform.position, 50.0f);
            Destroy(wall.gameObject);
            Destroy(gameObject);
        }
    }

    void OnTriggerExit(Collider aCol)
    {
        Prompt.text.Equals("");
    }
}
