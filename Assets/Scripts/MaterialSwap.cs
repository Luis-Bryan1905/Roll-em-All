using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaterialSwap : MonoBehaviour
{
    Material CurrentMaterial;

    public Material Standard;
    public Material Gold;

    public bool IsGold = false;

    //in the editor this is what you would set as the object you wan't to change

    void Start()
    {
         CurrentMaterial = this.GetComponent<MeshRenderer>().material;
    }


    void Update()
    {
       // if (CurrentMaterial != this.GetComponent<MeshRenderer>().material)
        //{
            
            if (IsGold)
            {
                this.GetComponent<MeshRenderer>().material = Gold;
            }
            else
            {
                this.GetComponent<MeshRenderer>().material = CurrentMaterial;
            }

                
       // }        
    }
}
