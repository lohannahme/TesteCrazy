using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class UIHUDHealthBar : MonoBehaviour
{

    public Text nameField;
    public Image playerPortrait;
    public Slider HpSlider;
    public bool isPlayerTwo;

    private void Awake()
    {
        if(!GlobalGameSettings.Coop && isPlayerTwo)
        {
            gameObject.SetActive(false);
        }
    }

    void OnEnable()
    {
        HealthSystem.onHealthChange += UpdateHealth;
    }

    void OnDisable()
    {
        HealthSystem.onHealthChange -= UpdateHealth;
    }

    void Start()
    {
        //if (!isPlayer) Invoke("HideOnDestroy", Time.deltaTime); //hide enemy healthbar at start
        SetPlayerPortraitAndName();
    }

    void UpdateHealth(float percentage, GameObject go, bool P2)
    {
        if(P2 && isPlayerTwo)
        {
            if (go.CompareTag("Player"))
            {
                HpSlider.value = percentage;
            }
        }
        else if (!P2 && !isPlayerTwo)
        {
            if (go.CompareTag("Player"))
            {
                HpSlider.value = percentage;
            }
        }

    }

    void HideOnDestroy()
    {
        HpSlider.gameObject.SetActive(false);
        nameField.text = "";
    }

    //loads the HUD icon of the player from the player prefab (Healthsystem)
    void SetPlayerPortraitAndName()
    {
        if (playerPortrait != null)
        {
            //GameObject player = GameObject.FindGameObjectWithTag("Player");
            PlayerMovement[] players = FindObjectsOfType<PlayerMovement>();

            //if (isPlayerTwo)
            //{

            //    //set portrait
            //    Sprite HUDPortrait = healthSystem.HUDPortrait;
            //    playerPortrait.overrideSprite = HUDPortrait;

            //    //set name
            //    nameField.text = healthSystem.PlayerName;
            //}

            for (int i = 0; i < players.Length; i++)
            {
                HealthSystem health = players[i].GetComponent<HealthSystem>();
                if(health.IsPlayerTwo && isPlayerTwo)
                {
                    playerPortrait.overrideSprite = health.HUDPortrait;

                    nameField.text = health.PlayerName;
                }
                else if(!health.IsPlayerTwo && !isPlayerTwo)
                {
                    playerPortrait.overrideSprite = health.HUDPortrait;

                    nameField.text = health.PlayerName;
                }
            }
        }
    }
}
