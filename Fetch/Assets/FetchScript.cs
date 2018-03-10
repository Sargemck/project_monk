using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FetchScript : MonoBehaviour {

    public Transform target;
    
    public Rigidbody2D rb;

    public float speed = 1f;
    public float rotationSpeed = 200f;

    IEnumerator Waiter()
    {
        yield return new WaitForSeconds(2f);
    }
    // Use this for initialization
    void Start () {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    void FixedUpdate(){
        //Vector2 direction = (Vector2)target.position - rb.position;
        //direction.Normalize();

        //float rotationAngle = Vector3.Cross(direction, transform.up).z;

        //rb.angularVelocity = rotationAngle * rotationSpeed;
        //rb.velocity = transform.up * speed;

        var dir = target.position - transform.position;

        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;

        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * speed);
    }
}
