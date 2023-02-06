using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolesSelect : MonoBehaviour
{
    public Transform[] Stone_Holes;
    public string Childname;
    public GetChild getChild;
    public GameObject child;
    private int index;
    int j = 0;
    private int totalStonesPresent;
    public string[] holesToUse;
    public string[] Childs = { "Hole-1", "Hole-2","Hole-3","Hole-4","Hole-5","Hole-6","Hole-7","Hole-8","Hole-9","Hole-10","Hole-11","Hole-12","Hole-13","Hole-14" };
   

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray=Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray,out hit,100.0f))
            {
                if (hit.transform != null)
                {
                    PrintName(hit.transform.gameObject);                    
                }
            }
        }
    }
    
    public void PrintName(GameObject go)
    {
        
        Childname= go.name;
        totalStonesPresent = getChild.getStoneCount(Childname);
        print(Childname+ " has "+ totalStonesPresent+" stones.");
        index = Array.IndexOf(Childs, Childname);
        DetectHoles(index,totalStonesPresent);
        

    }
    public void DetectHoles(int index,int noOfStones)
    {
        int startFrom = index + 1;
        int parseUpto = startFrom + noOfStones;
        holesToUse = new string[noOfStones];
        int lenOfArray = 0;
        for (int i = startFrom; i < parseUpto; i++)
        {            
            holesToUse[lenOfArray++] = Childs[i];
            print("LENGTH : "+holesToUse.Length);
        }
        for(int i=0;i<holesToUse.Length;i++)
        {
            if ( string.IsNullOrEmpty(holesToUse[i]))
            {
                print("child array : "+Childs[j]);
                holesToUse[i] = Childs[j++];
            }
        }
        


        //printing the array
        for(int i=0;i<lenOfArray; i++)
        {
            print(holesToUse[i]);
        }
    }  
}


