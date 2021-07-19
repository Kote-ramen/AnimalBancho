using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStatus : MonoBehaviour
{
    //　HP
    [SerializeField]
    private int hp = 10000;
    //　HPを一度減らしてからの経過時間
    private float countTime = 0f;
    //　次にHPを減らすまでの時間
    [SerializeField]
    private float nextCountTime = 0f;
    //　HP表示テキスト
    private Text hpText;
    //　現在のダメージ量
    private int damage = 0;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        hpText = GetComponentInChildren<Text>();
        hpText.text = hp.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //　ダメージなければ何もしない
        if (damage == 0)
        {
            return;
        }
        //　次に減らす時間がきたら
        if (countTime >= nextCountTime)
        {

            //　ダメージ量を10で割った商をHPから減らす
            var tempDamage = damage / 10;
            //　商が0になったら余りを減らす
            if (tempDamage == 0)
            {
                tempDamage = damage % 10;
            }
            hp -= tempDamage;
            hpText.text = hp.ToString();
            damage -= tempDamage;

            countTime = 0f;

            //　HPが0以下になったら敵を削除
            if (hp <= 0)
            {
                Destroy(gameObject);
                // HPが0以下になった時にプレイヤーに食べられ、プレイヤーは色を得る
                player.GetComponent<MeshRenderer>().material.color = GetComponent<MeshRenderer>().material.color;
                player.GetComponent<PlayerController>().colors.Enqueue(GetComponent<MeshRenderer>().material.color);
            }
        }

    }

    //　ダメージ値を追加するメソッド
    public void SetDamage(int damage)
    {
        this.damage += damage;
        countTime = 0f;
    }
}
