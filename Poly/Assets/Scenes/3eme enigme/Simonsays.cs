using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using Random = UnityEngine.Random;

public class Simonsays : MonoBehaviour
{
    /*
     * correspondance de couleurs :
     * 0 -> rouge
     * 1 -> vert
     * 2 -> bleu
     * 3 -> jaune
     *
     * 
     */

    private int timePause = 1; //la rapidite de l'espacement des lumieres

    private int Time = 30; //temps en seconde a laquelle se fait chaque enigmes

    //public Text disp;

    public Interactable levierRouge;
    public Interactable levierVert;
    public Interactable levierBleu;
    public Interactable levierJaune;

    public GameObject Light;



    public Material couleurGrise;

    public Material couleurRouge;
    public Material couleurVerte;
    public Material couleurBleue;
    public Material couleurJaune;
    
    // Start is called before the first frame update

    void lighton(int light)
    {
        switch (light)
        {
            case 0 :
                Light.GetComponent<MeshRenderer>().material = couleurRouge;
                break;
            case 1 :
                Light.GetComponent<MeshRenderer>().material = couleurBleue;
                break;
            case 2:
                Light.GetComponent<MeshRenderer>().material = couleurVerte;
                break;
            case 3:
                Light.GetComponent<MeshRenderer>().material = couleurJaune;
                break;
            default:
                Light.GetComponent<MeshRenderer>().material = couleurGrise;
                break;
        }
        
        
    }
    
    

    void waitFor(int seconds)
    {
        int timer = 0;
        
        while (timer < seconds)
            timer += 1;

        return;
    }

    void displaylevel(int[] lights)
    {
        foreach (var light in lights)
        {
            lighton(light);
            waitFor(timePause);
            lighton(4);
            waitFor(timePause);

        }
        
        
    }
    

    int adatp(int light, int modifier)
    {
        return (light + modifier) % 4;

    }


    int action()
    {
        (levierRouge.state, levierVert.state, levierBleu.state, levierJaune.state) = (false, false, false, false);

        while (!(levierRouge.state || levierVert.state || levierBleu.state || levierJaune.state))
            continue;

        if (levierRouge.state)
            return 0;
        if (levierVert.state)
            return 1;
        if (levierBleu.state)
            return 2;
        if (levierJaune.state)
            return 3;
        
        throw new Exception("La ia un soucis");

    }

    int[] getactions(int length)
    {
        int[] actions = new int[length];

        for (int i = 0; i < length; i++)
            actions[i] = action();

        return actions;
    }
    
    bool ClickLevel(int[] lights, int modifier)
    {
        for (int i = 0; i < lights.Length; i++)
        {
            lights[i] = adatp(i, modifier);
        }

        int[] actions = getactions(lights.Length);

        for (int i = 0; i < lights.Length; i++)
        {
            if (actions[i] != lights[i])
                return false;
        }

        return true;
    }

    private int TimeRemaining;

    void displaytext(int i)
    {
        // afficher numero de la manche (i+1) et timeremaining
    }
    
    void Start()
    {
        TimeRemaining = Time;


        for (int i = 0; i < 3; i++)
        {
            displaytext(i);
            int[] lights = createRandomLights(2*i + 4);
            displaylevel(lights);
            if (!ClickLevel(lights, i))
                i = 0;

        }
        
        //l'enigme est finie
    }

    int[] createRandomLights(int length)
    {
        int[] lights = new int[length];

        System.Random rand = new System.Random();
        for (int i = 0; i < length; i++)
        {
            lights[i] = rand.Next(4);
        }

        return lights;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
