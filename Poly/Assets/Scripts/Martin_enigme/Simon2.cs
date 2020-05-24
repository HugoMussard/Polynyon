using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class Simon2 : MonoBehaviour
{
    
    
    public Interactable levierRouge;
    public Interactable levierVert;
    public Interactable levierBleu;
    public Interactable levierJaune;

    public GameObject Lum;
    private int[] actions;
    private int level;
    int[][] lights = new int[3][]; 

    public Material couleurGrise;

    public Material couleurRouge;
    public Material couleurVerte;
    public Material couleurBleue;
    public Material couleurJaune;
    public bool finished;
    // Start is called before the first frame update

    void lighton(int color)
    {
        Material mat = new Material(couleurBleue);
        switch (color)
        {
            case 0:
                mat = couleurRouge;
                break;
            case 1 :
                mat = couleurBleue;
                break;
            case 2 :
                mat = couleurVerte;
                break;
            case 3 :
                mat = couleurJaune;
                break;
            default:
                mat = couleurGrise;
                break;

        }

        Lum.GetComponent<MeshRenderer>().material = mat;

    }

    IEnumerator Wait(float time, int[] lights)
    {
        foreach (var lu in lights)
        {


            lighton(lu);
            yield return new WaitForSeconds(time);
            lighton(5);
            yield return new WaitForSeconds(time);
        }
    }

    int adatp(int lum, int modifier)
    {
        return (lum + modifier) % 4;
    }

    void display(int[] lights)
    {
        StartCoroutine(Wait(0.5f, lights));
            Debug.Log("Chip");


    }


    bool CheckLevel(int[][] lights, int modifier)
    {
        
        for (int i = 0; i < lights.Length; i++)
        {
            lights[level][i] = adatp(i, modifier);
        }
        

        for (int i = 0; i < lights[level].Length; i++)
        {
            if (actions[i] != lights[level][i])
                return false;
        }

        return true;
    }

    
    void Start()
    {
        System.Random rand = new System.Random();

        level = 0;
        
        for (int i = 0; i < 3; i++)
        {
            Debug.Log("Bonjour");
            int length = 2 * i + 3;
            lights[i] = new int[length];
            
            for (int j = 0; j < length; j++)
            {
                lights[i][j] = rand.Next(4);
                Debug.Log("F");
            }
            
            Debug.Log("zboub");

        }
        
        display(lights[0]);
        finished = false;
        
    }

    private void resetactions()
    {
        actions = new int[0];
        
    }

    private void resetlevers()
    {
        
        (levierRouge.state, levierVert.state, levierBleu.state, levierJaune.state) = (false, false, false, false);
    }

    // Update is called once per frame
    void Update()
    {
        if (level == 4)
            finished = true;
            //exitfunction
        Debug.Log("ping");
        if (levierRouge.state)
        {
            actions.Append(0);

        }

        Debug.Log("Pong");
        if (levierVert.state)
        {
            actions.Append(1);
        }
        
        if (levierBleu.state)
        {
            actions.Append(2);
        }
        
        if(levierJaune.state)
        {
            actions.Append(3);
        }
        
        resetlevers();
        if (actions.Length != 0 && actions.Length == lights[level].Length)
        {
            if (CheckLevel(lights, level))
            {
                level++;
                display(lights[level]);
            }
            else
            {
                level = 0;
            }
            resetactions();
        }
        
        
            
    }
}
