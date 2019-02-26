using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customizer : MonoBehaviour
{
    public Skin[] skin;
    public ClothesTypes[] clothesTypes;
    public Clothes[] CurrentClothes;

    public void NextClother(int SkinnedTypeIndex)
    {
        int nextClothesIndex;
        nextClothesIndex = skin[SkinnedTypeIndex].currentIndex +1;

        if (nextClothesIndex >= clothesTypes[SkinnedTypeIndex].clothes.Length)
        {
            nextClothesIndex = 0;
        }

        AddClothes(clothesTypes[SkinnedTypeIndex].clothes[nextClothesIndex]);
        skin[SkinnedTypeIndex].currentIndex = nextClothesIndex;
    }
    public void PreviousClother(int SkinnedTypeIndex)
    {
        int nextClothesIndex;

        nextClothesIndex = skin[SkinnedTypeIndex].currentIndex -1;
        if (nextClothesIndex < 0)
        {
            nextClothesIndex = clothesTypes[SkinnedTypeIndex].clothes.Length-1;
        }

        AddClothes(clothesTypes[SkinnedTypeIndex].clothes[nextClothesIndex]);
        skin[SkinnedTypeIndex].currentIndex = nextClothesIndex;
    }

private void Start() {
            CurrentClothes = new Clothes[clothesTypes.Length];
}

    void AddClothes(GameObject _newClotherGO)
    {
        Clothes newClother = _newClotherGO.GetComponent<Clothes>();
        int slotIndex = (int)newClother.type;

        removeClothing(slotIndex);


        CurrentClothes[slotIndex] = newClother;

        if (_newClotherGO.GetComponent<Clothes>().hide == true)
        {
            int slotToHide = (int)newClother.hides;
            HideClothes(slotToHide);
        }

        //graphic settings
        skin[slotIndex].skinnedMeshRenderer.sharedMesh = _newClotherGO.GetComponent<MeshFilter>().sharedMesh;
        skin[slotIndex].skinnedMeshRenderer.materials = _newClotherGO.GetComponent<MeshRenderer>().sharedMaterials;

    }
    void removeClothing(int SlotIndex)
    {
        if(CurrentClothes[SlotIndex] != null && CurrentClothes[SlotIndex].hide)
        skin[(int)CurrentClothes[SlotIndex].hides].skinnedMeshRenderer.enabled = true;

        CurrentClothes[SlotIndex] = null;
       
    }
    void ShowClothes(int _slotToHide){

    }
    void HideClothes(int _slotToHide)
    {
        skin[_slotToHide].skinnedMeshRenderer.enabled = false;
    }

    public enum Type
    {
        Torso,
        Legs,
        Feet,
        Hands,
        Hair,
        BackPack,       
        Outer,
        Head,
        Eyes,
        Mask,
    }

}
[System.Serializable]
public class Skin
{
    public string name;
    public SkinnedMeshRenderer skinnedMeshRenderer;
    [HideInInspector]
    public int currentIndex;
}

[System.Serializable]
public class ClothesTypes
{
    public string name;
    public GameObject[] clothes;
}


