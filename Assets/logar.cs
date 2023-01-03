using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class logar : MonoBehaviour
{
    public TMP_InputField usuario;
    public TMP_InputField senha;
    
    public void logar_jogador()
    {
        Login login = new Login(usuario.text.ToString(), senha.text.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
