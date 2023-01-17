using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkinPicker : MonoBehaviour
{
    [SerializeField] List<Sprite> skins;

    private void OnEnable()
    {
        this.GetComponent<SpriteRenderer>().sprite = skins[Random.Range(0, skins.Count)];
        print(this.GetComponent<SpriteRenderer>().sprite.name);
    }
}
