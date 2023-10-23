using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MovePLayer : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb2d;
    private Vector2 localscale;

    private bool jump = false;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        localscale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        float move = transformMove((int)Input.GetAxisRaw("Horizontal")) * moveSpeed;

        if (move != 0) transform.localScale = new Vector3(localscale.x, localscale.y);
        rb2d.velocity = new Vector2(move, rb2d.velocity.y);

        if((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) && !jump)
        {
            jump = true;
            rb2d.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(DisableJump.ContainTags(collision.gameObject.tag))
        {
            jump = false;
        }
    }
    readonly Func<int, float> transformMove = (input) =>
    {
        if (input == -1f)
        {
            return -0.5f;
        }
        else if (input == 1f)
        {
            return 0.5f;
        }

        // Jeœli input nie pasuje do ¿adnego z tych przypadków, zwracamy wartoœæ domyœln¹.
        return input;
    };

    readonly struct DisableJump
    {
        private static readonly string[] tags = { "Ground", "Grass" };

        public static bool ContainTags(string tag)
        {
            return tags.Contains(tag);
        }
    }
}
