using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Details : MonoBehaviour
{

    public GameObject loadingPrefab;


    // Use this for initialization
    void Start()
    {
        GameObject.Find("txtname").GetComponent<Text>().text = Scrollerview.MyProduct.name;
        GameObject.Find("txtcategory").GetComponent<Text>().text = Scrollerview.MyProduct.category;
        GameObject.Find("txtmodel").GetComponent<Text>().text = Scrollerview.MyProduct.model;
        GameObject.Find("txtColor").GetComponent<Text>().text = Scrollerview.MyProduct.color;
        GameObject.Find("txtPrice").GetComponent<Text>().text = Scrollerview.MyProduct.price;
        StartCoroutine(loadSpriteImageFromUrl(Scrollerview.MyProduct.image, GameObject.Find("productImg").GetComponent<Image>()));

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