using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    
    public int score1;
    public int score2;
    public float timer;
    private int timer2;

    public GameObject display1;
    public GameObject display2;
    public GameObject timerDisplay;
    public GameObject winBG;
    public GameObject winText1;
    public GameObject winText2;
    public GameObject winText3;

    //Instanciando a classe usando o design Singleton. Qualquer variável ou função que sejam públicos podem ser acessados com ScoreManager.Instance.[variável ou função]
    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        timer2 = (int) timer;
        timerDisplay.GetComponent<TextMesh>().text = timer2.ToString();

        //Quando o timer chega em 0, anuncia o resultado
        if (timer <= 0)
        {
            winBG.GetComponent<SpriteRenderer>().enabled = true;
            winText1.GetComponent<MeshRenderer>().enabled = true;
            winText2.GetComponent<MeshRenderer>().enabled = true;
            winText3.GetComponent<MeshRenderer>().enabled = true;

            if (score1 > score2)
                winText2.GetComponent<TextMesh>().text = "Jogador 1 vence!";
            else if (score2 > score1)
                winText2.GetComponent<TextMesh>().text = "Jogador 2 vence!";
            else
                winText2.GetComponent<TextMesh>().text = "Empate!";
        }

        //5 segundos depois, reinicia a cena
        if (timer <= -5)
            Application.LoadLevel(Application.loadedLevel);
    }

    public void UpdateScore1()
    {
        display1.GetComponent<TextMesh>().text = score1.ToString();
    }

    public void UpdateScore2()
    {
        display2.GetComponent<TextMesh>().text = score2.ToString();
    }
}
