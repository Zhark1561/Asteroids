using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrap : MonoBehaviour
{
    
    public void ScreenWrapPlayer(GameObject player)
    {
        player.transform.position *= -1;
    }

    

}
