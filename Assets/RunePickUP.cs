using UnityEngine;

public class RunePickUP : MonoBehaviour
{
    public GameObject runeModule;
    public SpriteRenderer sr;
    SpellInventory spellInventory;
    bool contains;
    

    void Start()
    {
        var generalSpellModule = runeModule.GetComponent<GeneraldSpellModule>();
        sr.sprite = Sprite.Create(generalSpellModule.itemUiImage as Texture2D, new Rect(0, 0, generalSpellModule.itemUiImage.width, generalSpellModule.itemUiImage.height), new Vector2(0.5f, 0.5f));
        spellInventory = GameObject.Find("InventoryManager").GetComponent<SpellInventory>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            contains = false;
            foreach (var item in spellInventory.Spells)
            {
                if (item == runeModule)
                {   
                    contains = true;
                }

            }

            foreach (var item in spellInventory.spellsEuipe)
            {
                if (item == runeModule)
                {   
                    contains = true;
                }
            }

            
            if (!contains)
            {
                spellInventory.Spells.Add(runeModule);
            }            
            Destroy(this.gameObject);
        }


    }
}
