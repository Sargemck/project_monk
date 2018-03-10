using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour {

    public Rigidbody2D rb;
    public Rigidbody2D spring;

    public float unhookTime = .15f;
    public float maxSpringDistance = 2f;

    public GameObject nextBall;

    private bool isPressed;

    private void Update()
    {
        if (isPressed)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (Vector3.Distance(mousePos, spring.position) > maxSpringDistance)
                rb.position = spring.position + (mousePos - spring.position).normalized * maxSpringDistance;
            else
                rb.position = mousePos;
        }
    }

    void OnMouseDown ()
    {
        isPressed = true;
        rb.isKinematic = true;
        Debug.Log("Mouseclick");
    }

    private void OnMouseUp()
    {
        isPressed = false;
        rb.isKinematic = false;

        StartCoroutine(Unhook());
    }

    IEnumerator Unhook()
    {
        yield return new WaitForSeconds(unhookTime);

        GetComponent<SpringJoint2D>().enabled = false;

        yield return new WaitForSeconds(2f);

        if (nextBall != null)
        {
            nextBall.SetActive(true);
        }
        else
        {
            yield return new WaitForSeconds(4);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
