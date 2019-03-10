using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGlow : MonoBehaviour {

    private Light GlowCharacter;
    private Color GlowColour;
    //private Color StartingGlow = new Color32(252, 91, 83, 255);
    private GameObject Character;
    private GameObject Face;
    private SpriteRenderer SR;
    public Sprite[] Sprites;

    void Start () {
        GlowCharacter = GetComponent<Light>();
        Character = this.gameObject;
        Face = GameObject.Find("Face");
        SR = Face.GetComponent<SpriteRenderer>();
        
        GlowColour = Color.red;
	}

    void Update() {
        GlowCharacter.color = GlowColour;
        if (Character.GetComponent<Slingshot>().CollectibleCounter == 1)
        {
            GlowColour = Color.magenta;
            SR.sprite = Sprites[1];
        }
        else if (Character.GetComponent<Slingshot>().CollectibleCounter == 2) {
            SR.sprite = Sprites[2];

        }
    }
	
	
}
