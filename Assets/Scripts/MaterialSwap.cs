using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaterialSwap : MonoBehaviour
{
    Material CurrentMaterial;

    public Material Standard;
    public Material Gold;
    public Material Crystal;
    public Material Diamond;

    public bool IsGold = false;
    public bool IsCrystal = false;
    public bool IsDiamond = false;

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
            else if (IsCrystal)
            {
                this.GetComponent<MeshRenderer>().material = Crystal;
            }
            else if (IsDiamond)
            {
                this.GetComponent<MeshRenderer>().material = Diamond;
            }
            else
            {
                this.GetComponent<MeshRenderer>().material = Standard;
            }






        // }        
    }
}
