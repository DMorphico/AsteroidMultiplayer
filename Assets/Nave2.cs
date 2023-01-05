using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class Nave2 : MonoBehaviour
{
    public Rigidbody2D rb;
    public float movementSpeed = 5f;
    public float rotationSpeed = 150f;
    float rotation;

    public GameObject tiro;

    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        if (Input.GetKey("down"))
            rb.AddForce(((Vector2)transform.up * -1 * movementSpeed) - rb.velocity, ForceMode2D.Force);
        else if (Input.GetKey("up"))
            rb.AddForce(((Vector2)transform.up * movementSpeed) - rb.velocity, ForceMode2D.Force);
    }
    // Update is called once per frame
    void Update()
    {
        float rotationDir = 0f;
        if (Input.GetKey("left"))
        {
            rotationDir = 1f;
        } else if (Input.GetKey("right"))
        {
            rotationDir = -1f;
        }
        rotation += rotationDir * Time.smoothDeltaTime * rotationSpeed;
        transform.localEulerAngles = new Vector3(0f, 0f, rotation);

        //Atirar com num0
        if (Input.GetKeyDown("[0]"))
        {
            Instantiate(tiro, this.transform.position + (transform.up * 0.5f), this.transform.rotation);
        }

        if (transform.position.x < -13)
            transform.position = new Vector2(-12f, transform.position.y);
        if (transform.position.x > 13)
            transform.position = new Vector2(12f, transform.position.y);
        if (transform.position.y < -6)
            transform.position = new Vector2(transform.position.x, -5);
        if (transform.position.y > 6)
            transform.position = new Vector2(transform.position.x, 5);
    }
}
