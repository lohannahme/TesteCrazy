using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICharacterPort : MonoBehaviour
{
    [SerializeField] private Color _selectedColor;
    [SerializeField] private Color _normalColor;
    [SerializeField] private Image _portraitImage;
    [SerializeField] private int _index;

    private Image _mainImage;
    private GameObject _prefab;

    private void Awake()
    {
        _mainImage = GetComponent<Image>();
    }

    public void ChangeCharacter(CharactersSO character)
    {
        _mainImage.sprite = character.Portrait;
        _prefab = character.Prefab;
        UICharSelection characterSelectionScrn = GameObject.FindObjectOfType<UICharSelection>();
        if (characterSelectionScrn) characterSelectionScrn.SelectPlayer(_prefab, _index);
    }

    public void IsSelected(bool value)
    {
        if (value)
        {
            _portraitImage.color = _selectedColor;
        }
        else
        {
            _portraitImage.color = _normalColor;
        }
    }
}
