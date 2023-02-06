using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class GetChild : MonoBehaviour
{
    
    public Transform parent;

    
    public HolesSelect holesSelect;
    public Transform[] holes;
    public GameObject Holes;
    int totalHoles = 0;
    private void Start()
    {
        totalHoles=Holes.transform.childCount;
        holes=new Transform[totalHoles];
        for (int i=0; i < totalHoles; i++)
        {
            holes[i]=Holes.transform.GetChild(i);
        }        
    }
    public int getStoneCount(string name)
    {
       int stoneCount = 0;
        for (int i = 0; i < holes.Length; i++)
        {
            if (name == holes[i].name.ToString())
            {
                stoneCount=holes[i].childCount;
            }
        }
        /*if (name == "Hole-4")
        {
            holesSelect.changeParent(parent);
        }*/
       
        return stoneCount;        
    }


}
