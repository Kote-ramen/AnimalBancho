using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject player;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        //Playerの情報取得
        this.player = GameObject.Find("Player");

        //MainCamera(自分自身)とplayerの相対距離を求める
        this.offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //新しいトランスフォームの値を代入する
        transform.position = player.transform.position + offset;
    }
}
