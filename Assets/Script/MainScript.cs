using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainScript:MonoBehaviour
{
    public GameObject[] Fruits_Prefabs;
    public GameObject Score_obj;
    public GameObject NextFruits_obj;

    public Sprite cherry_S;
    public Sprite strawberry_S;
    public Sprite grap_S;
    public Sprite dekopon_S;
    public Sprite persimmon_S;

    public GameObject Line_obj;
    

    GameObject Fruits;
    Rigidbody2D Fruits_rb;
    Transform Fruits_tr;


    CircleCollider2D circleCollider;

    Image nextFruits_image;

    Vector3 tmp = new Vector3(0.0f, 7.5f, 0.0f);

    public static int i;
    int number = 0;
    int nextNumber;

    Text Score_txt;
    public static int Score = 0;
    public static int   Strawberry_S = 0,
                        Grape_S = 0,
                        Dekopon_S = 0,
                        Persimmon_S = 0,
                        Apple_S = 0,
                        Pear_S = 0,
                        Peach_S = 0,
                        Pineapple_S = 0,
                        Melon_S = 0,
                        Watermelon_S = 0,
                        noFruits = 0;

    bool onleft = false, onright = false;

    public static float fruitsSpeed = 10f;

    RectTransform nextFruits_transform;

    Transform line_tr;

    // Start is called before the first frame update
    void Start()
    {
        nextFruits_transform = NextFruits_obj.GetComponent<RectTransform>();
        line_tr = Line_obj.GetComponent<Transform>();

        Score = 0;
        Strawberry_S = 0;
        Grape_S = 0;
        Dekopon_S = 0;
        Persimmon_S = 0;
        Apple_S = 0;
        Pear_S = 0;
        Peach_S = 0;
        Pineapple_S = 0;
        Melon_S = 0;
        Watermelon_S = 0;
        noFruits = 0;
        Score_txt = Score_obj.GetComponent<Text>();
        nextFruits_image = NextFruits_obj.GetComponent<Image>();
        MakeFruits();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Fruits_rb != null)
        {
            if(Fruits_rb.bodyType == RigidbodyType2D.Kinematic)
            {
                circleCollider = Fruits.GetComponent<CircleCollider2D>();
                
                if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
                {
                    Fruits_tr.transform.position += new Vector3(-fruitsSpeed, 0, 0) * Time.deltaTime;
                    line_tr.transform.position += new Vector3(-fruitsSpeed, 0, 0) * Time.deltaTime;
                }
                if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
                {
                    Fruits_tr.transform.position += new Vector3(fruitsSpeed, 0, 0) * Time.deltaTime;
                    line_tr.transform.position += new Vector3(fruitsSpeed, 0, 0) * Time.deltaTime;
                }
                if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
                {
                    Fruits_rb.bodyType = RigidbodyType2D.Dynamic;
                    Touch.collisionTime = false;
                    tmp = Fruits.transform.position;
                    StartCoroutine(Make());
                }
                if(Input.GetKeyDown(KeyCode.R))
                {
                    RetryButton();
                }

                if(Fruits_tr.transform.position.x > (4.75f - circleCollider.radius * Fruits_tr.localScale.x))
                {
                    Fruits_tr.transform.position = new Vector3((4.74f - circleCollider.radius * Fruits_tr.localScale.x), 7.5f, 0);
                    line_tr.transform.position = new Vector3((4.74f - circleCollider.radius * Fruits_tr.localScale.x), 1, 0);
                }
                if(Fruits_tr.transform.position.x < (-4.75f + circleCollider.radius * Fruits_tr.localScale.x))
                {
                    Fruits_tr.transform.position = new Vector3((-4.74f + circleCollider.radius * Fruits_tr.localScale.x), 7.5f, 0);
                    line_tr.transform.position = new Vector3((-4.74f + circleCollider.radius * Fruits_tr.localScale.x), 1, 0);
                }
            }
        }

        Score_cal();

        if(onleft)
        {
            LeftArrow();
        }
        if(onright)
        {
            RightArrow();
        }
    }

    public void MakeFruits()
    {
        nextNumber = Random.Range(0, Fruits_Prefabs.Length);

        //Generate　Now Fruits
        Instantiate(Fruits_Prefabs[number], new Vector3(tmp.x, 7.5f, 0.0f), Quaternion.identity);
        ChangeName("Fruits");

        //View Next Fruits
        ChangeNextFruits(nextNumber);
        
        Fruits_rb = Fruits.GetComponent<Rigidbody2D>();
        Fruits_tr = Fruits.GetComponent<Transform>();
        Fruits_rb.bodyType = RigidbodyType2D.Kinematic;
        number = nextNumber;
    }

    IEnumerator Make()
    {
        yield return new WaitForSeconds(0.7f);
        Touch.collisionTime = true;
        MakeFruits();
    }

    void ChangeName(string name)
    {
        if(name == "Fruits")
        {
            if(GameObject.Find("Cherry(Clone)") == true)
            {
                Fruits = GameObject.Find("Cherry(Clone)");
            }
            if(GameObject.Find("Strawberry(Clone)") == true)
            {
                Fruits = GameObject.Find("Strawberry(Clone)");
            }
            if(GameObject.Find("Grape(Clone)") == true)
            {
                Fruits = GameObject.Find("Grape(Clone)");
            }
            if(GameObject.Find("Dekopon(Clone)") == true)
            {
                Fruits = GameObject.Find("Dekopon(Clone)");
            }
            if(GameObject.Find("Persimmon(Clone)") == true)
            {
                Fruits = GameObject.Find("Persimmon(Clone)");
            }
            Fruits.name = name + i;
        }
        
        i++;
    }

    public void Score_cal()
    {

        Score = (1 * Strawberry_S) + (3 * Grape_S) + (6 * Dekopon_S) + (10 * Persimmon_S) + (15 * Apple_S) + (21 * Pear_S) + (28 * Peach_S) + (36 * Pineapple_S) + (45 * Melon_S) + (55 * Watermelon_S) + (66 * noFruits);
        Score_txt.text = Score.ToString();
            
    }

    public void RetryButton()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void ChangeNextFruits(int nextNumber)
    {
        switch(nextNumber)
        {
            case 0:
                nextFruits_transform.sizeDelta = new Vector2(45, 45);
                nextFruits_image.sprite = cherry_S;
                break;
            case 1:
                nextFruits_transform.sizeDelta = new Vector2(60, 60);
                nextFruits_image.sprite = strawberry_S;
                break;
            case 2:
                nextFruits_transform.sizeDelta = new Vector2(90, 90);
                nextFruits_image.sprite = grap_S;
                break;
            case 3:
                nextFruits_transform.sizeDelta = new Vector2(115, 115);
                nextFruits_image.sprite = dekopon_S;
                break;
            case 4:
                nextFruits_transform.sizeDelta = new Vector2(145, 145);
                nextFruits_image.sprite = persimmon_S;
                break;

        }
            
    }

    public void OnButtonLeft()
    {
        onleft = true;
    }
    public void upButtonLeft()
    {
        onleft = false;
    }
    public void OnButtonRight()
    {
        onright = true;
    }
    public void upButtonRight()
    {
        onright = false;
    }


    public void LeftArrow()
    {
        if(Fruits_rb != null)
        {
            if(Fruits_rb.bodyType == RigidbodyType2D.Kinematic)
            {
                Fruits_tr.transform.position += new Vector3(-fruitsSpeed, 0, 0) * Time.deltaTime;
                line_tr.transform.position += new Vector3(-fruitsSpeed, 0, 0) * Time.deltaTime;
            }
        }
    }
    public void RightArrow()
    {
        if(Fruits_rb != null)
        {
            if(Fruits_rb.bodyType == RigidbodyType2D.Kinematic)
            {
                Fruits_tr.transform.position += new Vector3(fruitsSpeed, 0, 0) * Time.deltaTime;
                line_tr.transform.position += new Vector3(fruitsSpeed, 0, 0) * Time.deltaTime;
            }
        }
    }

    public void FallButton()
    {
        if(Fruits_rb != null)
        {
            if(Fruits_rb.bodyType == RigidbodyType2D.Kinematic)
            {
                Fruits_rb.bodyType = RigidbodyType2D.Dynamic;
                Touch.collisionTime = false;
                tmp = Fruits.transform.position;
                StartCoroutine("Make");
            }
        }
                
    }
}
