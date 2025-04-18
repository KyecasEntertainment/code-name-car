using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class ShopPanelScripts : MonoBehaviour
{
    public TextAsset shop_json;
    public Text shop_name_text;
    public GameObject[] shop_items;

    [System.Serializable]
    public class Item
    {
        public string name;
        public int cost;
        public string status;
        public int boost; // Optional property
        public bool is_limited; // Optional property
    }

    [System.Serializable]
    public class Shop
    {
        public string name;
        public string description;
        public List<Item> items;
    }

    [System.Serializable]
    public class ShopEntry
    {
        public string key;   
        public Shop value; 
    }

    [System.Serializable]
    public class ShopList
    {
        public List<ShopEntry> shops;
    }

    public ShopList shop_list = new ShopList();

    void Start()
    {
        shop_list = JsonUtility.FromJson<ShopList>(shop_json.text);
    }

    // Fix Tomorrow
    public void OpenShop(int shop_index)
    {
        switch (shop_index){
            case 1:
                string shop_name = shop_list.shops[0].value.name;
                shop_name_text.text = shop_name;
                Debug.Log(shop_name);
                string shop_description = shop_list.shops[0].value.description;
                Debug.Log(shop_description);
                List<Item> items = shop_list.shops[0].value.items;
                foreach (Item item in items)
                {
                    SetShopData(item);
                }
                break;
            case 2:
                string shop_name2 = shop_list.shops[1].value.name;
                shop_name_text.text = shop_name2;
                Debug.Log(shop_name2);
                string shop_description2 = shop_list.shops[1].value.description;
                Debug.Log(shop_description2);
                List<Item> items2 = shop_list.shops[1].value.items;
                foreach (Item item in items2)
                {
                    SetShopData(item);
                }
                break;
            case 3:
                string shop_name3 = shop_list.shops[2].value.name;
                shop_name_text.text = shop_name3;
                Debug.Log(shop_name3);
                string shop_description3 = shop_list.shops[2].value.description;
                Debug.Log(shop_description3);
                List<Item> items3 = shop_list.shops[2].value.items;
                foreach (Item item in items3)
                {
                    SetShopData(item);
                }
                break;
            case 4:
                string shop_name4 = shop_list.shops[3].value.name;
                shop_name_text.text = shop_name4;
                Debug.Log(shop_name4);
                string shop_description4 = shop_list.shops[3].value.description;
                Debug.Log(shop_description4);
                List<Item> items4 = shop_list.shops[3].value.items;
                foreach (Item item in items4)
                {
                    SetShopData(item);
                }
                break;
        }
    }

    public void SetShopData(Item item){

        Transform container = transform.GetChild(0).GetChild(0); // Assuming this holds all shop items
        int itemCount = container.childCount;

        shop_items = new GameObject[itemCount]; // Make sure to initialize the array!

        for (int i = 0; i < itemCount; i++)
        {
            shop_items[i] = container.GetChild(i).gameObject;
            Debug.Log(i + ": " + shop_items[i].name);
        }

        

    }
}
