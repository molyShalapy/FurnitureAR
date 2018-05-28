using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scrollerview : MonoBehaviour {

    public GameObject prefab;
    public Dropdown categDDL;
    public Dropdown modelDDL;

    void Awake() {
        InitializeFirebase();
    }

    List<Product> allprod;


/*****************************all data*******************************************/
    void InitializeFirebase()   
    {
        allprod = new List<Product>();
        FirebaseApp app = FirebaseApp.DefaultInstance;
        app.SetEditorDatabaseUrl("https://ar-v1-ce36f.firebaseio.com/");
        FirebaseDatabase.DefaultInstance
            .GetReference("Products").OrderByChild("category")
            .ValueChanged += (object sender2, ValueChangedEventArgs e2) => {
                if (e2.DatabaseError != null)
                {
                    Debug.LogError(e2.DatabaseError.Message);
                }
                else if (e2.Snapshot != null && e2.Snapshot.ChildrenCount > 0)
                {
                    foreach (var childSnapshot in e2.Snapshot.Children)
                    {
                        allprod.Add(new Product
                        {
                            name = childSnapshot.Child("name").Value.ToString(),
                            category = childSnapshot.Child("category").Value.ToString(),
                            model = childSnapshot.Child("model").Value.ToString(),
                            //id = childSnapshot.Child("id").Value.ToString(),
                            color = childSnapshot.Child("color").Value.ToString(),
                            price = childSnapshot.Child("price").Value.ToString(),
                            image = childSnapshot.Child("image").Value.ToString()
                        });
                    }
                    Populate(allprod);
                }
            };
    }

    /**********************************Search*******************************************/
    public GameObject content;
    enum categories { chair = 1, sofa = 2, table = 3 }
    enum models { modern = 1, classic = 2 }
    string model, category;
    public void search()
    {
                 
        List<Product> filter = new List<Product>();
        if (categDDL.value > 0 && modelDDL.value > 0)
        {
            foreach (Product p in allprod)
                if ((p.category == ((categories)categDDL.value).ToString()) && ((p.model == ((models)modelDDL.value).ToString())))
                {
                    filter.Add(p);
                }

        }
        else if (categDDL.value > 0)
        {
            foreach (Product p in allprod)
                if ((p.category == ((categories)categDDL.value).ToString()))
                {
                    filter.Add(p);
                }
        }

        else if (modelDDL.value > 0)
        {
            foreach (Product p in allprod)
                if (((p.model == ((models)modelDDL.value).ToString())))
                {
                    filter.Add(p);
                }
        }
        foreach (Transform child in content.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        Populate(filter); //## byrsm 3al 2deem 

    }
    /***************************Draw*****************************************/
    public  void Populate( List<Product> prod)
    {
        GameObject newObj;

        for (int t = 0; t < prod.Count; t++)
        {
            newObj = (GameObject)Instantiate(prefab, transform);
            //## static 
            AddButton(newObj, prod[t]);
            newObj.transform.GetComponentInChildren<Text>().text = prod[t].name;

        }
    }
   
    void AddButton(GameObject obj, Product p1)
    {
        var button = obj.transform.GetComponentInChildren<Button>();
        button.onClick.AddListener(delegate { OnPointerClick(p1); });
        StartCoroutine(loadSpriteImageFromUrl(p1.image, obj));

    }

    /*******************************add image*************************************/

    IEnumerator loadSpriteImageFromUrl(string URL, GameObject obj)
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

            var myim = obj.transform.GetComponentInChildren<Image>();
            myim.sprite = sprite;
        }
    }



    public static Product MyProduct { get; set; }

    /**********************************Details***************************************************/
    public void OnPointerClick(Product p )
    {
        MyProduct = p;
        SceneManager.LoadScene("ProductDetailsScreen");


    }

}
