using System;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputManagerEntry;

[RequireComponent(typeof(FêmeaDesova))]
public class Coloração : MonoBehaviour
{
    public enum Genero { Femea, Macho }
    public Genero genero;
    Sprite mySprite;
    public FêmeaDesova confirmed;

    [System.Serializable]
    public class SpriteNomeado
    {
        public String cor;
        public Sprite sprite;
    }

    public List<SpriteNomeado> sprites = new List<SpriteNomeado>();
    void Awake()
    {
;        mySprite = GetComponent<Sprite>();
    }

    private void Start()
    {
        mySprite = genero == Genero.Femea ? sprites[0].sprite : sprites[2].sprite;
        confirmed.enabled = genero == Genero.Femea ? true : false;
    }

}
//https://grouperluna.com/tag/goliath/
/*ele vão ter o gênero já definido
as fêmeas vão ter um coloração diferente
daí vai ser avaliado se ele é fêmea ou macho
então a fêmea de forma aleatória vai começar reprodução
vai lançar um sinal e outros machos próximos a ela vão seguir ela
o player deve acompanhar ela(bem próximo)
então quando ela lançar as ovócitos na água
ele deve apertar espaço para lançar
e depois proteger os espermas*/