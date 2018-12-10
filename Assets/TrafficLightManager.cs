using UnityEngine;
using System;
using UnityEngine.AI;

public class TrafficLightManager : MonoBehaviour {

    //Semáforos
    public GameObject First;
    public GameObject Second;
    public GameObject Third;
    public GameObject Fourth;

    //Faixas
    public NavMeshLink FirstLink;
    public NavMeshLink SecondLink;
    public NavMeshLink ThirdLink;
    public NavMeshLink FourthLink;

    //Luzes de cada semáforo
    private Renderer[] renderersFirst;
    private Renderer[] renderersSecond;
    private Renderer[] renderersThird;
    private Renderer[] renderersFourth;

    //Collider de cada faixa
    private BoxCollider firstCollider;
    private BoxCollider secondCollider;
    private BoxCollider thirdCollider;
    private BoxCollider fourthCollider;
    
    private DateTime changed;    
    private int state = 0; //0 aberto, 2 amarelo, 3 fechado (sempre para o veículo)

    // Use this for initialization
    void Start () {
        //Recebe todas as luzes de cada semáforo
        renderersFirst = First.transform.GetComponentsInChildren<Renderer>();
        renderersSecond = Second.transform.GetComponentsInChildren<Renderer>();
        renderersThird = Third.transform.GetComponentsInChildren<Renderer>();
        renderersFourth = Fourth.transform.GetComponentsInChildren<Renderer>();

        //Recebe collider de cada semáforo para ativar somente quando o sinal estiver fechado naquele semáforo
        firstCollider = First.GetComponent<BoxCollider>();
        secondCollider = Second.GetComponent<BoxCollider>();
        thirdCollider = Third.GetComponent<BoxCollider>();
        fourthCollider = Fourth.GetComponent<BoxCollider>();

        change(state);
        state++;
        changed = DateTime.Now;
    }
	
	// Update is called once per frame
	void Update () {
        if (DateTime.Compare(changed.AddSeconds(GameManager.SECONDS_CHANGE_TRAFFIC_LIGHT), DateTime.Now) < 0) {
            change(state);
            state++;

            if(state == 3) {
                state = 0;
            }
            changed = DateTime.Now;
        }        
	}

    void change(int state) {
        switch (state)
        {
            case 0: //Somente pedestre
                //Primeira
                //Pedestre aberto
                renderersFirst[1].material.EnableKeyword("_EMISSION");  //Verde
                renderersFirst[2].material.DisableKeyword("_EMISSION"); //Amarelo
                renderersFirst[3].material.DisableKeyword("_EMISSION"); //Vermelho

                //Veículo fechado
                renderersFirst[4].material.DisableKeyword("_EMISSION"); //Verde
                renderersFirst[5].material.DisableKeyword("_EMISSION"); //Amarelo
                renderersFirst[6].material.EnableKeyword("_EMISSION");  //Vermelho

                //Segunda
                //Pedestre aberto
                renderersSecond[1].material.EnableKeyword("_EMISSION");  //Verde
                renderersSecond[2].material.DisableKeyword("_EMISSION"); //Amarelo
                renderersSecond[3].material.DisableKeyword("_EMISSION"); //Vermelho

                //Veículo fechado
                renderersSecond[4].material.DisableKeyword("_EMISSION"); //Verde
                renderersSecond[5].material.DisableKeyword("_EMISSION"); //Amarelo
                renderersSecond[6].material.EnableKeyword("_EMISSION");  //Vermelho

                //Terceira
                //Pedestre aberto
                renderersThird[1].material.EnableKeyword("_EMISSION");  //Verde
                renderersThird[2].material.DisableKeyword("_EMISSION"); //Amarelo
                renderersThird[3].material.DisableKeyword("_EMISSION"); //Vermelho

                //Veículo fechado
                renderersThird[4].material.DisableKeyword("_EMISSION"); //Verde
                renderersThird[5].material.DisableKeyword("_EMISSION"); //Amarelo
                renderersThird[6].material.EnableKeyword("_EMISSION");  //Vermelho

                //Quarta
                //Pedestre aberto
                renderersFourth[1].material.EnableKeyword("_EMISSION");  //Verde
                renderersFourth[2].material.DisableKeyword("_EMISSION"); //Amarelo
                renderersFourth[3].material.DisableKeyword("_EMISSION"); //Vermelho

                //Veículo fechado
                renderersFourth[4].material.DisableKeyword("_EMISSION"); //Verde
                renderersFourth[5].material.DisableKeyword("_EMISSION"); //Amarelo
                renderersFourth[6].material.EnableKeyword("_EMISSION");  //Vermelho

                FirstLink.enabled = true;
                SecondLink.enabled = true;
                ThirdLink.enabled = true;
                FourthLink.enabled = true;

                firstCollider.enabled = true;
                secondCollider.enabled = true;
                thirdCollider.enabled = true;
                fourthCollider.enabled = true;

                break;

            case 1: //Somente veículo 1 e 3
                //Primeira
                //Pedestre fechado
                renderersFirst[1].material.DisableKeyword("_EMISSION");  //Verde
                renderersFirst[2].material.DisableKeyword("_EMISSION"); //Amarelo
                renderersFirst[3].material.EnableKeyword("_EMISSION"); //Vermelho

                //Veículo aberto
                renderersFirst[4].material.EnableKeyword("_EMISSION"); //Verde
                renderersFirst[5].material.DisableKeyword("_EMISSION"); //Amarelo
                renderersFirst[6].material.DisableKeyword("_EMISSION");  //Vermelho

                //Segunda
                //Pedestre
                renderersSecond[1].material.DisableKeyword("_EMISSION");
                renderersSecond[2].material.DisableKeyword("_EMISSION");
                renderersSecond[3].material.EnableKeyword("_EMISSION");

                //Veículo
                renderersSecond[4].material.DisableKeyword("_EMISSION");
                renderersSecond[5].material.DisableKeyword("_EMISSION");
                renderersSecond[6].material.EnableKeyword("_EMISSION");

                //Terceira
                //Pedestre
                renderersThird[1].material.DisableKeyword("_EMISSION");
                renderersThird[2].material.DisableKeyword("_EMISSION");
                renderersThird[3].material.EnableKeyword("_EMISSION");

                //Veículo
                renderersThird[4].material.EnableKeyword("_EMISSION");
                renderersThird[5].material.DisableKeyword("_EMISSION");
                renderersThird[6].material.DisableKeyword("_EMISSION");

                //Quarta
                //Pedestre
                renderersFourth[1].material.DisableKeyword("_EMISSION");
                renderersFourth[2].material.DisableKeyword("_EMISSION");
                renderersFourth[3].material.EnableKeyword("_EMISSION");

                //Veículo
                renderersFourth[4].material.DisableKeyword("_EMISSION");
                renderersFourth[5].material.DisableKeyword("_EMISSION");
                renderersFourth[6].material.EnableKeyword("_EMISSION");

                FirstLink.enabled = false;
                SecondLink.enabled = false;
                ThirdLink.enabled = false;
                FourthLink.enabled = false;

                firstCollider.enabled = false;
                secondCollider.enabled = true;
                thirdCollider.enabled = false;
                fourthCollider.enabled = true;

                break;

            case 2: //Somente veículo 2 e 4
                //Pedestre
                renderersFirst[1].material.DisableKeyword("_EMISSION");  //Verde
                renderersFirst[2].material.DisableKeyword("_EMISSION"); //Amarelo
                renderersFirst[3].material.EnableKeyword("_EMISSION"); //Vermelho

                //Veículo
                renderersFirst[4].material.DisableKeyword("_EMISSION"); //Verde
                renderersFirst[5].material.DisableKeyword("_EMISSION"); //Amarelo
                renderersFirst[6].material.EnableKeyword("_EMISSION");  //Vermelho

                //Segunda
                //Pedestre fechado
                renderersSecond[1].material.DisableKeyword("_EMISSION");
                renderersSecond[2].material.DisableKeyword("_EMISSION");
                renderersSecond[3].material.EnableKeyword("_EMISSION");

                //Veículo aberto
                renderersSecond[4].material.EnableKeyword("_EMISSION");
                renderersSecond[5].material.DisableKeyword("_EMISSION");
                renderersSecond[6].material.DisableKeyword("_EMISSION");

                //Terceira                
                //Pedestre
                renderersThird[1].material.DisableKeyword("_EMISSION");
                renderersThird[2].material.DisableKeyword("_EMISSION");
                renderersThird[3].material.EnableKeyword("_EMISSION");

                //Veículo
                renderersThird[4].material.DisableKeyword("_EMISSION");
                renderersThird[5].material.DisableKeyword("_EMISSION");
                renderersThird[6].material.EnableKeyword("_EMISSION");

                //Quarta 
                //Pedestre
                renderersFourth[1].material.DisableKeyword("_EMISSION");
                renderersFourth[2].material.DisableKeyword("_EMISSION");
                renderersFourth[3].material.EnableKeyword("_EMISSION");

                //Veículo
                renderersFourth[4].material.EnableKeyword("_EMISSION");
                renderersFourth[5].material.DisableKeyword("_EMISSION");
                renderersFourth[6].material.DisableKeyword("_EMISSION");

                FirstLink.enabled = false;
                SecondLink.enabled = false;
                ThirdLink.enabled = false;
                FourthLink.enabled = false;

                firstCollider.enabled = true;
                secondCollider.enabled = false;
                thirdCollider.enabled = true;
                fourthCollider.enabled = false;

                break;
        }
    }
}
