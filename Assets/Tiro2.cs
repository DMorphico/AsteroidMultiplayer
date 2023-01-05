using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Rigidbody2D>().AddForce(transform.up * 1000);
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.x > 100 || this.transform.position.y > 100 || this.transform.position.x < -100 || this.transform.position.y < -100)
            Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Asteroide")
        {
            if (col.gameObject.GetComponent<Asteroid>().vida > 0)
            {
                col.gameObject.GetComponent<Asteroid>().vida -= 1;
            }
            else
            {
                Destroy(col.gameObject);
                ScoreManager.Instance.score2 += col.gameObject.GetComponent<Asteroid>().pontos;
                ScoreManager.Instance.UpdateScore2();
            }

            Destroy(gameObject);
        }

        if (col.gameObject.name == "nave")
        {
            Destroy(gameObject);
            ScoreManager.Instance.score2 += 10;
            ScoreManager.Instance.score1 -= 10;
            if (ScoreManager.Instance.score1 < 0)
                ScoreManager.Instance.score1 = 0;
            ScoreManager.Instance.UpdateScore2();
            ScoreManager.Instance.UpdateScore1();
        }
    }
}
