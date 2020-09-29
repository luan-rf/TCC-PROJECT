using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Menu_selecao : MonoBehaviour
{
    public float personagem_I_1; //variavel que determina a posição do cursor1
    public float personagem_I_2;//variavel que determina a posição do cursor2
    public float Hor, Hor2; //variavel que armazena os eixos do analogico do controle1
    public float C_Hor, C_Hor2;//variavel que armazena os eixos do analogico do controle2
    public GameObject f1, f2, s1, s2, t1, t2; // variaveis que servem para ativar e desativar as imagens dos personagens para que
                                              //o jogador saiba qual personagem ele esta escolhendo
    public static bool F1, F2, S1, S2, T1, T2; //variaveis que servem para saber qual cenario foi selecionado
    public bool selecionado_1, selecionado_2; //variaveis que verificam se 
    public string b1, b2, b3, b4, b5, b6;


    // Start is called before the first frame update
    void Start()
    {
        personagem_I_1 = 1; //posição do cursor do player 1  = 1  
        personagem_I_2 = 1; //posição do cursor do player 2  = 1  
    }



    void Update()
    {
        C_Hor = Input.GetAxisRaw("XboxH1");//variavel que armazena o analogico do controle 1
        Hor = Input.GetAxisRaw("Horizontal");//variavel que armazena o analogico do controle 1
        Hor2 = Input.GetAxisRaw("Horizontal2");//variavel que armazena o analogico do controle 1
        C_Hor2 = Input.GetAxisRaw("XboxH2");//variavel que armazena o analogico do controle 2

        if (Hor > 0.9 || C_Hor > 0.9) //se o player1 apertar o botão pra ir pra direita no teclado ou
                                      //o analogico do controle 1 para ir para a direita
        {
            personagem_I_1 += 2.5f;  //seleciona o personagem a direita
        }

        if (Hor < -0.9 || C_Hor < -0.9) //se o player1 apertar o botão pra ir pra esquerda no teclado ou
                                        //o analogico do controle 1 para ir para a esquerda
        {
            personagem_I_1 -= 2.5f; //seleciona o personagem a esquerda
        }


        if (personagem_I_1 > 30) // aqui não deixa o cursor passar de 30, o cursor de seleção de personagem vai de
                                 //1 a 10, 11 a 20,21,30  se passar de 30...
        {
            personagem_I_1 = 1;  // indice do peronagem = 1
        }



        if (personagem_I_1 >= 1 && personagem_I_1 <= 10)
        {
            f1.SetActive(true); //player 1 seleciona o personagem 1 e desativa os outros
            s1.SetActive(false);
            t1.SetActive(false);
            if (Input.GetKey(b1) || Input.GetKey(b2))
            {
                F1 = true;
                selecionado_1 = true;
                f1.GetComponent<Renderer>().material.color = Color.red;//muda a cor da imagem para vermelho 
            }
        }

        if (personagem_I_1 >= 11 && personagem_I_1 <= 20)
        {
            f1.SetActive(false);//player 1 seleciona o peronagem 2 e desativa os outros
            s1.SetActive(true);
            t1.SetActive(false);
            if (Input.GetKey(b1) || Input.GetKey(b2))
            {
                S1 = true;
                selecionado_1 = true;
                s1.GetComponent<Renderer>().material.color = Color.red;//muda a cor da imagem para vermelho 
            }
        }

        if (personagem_I_1 >= 21 && personagem_I_1 <= 30)
        {
            f1.SetActive(false);//player 1 seleciona o personagem 3 e desativa os outros
            s1.SetActive(false);
            t1.SetActive(true);
            if (Input.GetKey(b1) || Input.GetKey(b2))
            {
                T1 = true;
                selecionado_1 = true;
                t1.GetComponent<Renderer>().material.color = Color.red;//muda a cor da imagem para vermelho 
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////


        if (Hor2 > 0.9 || C_Hor2 > 0.9) //se o player2 apertar o botão pra ir pra direita no teclado ou
                                        //o analogico do controle 2 para ir para a direita
        {
            personagem_I_1 += 2.5f; //seleciona o personagem a direita
        }

        if (Hor2 < -0.9 || C_Hor2 < -0.9) //se o player1 apertar o botão pra ir pra esquerda no teclado ou
                                          //o analogico do controle 1 para ir para a esquerda
        {
            personagem_I_1 -= 2.5f;
        }


        if (personagem_I_1 > 30)  // aqui não deixa o cursor passar de 30, o cursor de seleção de personagem vai de
                                  //1 a 10, 11 a 20,21,30  se passar de 30...
        {
            personagem_I_1 = 1; // indice do peronagem = 1
        }

        if (personagem_I_2 >= 1 && personagem_I_2 <= 10)
        {
            f2.SetActive(true); //player 1 seleciona o peronagem 1 e desativa os outros
            s2.SetActive(false);
            t2.SetActive(false);

            if (Input.GetKey(b3) || Input.GetKey(b4))
            {
                F2 = true;
                selecionado_2 = true;
                f2.GetComponent<Renderer>().material.color = Color.red;//muda a cor da imagem para vermelho 
            }
        }

        if (personagem_I_2 >= 11 && personagem_I_2 <= 20 && Input.GetKey(b3) || Input.GetKey(b4))
        {
            f2.SetActive(false);//player 1 seleciona o peronagem 1 e desativa os outros
            s2.SetActive(true);
            t2.SetActive(false);
            if (Input.GetKey(b3) || Input.GetKey(b4))
            {
                S2 = true;
                selecionado_2 = true;
                s2.GetComponent<Renderer>().material.color = Color.red;//muda a cor da imagem para vermelho 
            }
        }

        if (personagem_I_2 >= 21 && personagem_I_2 <= 30)//player 1 seleciona o peronagem 1 e desativa os outros
        {
            f2.SetActive(false);
            s2.SetActive(false);
            t2.SetActive(true);
            if (Input.GetKey(b3) || Input.GetKey(b4))
                T2 = true;
            selecionado_2 = true;
            t2.GetComponent<Renderer>().material.color = Color.red;//muda a cor da imagem para vermelho 
        }

        if (selecionado_1 == true)
        {
            personagem_I_1 = 0;
            Hor = 0;
            C_Hor = 0;
        }
        if (selecionado_2 == true)
        {
            personagem_I_2 = 0;
            C_Hor2 = 0;
            Hor2 = 0;
        }
        /*  if(F1 == true) //se player1 escolher o personagem 1 
          {
              f1.GetComponent<Renderer>().material.color = Color.red;//muda a cor da imagem para vermelho 
                                                                      //para o jogador1 saber que o personagem foi selecionado
              selecionado_1 = true; //saber se o player1 selecionou um personagem 
            //  hor = 0;
          }

           if(S1 == true) //se player1 escolher o personagem 2
          {
              s1.GetComponent<Renderer>().material.color = Color.red; //muda a cor da imagem para vermelho 
                                                                      //para o jogador1 saber que o personagem foi selecionado
              selecionado_1= true;//saber se o player 1 selecionou um personagem 
           //   hor = 0;
          }
           if(T1 == true) //se player1 escolher o personagem 3
          {
              t1.GetComponent<Renderer>().material.color = Color.red;//muda a cor da imagem para vermelho 
                                                                      //para o jogador1 saber que o personagem foi selecionado
              selecionado_1 = true;//saber se o player1 selecionou um personagem 
         //     hor = 0;
          }
           if(F2 == true) //se player2 escolher o personagem 1
          {
              f1.GetComponent<Renderer>().material.color = Color.blue;//muda a cor da imagem para azul
                                                                      //para o jogador 2 saber que o personagem foi selecionado
              selecionado_2 = true;//saber se o player2 selecionou um personagem 
           //   hor2 = 0;
          }
           if(S2 == true) //se player2 escolher o personagem2
          {
              s2.GetComponent<Renderer>().material.color = Color.blue;//muda a cor da imagem para azul
                                                                      //para o jogador 2 saber que o personagem foi selecionado
              selecionado_2 = true;//saber se o player2 selecionou um personagem 
         //     hor2 = 0;
          }
           if(T2 == true) //se player2 escolher o personagem 3
          {
              t2.GetComponent<Renderer>().material.color = Color.blue;//muda a cor da imagem para azul
                                                                      //para o jogador 2 saber que o personagem foi selecionado
              selecionado_2 = true; //saber se o player2 selecionou um personagem  
          //    hor2 = 0;
          }*/
        if (selecionado_1 == true && selecionado_2 == true) //verifica se o player1 e o player2 selecionaram seus peronagens
        {
            SceneManager.LoadScene(2); //carrega a cena de numero 2
        }
    }
}


