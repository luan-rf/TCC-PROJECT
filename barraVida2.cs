using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class barraVida2 : MonoBehaviour
{
    public Image BarraVidaUI;  // imagem da quantidade da vida
    public static float vidaMax = 100, vidaAtual;


    void Start()
    {
        vidaAtual = vidaMax;
    }

    void Update()
    {
        BarraVidaUI.rectTransform.sizeDelta = new Vector2(vidaAtual / vidaMax * 550, 60);
        if (vidaAtual >= vidaMax)
        {
            vidaAtual = vidaMax;
        }
        if (Input.GetKey(KeyCode.Space)) vidaAtual = 100;
    }
}
