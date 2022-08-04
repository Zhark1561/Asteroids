using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryCheck : MonoBehaviour
{
    public GameEvent screenWrap;

    

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            screenWrap.Raise();
        }
        if (collision.tag == "Asteroid")
        {
            collision.transform.position *= -1;
        }
    }


}
