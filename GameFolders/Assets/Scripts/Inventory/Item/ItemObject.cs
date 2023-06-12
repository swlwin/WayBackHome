using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]

public class ItemObject : ScriptableObject
{
    [field: SerializeField] public bool IsCountable {get; set;}

    public int ID => GetInstanceID();

    [field:SerializeField] public int MaxCount {get; set;} = 1;
    [field:SerializeField] public string Name {get; set;} 
    [field:SerializeField] [field: TextArea] public string Description {get; set;}
    [field:SerializeField] public Sprite ItemImg {get; set;}
}
