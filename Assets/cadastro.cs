using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class cadastro : MonoBehaviour
{
    public TMP_InputField nome;
    public TMP_InputField usuario;
    public TMP_InputField senha;

    // Start is called before the first frame update
    public void cadastrar_itens()
    {
        Cadastrar cadastrar = new Cadastrar(usuario.text.ToString(), nome.text.ToString(), senha.text.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
