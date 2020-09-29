using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controle : MonoBehaviour
{
    public GameObject F1, F2, S1, S2, T1, T2;  //variaveis que armazenam os personagens
    public bool f1, f2, s1 , s2, t1, t2,c1,c2,c3; //variaveis boleanas que sao ativas nos outros codigos
                                                    //para que eu possa spawnar os personagens e cenarios na cena do jogo
    public Vector3 pos1, pos2;     //a posiçao de spawn
    public Animator anim;   //componente de animaçao para ativar os cenarios

    // Start is called before the first frame update

    private void Awake()
    {

        /* o nome das variaveis sao 
         * F,S,T de
         * primeiro,segundo e terceiro personagem
         * e o numero 1 é de player 1
         * e o numero 2 é de player 2
         exemplo : F1 = primeiro personagem, selecionado pelo player 1
         exemplo : F2 = primeiro personagem, selecionado pelo player 2
         */

        //variaveis de outros codigos
        f1 = Menu_selecao.F1; //variavel que verifica que se player1 selecionou 1º personagem
        f2 = Menu_selecao.F2; //variavel que verifica que se player2 selecionou 1º personagem
        s1 = Menu_selecao.S1;//variavel que verifica que se player1 selecionou 2º personagem
        s2 = Menu_selecao.S2;//variavel que verifica que se player2 selecionou 2º personagem
        t1 = Menu_selecao.T1;//variavel que verifica que se player1 selecionou 3º personagem
        t2 = Menu_selecao.T2;//variavel que verifica que se player2 selecionou 3º personagem
        c1 = selecao_cenario.c1; //variavel que verifica se o cenario 1 foi selecionado
        c2 = selecao_cenario.c2;//variavel que verifica se o cenario 2 foi selecionad
        c3 = selecao_cenario.c3;//variavel que verifica se o cenario 3 foi selecionado
        
        if (f1 == true) //se o player 1 selecionou o personagem 1 
        {
            Instantiate(F1, pos1, Quaternion.identity); //spawna o personagem 1 na posição que eu colocar na variavel pos1
        }
        if (f2 == true) //se o player 2 selecionou o personagem 1 
        {
            Instantiate(F2, pos2, Quaternion.identity); //spawna o personagem 1 na posição que eu colocar na variavel pos2
        }
        if(s1 == true) 
        {
            Instantiate(S1, pos1, Quaternion.identity); //spawna o personagem 2 na posição que eu colocar na variavel pos1
        }
        if (s2 == true)
        {
            Instantiate(S2, pos2, Quaternion.identity);//spawna o personagem 2 na posição que eu colocar na variavel po2
        }
     if(t1 == true)
        {
            Instantiate(T1, pos1, Quaternion.identity);//spawna o personagem 3 na posição que eu colocar na variavel pos1
        }
        if (t2 == true)
        {
            Instantiate(T2, pos2, Quaternion.identity);//spawna o personagem 3 na posição que eu colocar na variavel po2
        }
        if(c1 == true) // se o cenario 1 for selecionado
        {
            anim.SetBool("cenario1", true); //roda a animação do cenario 1 e desativa os outros
            anim.SetBool("cenario2", false);
            anim.SetBool("cenario3", false);
        }
        if (c2 == true)
        {
            anim.SetBool("cenario1", false);
            anim.SetBool("cenario2", true); //roda a animação do cenario 2 e desativa os outros
            anim.SetBool("cenario3", false);
        }
        if (c3 == true)
        {
            anim.SetBool("cenario1", false);
            anim.SetBool("cenario2", false);
            anim.SetBool("cenario3", true); //roda a animação do cenario 3 e desativa os outros
        }
   }            

}