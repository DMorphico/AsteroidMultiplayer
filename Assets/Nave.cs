using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class Nave : MonoBehaviour
{
    public Rigidbody2D rb;
    public float movementSpeed = 5f;
    public float rotationSpeed = 150f;
    float rotation; 

    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        float v = Input.GetAxisRaw("Vertical");
        rb.AddForce(((Vector2)transform.up * v * movementSpeed) - rb.velocity, ForceMode2D.Force);   
    }
    // Update is called once per frame
    void Update()
    {
        float rotationDir = 0f;
        if (Input.GetKey(KeyCode.A))
        {
            rotationDir = 1f;
        } else if (Input.GetKey(KeyCode.D))
        {
            rotationDir = -1f;
        }
        rotation += rotationDir * Time.smoothDeltaTime * rotationSpeed;
        transform.localEulerAngles = new Vector3(0f, 0f, rotation);
    }
}
