using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New character", menuName = "Character")]
public class CharactersSO : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private Sprite _portrait;
    [SerializeField] private Sprite _buttonPortrait;
    [SerializeField] private GameObject _prefab;

    public Sprite Portrait { get => _portrait; set => _portrait = value; }
    public GameObject Prefab { get => _prefab; set => _prefab = value; }
}
