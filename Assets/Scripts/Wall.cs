using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {

    void OnCollisionEnter(Collision aCol)
    {
        print("Collision Detected");

        if (aCol.gameObject.tag.Equals("Blue") && gameObject.tag.Equals("BlueWall"))
        {
            GameObject Blue = aCol.gameObject;
            Physics.IgnoreCollision(Blue.GetComponent<Collider>(), GetComponent<Collider>());
        }

        else if (aCol.gameObject.tag.Equals("Yellow") && gameObject.tag.Equals("YellowWall"))
        {
            GameObject Yellow = aCol.gameObject;
            Physics.IgnoreCollision(Yellow.GetComponent<Collider>(), GetComponent<Collider>());
        }

        else if (aCol.gameObject.tag.Equals("Red") && gameObject.tag.Equals("RedWall"))
        {
            GameObject Red = aCol.gameObject;
            Physics.IgnoreCollision(Red.GetComponent<Collider>(), GetComponent<Collider>());
        }
    }
}
