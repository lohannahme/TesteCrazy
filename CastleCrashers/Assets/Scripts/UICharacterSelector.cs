using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICharacterSelector : MonoBehaviour
{
    [SerializeField] private Button[] _selectedCharacters;
    [SerializeField] private CharactersSO _defaultCharacter;
    [SerializeField] private UICharacterPort _defaultPortrait;

    private UICharacterPort _currentPortraitSelected;
    private int _playerIndex;

    private void Start()
    {
        ChangeCurrentPortraitSelected(_defaultPortrait);
        _currentPortraitSelected = _defaultPortrait;
        ChangeCurrentPortrait(_defaultCharacter);
    }

    public void ChangeCurrentPortraitSelected(UICharacterPort currentPortraitSelected)
    {
        if(_currentPortraitSelected == null)
        {
            _currentPortraitSelected = currentPortraitSelected;
            currentPortraitSelected.IsSelected(true);
        }
        else
        {
            _currentPortraitSelected.IsSelected(false);
            _currentPortraitSelected = currentPortraitSelected;
            currentPortraitSelected.IsSelected(true);
        }
    }

    public void ChangePlayer(int index)
    {
        _playerIndex = index;
    }

    public void ChangeCurrentPortrait(CharactersSO character)
    {
        _currentPortraitSelected.ChangeCharacter(character);
    }

    public void DisableCurrentButton(Button but)
    {
        if (_selectedCharacters[_playerIndex] == null)
        {
            _selectedCharacters[_playerIndex] = but;
            _selectedCharacters[_playerIndex].interactable = false;
        }
        else
        {
            _selectedCharacters[_playerIndex].interactable = true;
            but.interactable = false;
            _selectedCharacters[_playerIndex] = but;
        }
    }
}
