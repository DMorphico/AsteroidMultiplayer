using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro1 : MonoBehaviour
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
        //Dá pontos ao colidir com o asteroide
        if (col.gameObject.tag == "Asteroide")
        {
            if (col.gameObject.GetComponent<Asteroid>().vida > 0)
            {
                col.gameObject.GetComponent<Asteroid>().vida -= 1;
            }
            else
            {
                Destroy(col.gameObject);
                ScoreManager.Instance.score1 += col.gameObject.GetComponent<Asteroid>().pontos;
                ScoreManager.Instance.UpdateScore1();
            }

            Destroy(gameObject);
        }

        //Rouba pontos do jogador inimigo
        if (col.gameObject.name == "nave_player_2")
        {
            Destroy(gameObject);
            ScoreManager.Instance.score1 += 10;
            ScoreManager.Instance.score2 -= 10;
            if (ScoreManager.Instance.score2 < 0)
                ScoreManager.Instance.score2 = 0;
            ScoreManager.Instance.UpdateScore1();
            ScoreManager.Instance.UpdateScore2();
        }
    }
}
