using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ClickSprite : MonoBehaviour
{
    // Start is called before the first frame update
    public float PlayerRadius = 5f;
    private void OnMouseUp()
    {
        string gameObjTag = gameObject.tag;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            Vector3 playerPosition = player.transform.position;
            //Debug.Log("Player Position: " + playerPosition);
            //Debug.Log("Block Position: " + transform.position);
            //Debug.Log("Magnitude : " + (transform.position - playerPosition).magnitude);
            if ((playerPosition - transform.position).magnitude < PlayerRadius)
            {
                //klinkn¹³eœ na coœ w zasiêgu
                if (gameObjTag == "Ground")
                {
                    Debug.Log("Ground w zasiegu");
                    return;
                    //Destroy(this.gameObject);
                }
                if (gameObjTag == "Grass")
                {
                    Debug.Log("Grass w zasiegu");
                    return;
                    //Destroy(this.gameObject);
                }
            }
            else Debug.Log("Poza zasiegiem");            
        }
    }
}
