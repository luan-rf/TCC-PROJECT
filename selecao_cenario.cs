using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class selecao_cenario : MonoBehaviour
{
    public float cenario_I; //variavel que determina a posição do cursor
    public float C_Hor,Hor; //variavel que armazena os eixos do analogico de um controle
    public GameObject C1,C2,C3; // variaveis que servem para ativar e desativar as imagens dos cenarios para que
												//o jogador saiba qual cenario ele esta escolhendo
    public static bool c1, c2, c3;			//variaveis que servem para saber qual cenario foi selecionado 
    public string b1, b2,b3; //variaveis que definem qual botao o usuario deve apertar para mudar de cenario
                             // Start is called before the first frame update

    void Start()
    {
        cenario_I = 1; //posição do cursor  = 1  
    }
    
    // Update is called once per frame
    void Update()
    {
        C_Hor = Input.GetAxisRaw("XboxH1");//variavel que armazena o analogico do controle 1
        Hor = Input.GetAxisRaw("Horizontal");//variavel que armazena o analogico do controle 1
       

        if (Hor > 0.9 || C_Hor > 0.9) //se o player1 apertar o botão pra ir pra direita no teclado ou
                                      //o analogico do controle 1 para ir para a direita
        {
            cenario_I += 2.5f;  //seleciona o personagem a direita
        }

        if (Hor < -0.9 || C_Hor < -0.9) //se o player1 apertar o botão pra ir pra esquerda no teclado ou
                                        //o analogico do controle 1 para ir para a esquerda
        {
            cenario_I -= 2.5f; //seleciona o personagem a esquerda
        }


        if (cenario_I > 30) // aqui não deixa o cursor passar de 30, o cursor de seleção de personagem vai de
                                 //1 a 10, 11 a 20,21,30  se passar de 30...
        {
            cenario_I = 1;  // indice do peronagem = 1
        }

        if (cenario_I >= 1 && cenario_I <= 10)
        {
            C1.SetActive(true); //player 1 seleciona o cenario 1 e desativa os outros
            C2.SetActive(false);
            C3.SetActive(false);

            if (Input.GetKey(b1) || Input.GetKey(b2))
            {
                c1 = true; //essa boleana serve para spawnar o cenario e rodar a animação do cenario da proxima cena
                C1.GetComponent<Renderer>().material.color = Color.red;// muda a cor da imagem para vermelho pra mostrar que o cenario foi selecionado
                SceneManager.LoadScene(3);// roda a proxima cena
            }
        }

        if (cenario_I >= 11 && cenario_I <= 20 )
        {
            C1.SetActive(false);
            C2.SetActive(true); //player 1 seleciona ocenario 1 e desativa os outros
            C3.SetActive(false);
            if (Input.GetKey(b1) || Input.GetKey(b2))
            {
                c2 = true; //essa boleana serve para spawnar o cenario e rodar a animação do cenario da proxima cena
                C2.GetComponent<Renderer>().material.color = Color.red;// muda a cor da imagem para vermelho pra mostrar que o cenario foi selecionado
                SceneManager.LoadScene(3);// roda a proxima cena
            }
        }

        if (cenario_I >= 21 && cenario_I <= 30 )
        {
            C1.SetActive(false); 
            C2.SetActive(false);
            C3.SetActive(true); //player  seleciona ocenario 1 e desativa os outros
            if  (Input.GetKey(b1) || Input.GetKey(b2))
            { 
                c3 = true; //essa boleana serve para spawnar o cenario e rodar a animação do cenario da proxima cena
                C3.GetComponent<Renderer>().material.color = Color.red;// muda a cor da imagem para vermelho pra mostrar que o cenario foi selecionado
                SceneManager.LoadScene(3); // roda a proxima cena
            }
        }
    }
}