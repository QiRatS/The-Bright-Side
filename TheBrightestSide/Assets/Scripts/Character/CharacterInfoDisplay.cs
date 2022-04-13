using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterInfoDisplay : MonoBehaviour
{
    public CharacterInfo character;

    public Text nameText;
    public Image artwork;

    public Text attackText;
    public Text energyText;

    public Text healthText;

    // Start is called before the first frame update
    void Start()
    {
        nameText.text = character.name;
        //artwork.sprite = character.artwork;

        energyText.text = character.energyCost.ToString();
        attackText.text = character.attackValue.ToString();
        healthText.text = character.health.ToString();
    }

 
}
