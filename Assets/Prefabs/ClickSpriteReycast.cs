using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSpriteReycast : MonoBehaviour
{
    // Start is called before the first frame update
    private bool clickHandled = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !clickHandled)
        {
            Vector2 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(clickPosition, Vector2.zero);

            if (hit.collider != null)
            {
                string gameObjTag = hit.collider.gameObject.tag;

                if (gameObjTag == "Ground")
                {
                    Debug.Log("Ground w zasiegu");
                    // Destroy(hit.collider.gameObject);
                }
                else if (gameObjTag == "Grass")
                {
                    Debug.Log("Grass w zasiegu");
                    // Destroy(hit.collider.gameObject);
                }
            }

            clickHandled = true;
        }
    }
}
