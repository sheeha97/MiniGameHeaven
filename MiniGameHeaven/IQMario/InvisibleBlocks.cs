using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleBlocks : MonoBehaviour
{

    public float bounceHeight = 0.5f;
    public float bounceSpeed = 4f;

    private Vector2 originalPosition;

    public Sprite emptyBlockSprite;

    private bool canBounce = true;
    

    // Use this for initialization
    void Start()
    {
        originalPosition = transform.localPosition;
        GetComponent<SpriteRenderer>().enabled = false;
    }

    public void InvisibleBlockBounce()
    {
        if (canBounce)
        {
            canBounce = false;

            StartCoroutine(Bounce());

        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ChangeSprite()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<Animator>().enabled = false;
        GetComponent<SpriteRenderer>().sprite = emptyBlockSprite;
    }


    IEnumerator Bounce()
    {
        ChangeSprite();


        while (true)
        {
            transform.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y + bounceSpeed * Time.deltaTime);
            if (transform.localPosition.y >= originalPosition.y + bounceHeight)
                break;

            yield return null;
        }

        while (true)
        {
            transform.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y - bounceSpeed * Time.deltaTime);
            if (transform.localPosition.y <= originalPosition.y)
            {
                transform.localPosition = originalPosition;
                break;
            }
            yield return null;

        }
    }
}
