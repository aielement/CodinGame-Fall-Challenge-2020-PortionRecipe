using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DrawPortionRecipe : MonoBehaviour
{
    TextAsset portionCsvFile;
    List<PortionRecipe> portionRecipeList = new List<PortionRecipe>();


    [SerializeField]
    GameObject _portionRecipeContentPrefab;

    [SerializeField]
    Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        LoadPortionRecipeCSV();
        DrawPortionRecipes();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void LoadPortionRecipeCSV() {
        portionCsvFile = Resources.Load("portionRecipe") as TextAsset; // Resouces下のCSV読み込み
        StringReader reader = new StringReader(portionCsvFile.text);

        // , で分割しつつ一行ずつ読み込み
        // リストに追加していく
        while (reader.Peek() != -1) // reader.Peaekが-1になるまで
        {
            string line = reader.ReadLine(); // 一行ずつ読み込み
            string[] data = line.Split(',');
            PortionRecipe portionRecipe = new PortionRecipe();
            portionRecipe.tier0 = int.Parse(data[0]);
            portionRecipe.tier1 = int.Parse(data[1]);
            portionRecipe.tier2 = int.Parse(data[2]);
            portionRecipe.tier3 = int.Parse(data[3]);
            portionRecipe.price = int.Parse(data[4]);

            portionRecipeList.Add(portionRecipe); // , 区切りでリストに追加
        }

    }

    void DrawPortionRecipes() {
        for (int w = 0; w < 6; w++) {
            for(int h = 0;h < 6; h++) {
                GameObject portionRecipeContentObject = Instantiate(_portionRecipeContentPrefab,canvas.transform);
                RectTransform rectTransform = portionRecipeContentObject.GetComponent<RectTransform>();
                rectTransform.localPosition = new Vector3(330 * w - 930, 490 - 170 * h, 0) + new Vector3(50, 75, 0);
                PortionRecipeContent portionRecipeContent = portionRecipeContentObject.GetComponent<PortionRecipeContent>();
                portionRecipeContent.Set(portionRecipeList[w + 6 * h]);
            }
        }
    }

}

public class PortionRecipe {
    public int tier0;
    public int tier1;
    public int tier2;
    public int tier3;
    public int price;
}

