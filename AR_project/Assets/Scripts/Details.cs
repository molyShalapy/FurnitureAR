using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Details : MonoBehaviour
{

    public GameObject loadingPrefab;
    Product ThisProduct;

    // Use this for initialization
    void Start()
    {
        if (Scrollerview.MyProduct.name != null)
            ThisProduct = Scrollerview.MyProduct;
        else
            ThisProduct = ImageScrollViewer.MyProduct;



        GameObject.Find("txtname").GetComponent<Text>().text = ThisProduct.name;
        GameObject.Find("txtcategory").GetComponent<Text>().text = ThisProduct.category;
        GameObject.Find("txtmodel").GetComponent<Text>().text = ThisProduct.model;
        GameObject.Find("txtColor").GetComponent<Text>().text = ThisProduct.color;
        GameObject.Find("txtPrice").GetComponent<Text>().text = ThisProduct.price;
        StartCoroutine(loadSpriteImageFromUrl(ThisProduct.image, GameObject.Find("productImg").GetComponent<Image>()));

    }

    IEnumerator loadSpriteImageFromUrl(string URL, Image obj)
    {

        WWW www = new WWW(URL);
        while (!www.isDone)
        {
            Debug.Log("Download image on progress" + www.progress);
            yield return null;
        }

        if (!string.IsNullOrEmpty(www.error))
        {
            Debug.Log("Download failed");
        }
        else
        {
            Debug.Log("Download succes");
            Texture2D texture = new Texture2D(1, 1);
            www.LoadImageIntoTexture(texture);

            Sprite sprite = Sprite.Create(texture,
                new Rect(0, 0, texture.width, texture.height), Vector2.zero);


            obj.sprite = sprite;
            loadingPrefab.SetActive(false);

        }

    }
}