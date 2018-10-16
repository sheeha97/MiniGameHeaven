using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBox : MonoBehaviour
{

    public float bounceHeight = 0.5f;
    public float bounceSpeed = 4f;

    public GameObject leftBound;
    public GameObject RightBound;
    public GameObject ground;


    private Vector2 originalPosition;

    public Sprite emptyBlockSprite;

    private bool canBounce = true;

    // Use this for initialization
    void Start()
    {
        originalPosition = transform.localPosition;
    }

    public void TriggernBlockBounce()
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
        GetComponent<Animator>().enabled = false;
        GetComponent<SpriteRenderer>().sprite = emptyBlockSprite;
    }

    IEnumerator Bounce()
    {
        ChangeSprite();
        //do something

        ground.GetComponent<BoxCollider2D>().enabled = false;
        //ground.GetComponent<Transform>().position = Vector3.zero;

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
