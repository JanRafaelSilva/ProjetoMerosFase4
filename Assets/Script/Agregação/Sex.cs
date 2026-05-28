using System;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputManagerEntry;

public class Sex : MonoBehaviour
{
    public enum Genero { Femea, Macho }
    public Genero genero;
    Sprite mySprite;
    public SpawningCall confirmed;

    [System.Serializable]
    public class SpriteNomeado
    {
        public String cor;
        public Sprite sprite;
    }

    public List<SpriteNomeado> sprites = new List<SpriteNomeado>();
    void Awake()
    {
        mySprite = GetComponent<Sprite>();
    }

    private void Start()
    {
        mySprite = genero == Genero.Femea ? sprites[0].sprite : sprites[1].sprite;
        confirmed.enabled = genero == Genero.Femea ? true : false;
    }

}