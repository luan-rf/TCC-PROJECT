using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mov_1 : MonoBehaviour

{
    public float velocidade;
    public float forcaPulo;
    public Vector2 movimento;  //a variavel movimento é uma variavel que armazena os valores do eixo x e y e verifica se e maior ou menor que zero
    public Vector2 movimento2;  //a variavel movimento é uma variavel que armazena os valores do eixo x e y e verifica se e maior ou menor que zero                             //para poder movimentar o personagem
    public static bool no_chao; //verifica se personagem esta no chao
    public Vector2 Tamanho_I; //essa variavel representa o tamanho inicial do personagem
    public Vector2 Tamanho_V; // e essa representa o tamanho inicial * -1 no eixo x
    public Animator anim;   //essa variavel armazena o componente animator do unity  //componente animator é o componente que controla as animações
    private GameObject P1;  //essa variavel serve para armazenar as informações da posição do Player 1
    GameObject P2;      //e essa variavel serve para armazenar as informações da posição do Player 2  para que eu consiga compara-las
    Rigidbody2D rb; // Rigidbody é o componente usado para simulações fisicas como a gravidade


    // public Transform p1;

    void OnTriggerEnter2D(Collider2D coll)         // ontriggerEnter é uma funçao onde verifica se o personagem esta colidindo com algo
    {
        if (coll.gameObject.tag == "chao")   // aqui ele verifica se o personagem esta colidindo com um objeto com a tag "chao"
        {
            no_chao = true;                  // e se ele estiver a variavel no_chao se torna verdadeira
        }

    }
    void OnTriggerExit2D(Collider2D coll)
    {

        if (coll.gameObject.tag == "chao")   // aqui e o oposto da função de cima
        {
            no_chao = false;                         // aqui ele verifica se o personagem não esta colidindo com um objeto com a tag "chao
        }
    }

    void Start()
    {
        anim = GetComponent<Animator>();  // a variavel anim = componente animator
        velocidade = 15f;           // aqui eu defino a velocidade do personagem
        rb = GetComponent<Rigidbody2D>();   //aqui eu pego o componente fisico
        P1 = GameObject.FindGameObjectWithTag("Player1");    // aqui eu procuro o personagem com a tag Player1
        P2 = GameObject.FindGameObjectWithTag("Player2");   // aqui eu procuro o personagem com a tag Player2
        Tamanho_I = transform.localScale; // aqui eu armazeno os tamanhos de x e y do personagem 
    }

    void FixedUpdate()
    {
        if (movimento.x > 0.1 || movimento2.x > 0.9 )           // verifica se o eixo horizontal é maior que 0.1
        {
            transform.Translate(Vector2.right * velocidade * Time.fixedDeltaTime); // move o personagem para direita

        }

        if (movimento.x < -0.1 || movimento2.x < -0.9)           // verifica se o eixo horizontal é maior que 0.1
        {
            transform.Translate(-Vector2.right * velocidade * Time.fixedDeltaTime); // move o personagem para direita
        }

        if (movimento.y > 0.5 && no_chao == true || movimento2.y > 0.5 && no_chao == true) //verifica se o eixo vertical é maior que 0.5 e se o personagem esta no chão
        {
            rb.velocity = (Vector2.up * forcaPulo); //aqui ele adiciona uma força para cima * a força do pulo
        }
    }
       void Update()
    {
        velocidade = 15f; // determina a velocidade do personagem
        movimento.x = Input.GetAxisRaw("Horizontal"); // a variavel movimento armazena os eixo x 
        movimento2.x = Input.GetAxisRaw("XboxH1"); //pega os eixo x do controle 
        movimento.y = Input.GetAxisRaw("Vertical"); // a variavel movimento armazena os eixo y  
        movimento2.y = Input.GetAxisRaw("XboxV1");  //pega o eixo y do controle

        Tamanho_V.x = Tamanho_I.x * -1;
        Tamanho_V.y = Tamanho_I.y;

        if (movimento.x == 0 || movimento2.x == 0)  // se o movimento for igual a zero 
        {
            anim.SetBool("parado", true); // solta a animaçao do personagem parado

            anim.SetFloat("Horizontal", 0); //a variavel horizontal = 0
        }

        if (movimento.x != 0  || movimento2.x != 0 ) // se o movimento do personagem for diferente de 0 
        {
            if (movimento.x > 0 )       //aqui movimenta o personagem para a direita
            {
                anim.SetFloat("Horizontal", movimento.x); //a variavel Horizontal esta recebendo o valor da varia movimento, mas so da cordenada x
                anim.SetBool("parado", false);          //a variavel boleana parado esta recendo o valor de falso
            }
          

            else if (movimento2.x ==  1 )       //aqui movimenta o personagem para a direita com o controle
            {
                anim.SetFloat("Horizontal", movimento2.x); //a variavel Horizontal esta recebendo o valor da varia movimento, mas so da cordenada x
                anim.SetBool("parado", false);          //a variavel boleana parado esta recendo o valor de falso
            }

           
            else if (movimento.x < 0 ) //aqui movimenta o personagem para a esquerda
            {
                anim.SetFloat("Horizontal", movimento.x); //a variavel Horizontal esta recebendo o valor da varia movimento, mas so da cordenada x
                anim.SetBool("parado", false);          //a variavel boleana parado esta recendo o valor de falso
            }

            else if (movimento2.x == -1) // aqui movimenta o personagem para a esquerda com o controle
            {
                
                anim.SetFloat("Horizontal", movimento2.x); //a variavel Horizontal esta recebendo o valor da varia movimento, mas so da cordenada x
                anim.SetBool("parado", false);          //a variavel boleana parado esta recendo o valor de falso
            }
            else
            {
                anim.SetBool("parado", true);    //se todos os movimentos forem = 0 , parado true
            }
        }

        if (movimento.y == 0)
        {
            anim.SetBool("pulo", false);  //a variavel pulo = false
        }

        if (movimento.y > 0.5 || movimento2.y > 0.5 ) // pula com o personagem se os eixos y != 0
        {
            anim.SetBool("pulo", true );  //a variavel pulo = false
        }
        else
        {
            anim.SetBool("pulo", false);
        }
        if (no_chao == false) // se o personagem nao estiver no chao 
        {
            anim.SetBool("pulo", true); //a variavel pulo = true
        }
        else
        {
            anim.SetBool("pulo", false); //a variavel pulo = false
        }

        if (movimento.y < -0.5 || movimento2.y < -0.5) // se o eixo vertical for menor que -0.5, agachado = true
        {
            anim.SetBool("pulo", false); //a variavel pulo = false
            anim.SetBool("agachado", true);      //a variavel agachado = true
        }

        else
        {
            anim.SetBool("agachado", false);   //a variavel agachado = true
        }

        if (transform.position.x > P2.transform.position.x)        //verifica se a posição do Player1 é maior do que a posição do player 2
        {
            transform.localScale = Tamanho_V;           // gira o persongem no eixo x em 180 graus
            anim.SetBool("Flip", true);     //a variavel flip = true, isso significa que o personagem rotaionou 180 graus no eixo x

        }
        else
        {
            transform.localScale = Tamanho_I;
            anim.SetBool("Flip", false); //a variavel flip = false
            // Volta a rotação original do personagem
        }

    }
}
