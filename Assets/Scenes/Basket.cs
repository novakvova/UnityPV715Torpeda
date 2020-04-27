using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{

    [Header("Set Dynamically")]
    public Text scoreGT;
    // Start is called before the first frame update
    void Start()
    {
        //Получить силку на ігровий обєкт ScoreCounter
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        //Получить компонент Text цього ігрового обєкта
        scoreGT = scoreGO.GetComponent<Text>();
        //Встанолюємо початкове значення очків
        scoreGT.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;

        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }
    
    void OnCollisionEnter(Collision coll)
    {
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "Apple")
        {
            Destroy(collidedWith);
            //Перетворити текст в scoreGT в ціле число
            int score = int.Parse(scoreGT.text);
            //Добавить очки за пойманное яблоко
            score += 100;
            //Перетворити число очків назад в строку і вивести його на екран
            scoreGT.text = score.ToString();

            ////Запамятовуємо вище досягнення
            //if (score > HighScore.score)
            //{
            //    HighScore.score = score;
            //}
        }

    }
}
