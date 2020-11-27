using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PortionRecipeContent : MonoBehaviour
{
    const int TIER_MAX_COUNT = 6;
    const int TIER_TYPE_COUNT = 4;

    [SerializeField]
    Sprite[] _sprites_tier = new Sprite[TIER_TYPE_COUNT];

    [SerializeField]
    Image[] _imgs_tier = new Image[TIER_MAX_COUNT];

    [SerializeField]
    Text _txt_price;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Set(PortionRecipe portionRecipe) {
        _txt_price.text = portionRecipe.price.ToString();


        foreach (Image img_tier in _imgs_tier) {
            img_tier.gameObject.SetActive(false);
        }

        int baseIndex = 0;

        for (int i = baseIndex; i < baseIndex + portionRecipe.tier0; i++) {
            _imgs_tier[i].gameObject.SetActive(true);
            _imgs_tier[i].sprite = _sprites_tier[0];
        }

        baseIndex += portionRecipe.tier0;

        for (int i = baseIndex; i < baseIndex + portionRecipe.tier1; i++) {
            _imgs_tier[i].gameObject.SetActive(true);
            _imgs_tier[i].sprite = _sprites_tier[1];
        }

        baseIndex += portionRecipe.tier1;

        for (int i = baseIndex; i < baseIndex + portionRecipe.tier2; i++) {
            _imgs_tier[i].gameObject.SetActive(true);
            _imgs_tier[i].sprite = _sprites_tier[2];
        }

        baseIndex += portionRecipe.tier2;

        for (int i = baseIndex; i < baseIndex + portionRecipe.tier3; i++) {
            _imgs_tier[i].gameObject.SetActive(true);
            _imgs_tier[i].sprite = _sprites_tier[3];
        }

        baseIndex += portionRecipe.tier3;
    }
}
