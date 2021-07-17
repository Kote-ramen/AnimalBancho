using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 0.5f; //移動速度
    //private int level = 1; //レベル（肉の枚数）
    public GameObject poop;
    private Color poopcolor;
    private float playerx;
    private float playerz;
    private bool poopkey = false;

    /* 古い肉（リストの先頭）から順に捨てていくため先入れ先出しのキューを用いる */
    public Queue<Color> colors = new Queue<Color>(10); //肉の色のキュー

    Dictionary<string, bool> move = new Dictionary<string, bool>
    {
        {"up",false },
        {"down", false },
        {"right", false },
        {"left", false },
    };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move["up"] = Input.GetKey(KeyCode.UpArrow);
        move["down"] = Input.GetKey(KeyCode.DownArrow);
        move["right"] = Input.GetKey(KeyCode.RightArrow);
        move["left"] = Input.GetKey(KeyCode.LeftArrow);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            poopkey = true;
        }

        playerx = transform.position.x;
        playerz = transform.position.z;
    }

    private void FixedUpdate()
    {
        if (move["up"])
        {
            transform.Translate(0f, 0f, speed);
        }
        if (move["down"])
        {
            transform.Translate(0f, 0f, -speed);
        }
        if (move["right"])
        {
            transform.Translate(speed, 0f, 0f);
        }
        if (move["left"])
        {
            transform.Translate(-speed, 0f, 0f);
        }

        if (poopkey)
        {
            Defication();
        }
    }


    /* colorsの先頭を捨ててオブジェクトの色を（暫定的に）白にする */
    private void Defication()
    {
        poopkey = false;
        if (colors.Count() > 1){
            colors.Dequeue();
            Instantiate(poop, new Vector3(playerx, 2f, playerz), Quaternion.identity);
            GetComponent<MeshRenderer>().material.color = colors.Peek();
        }
        else if(colors.Count() == 1)
        {
            colors.Dequeue();
            Instantiate(poop, new Vector3(playerx, 2f, playerz), Quaternion.identity);
            GetComponent<MeshRenderer>().material.color = Color.gray;
        }
        else
        {
            GetComponent<MeshRenderer>().material.color = Color.white;
        }


        print(colors.Count());
        print("I've deficated");
        return;
    }
}
