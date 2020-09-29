using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botoes1 : MonoBehaviour
{
    /*as animaçoes são rodadas através daquelas variaveis boleanas ou de variaveis float
     * igual esta na imagem, entao basicamente eu tenho variaveis pro personagem ir para todas as direçoes 
     e todos os 6 botoes são botoes para os golpes como todos essas variaveis em baixo;
     e elas estão como string porque eu consigo mudar o nome no editor do unity 
     assim eu consigo basicamente mudar a tecla que eu controlo o personagem
     como esta em uma das imagens que eu mandei
     */
    public string b1, b2, b3, b4, b5, b6;     //variaveis que servem para guardar os nomes dos botoes para que eu consiga modificar quais botoes o usuario ira jogar
    public string Cb1, Cb2, Cb3, Cb4, Cb5, Cb6; //variaveis que servem para guardar os nomes dos botoes de controles de video game
    public Animator anim;
    public float dano, danoSofrido;
    public static float danoInimigo;
    public bool atacando, coliders, InimigoAtacando;
    public static bool atackInimigo;

    // Start is called before the first frame update

    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        /*essa variavel abaixo recebe a informação de uma variavel no codigo Botoes1, que serve pra verificar se o inimigo esta atacando 
         assim eu consigo ver se o adversario esta atacando, e se o inimigo atacar e encostar em vc, solta a animaçao de levando hit*/
        InimigoAtacando = Botoes.atackInimigo;
        danoSofrido = Botoes.danoInimigo;


        if (Input.GetKeyDown(b1) || Input.GetKey(Cb1))  //verifica se o primeiro botao configurado no editor foi pressionado
                                                        // ou se o botao 0 de um controle foi pressiionado

        {
            anim.SetBool("Botao1", true);  // Botao1 na verdade é uma variavel boleana, e nessa linha de codigo ele esta definindo ela com true
                                           // é desse jeito que eu faço as animaçoes rodarem, como na imagem de exemplo

        }
        else
        {
            anim.SetBool("Botao1", false);
        }
        if (Input.GetKeyDown(b2) || Input.GetKey(Cb2))  // verifica se o botão do joystick 1 esta precionado
        {
            anim.SetBool("Botao2", true);  // ativa a 
        }
        else
        {
            anim.SetBool("Botao2", false);
        }
        if (Input.GetKeyDown(b3) || Input.GetKey(Cb3))  // verifica se o botão do joystick 1 esta precionado
        {
            anim.SetBool("Botao3", true);  // ativa a animação
        }
        else
        {
            anim.SetBool("Botao3", false);
        }
        if (Input.GetKeyDown(b4) || Input.GetKey(Cb4))  // verifica se o botão do joystick 1 esta precionado
        {
            anim.SetBool("Botao4", true);  // ativa a animação
        }
        else
        {
            anim.SetBool("Botao4", false);
        }
        if (Input.GetKeyDown(b5) || Input.GetKey(Cb5))  // verifica se o botão do joystick 1 esta precionado
        {
            anim.SetBool("Botao5", true);  // ativa a animação

        }
        else
        {
            anim.SetBool("Botao5", false);

        }
        if (Input.GetKeyDown(b6) || Input.GetKey(Cb6))  // verifica se o botão do joystick 1 esta precionado
        {
            anim.SetBool("Botao6", true);  // ativa a animação
        }

        else
        {
            anim.SetBool("Botao6", false);

        }

        atackInimigo = atacando;
        danoInimigo = dano;

        if (coliders == true && InimigoAtacando == true && atacando == false) // verifica se o inimigo esta te encostando e se vc esta levando hit
        {
            anim.SetBool("hit", true);
            barraVida2.vidaAtual = barraVida2.vidaAtual - danoSofrido;  // a barra de vida é uma imagem que eu conigo modificar por scripts
        }
        else
        {
            anim.SetBool("hit", false);
        }
    }

    void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.gameObject.tag == "trigger")
        {
            coliders = true;

        }
    }
    void OnTriggerExit2D(Collider2D hit)
    {
        if (hit.gameObject.tag == "trigger")
        {
            coliders = false;
        }
    }
}