using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGlow : MonoBehaviour {

    private Light GlowCharacter;
    private Color GlowColour;
    //private Color StartingGlow = new Color32(252, 91, 83, 255);
    private GameObject Character;
	
	void Start () {
        GlowCharacter = GetComponent<Light>();
        Character = this.gameObject;
        GlowColour = Color.red;
	}

    void Update() {
        GlowCharacter.color = GlowColour;
        if (Character.GetComponent<Slingshot>().CollectibleCounter == 1) {
            GlowColour = Color.magenta;
        }
    }
	
	
}
