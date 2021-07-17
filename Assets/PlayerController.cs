using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 0.5f; //移動速度
    public int level; //レベル（肉の枚数）
    public List<int> colors = new List<int>(10); //肉の色のリスト

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
        this.level = 1;
    }

    // Update is called once per frame
    void Update()
    {
        move["up"] = Input.GetKey(KeyCode.UpArrow);
        move["down"] = Input.GetKey(KeyCode.DownArrow);
        move["right"] = Input.GetKey(KeyCode.RightArrow);
        move["left"] = Input.GetKey(KeyCode.LeftArrow);
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

        if (Input.GetKey(KeyCode.Space))
        {
            Defication();
        }
    }

    private void Defication()
    {
        print("I've deficated");
        GetComponent<MeshRenderer>().material.color = Color.white;
    }
}
