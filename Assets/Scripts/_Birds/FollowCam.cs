using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }


    static public GameObject POI; // Ссылка на интересующий объект 
    [Header("Set Dynamically")]
    public float camZ; // Желаемая координата Z камеры
    public float easing = 0.05f;
    public Vector2 minXY = Vector2.zero;

    void Awake()
    {
        camZ = this.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {

      

    }

    void FixedUpdate()
    {
         //Однострочная версия if не требует фигурных скобок
        if (POI == null) return;
        // Получить позицию интересующего объекта
        Vector3 destination = POI.transform.position;

        destination.x = Mathf.Max(minXY.x, destination.x);
        destination.y = Mathf.Max(minXY.y, destination.y);
        destination = Vector3.Lerp(transform.position, destination, easing);
        


        destination.z = camZ;
        // Поместить камеру в позицию destination
        transform.position = destination;
        Camera.main.orthographicSize = destination.y + 10;
    }
}