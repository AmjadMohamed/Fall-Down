using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerSkinPicker : MonoBehaviour
{
    [SerializeField] List<Sprite> skins;
    [SerializeField] List<RuntimeAnimatorController> animations;
    Dictionary<string, RuntimeAnimatorController> player;

    private void OnEnable()
    {
        player = new Dictionary<string, RuntimeAnimatorController>();
        print(skins.Count + " " + animations.Count);
        for (int i = 0; i < skins.Count; i++)
        {
            if (animations[i] != null)
            {
                print(i);
                print(skins[i].name);
                print(animations[i].name);
                player.Add(skins[i].name, animations[i]);
            }
        }
    }

    private void Start()
    {
        SpriteRenderer sr = this.GetComponent<SpriteRenderer>();
        Animator ac = this.GetComponent<Animator>();
        sr.sprite = skins[Random.Range(0, skins.Count)];
        print("from start: " + sr.sprite.name);
        print(this.GetComponent<SpriteRenderer>().sprite.name);
        if (player.ContainsKey(sr.sprite.name))
        {
            ac.runtimeAnimatorController = player[sr.sprite.name];
        }

    }
}
