using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{

    [Header("Set in Inspector")]
    public GameObject prefabProjectile;
    //public Material[] materials;
    public float velocityMult = 8f;
    
    [Header("Set Dynamically")]
    public GameObject launchPoint;
    public Vector3 launchPos;
    public GameObject projectile; // b
    public bool aimingMode;
  
    private Rigidbody projectileRigidbody;

     void Awake() { 
        Transform launchPointTrans = transform.Find("LaunchPoint"); // a 
        launchPoint = launchPointTrans.gameObject; 
        launchPoint.SetActive( false ); // b 
        launchPos = launchPointTrans.position; 


        }
    void OnMouseDown()
    { // d
      // Игрок нажал кнопку мыши, когда указатель находился над рогаткой
        aimingMode = true;
        // Создать снаряд
        projectile = Instantiate(prefabProjectile) as GameObject; 
        //List<Component> hingeJoints = new List<Component>();
        projectile.transform.position = launchPos;
        //Debug.Log(hingeJoints.ToString());
        projectile.GetComponent<Rigidbody>().isKinematic = true;
        projectileRigidbody = projectile.GetComponent<Rigidbody>();
        projectileRigidbody.isKinematic = true;
    }

    void OnMouseEnter() {
       // print("Slingshot:OnMouseEnter()");
       launchPoint.SetActive(true);
    }
    void OnMouseExit() {
      //  print("Slingshot:OnMouseExit()");
      launchPoint.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
      if (!aimingMode) return;
        Vector3 mousePos2D = Input.mousePosition; // с
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        Vector3 mouseDelta = mousePos3D - launchPos;
        // Ограничить mouseDelta радиусом коллайдера объекта Slingshot // d
        float maxMagnitude = this.GetComponent<SphereCollider>().radius;
        if (mouseDelta.magnitude > maxMagnitude)
        {
            mouseDelta.Normalize();
            mouseDelta *= maxMagnitude;
        }
        Vector3 projPos = launchPos + mouseDelta;
        projectile.transform.position = projPos;
        if (Input.GetMouseButtonUp(0))
        { // e
          // Кнопка мыши отпущена
            aimingMode = false;
            projectileRigidbody.isKinematic = false;
            projectileRigidbody.velocity = -mouseDelta * velocityMult;
	          //FollowCam.POI = projectile;
            projectile = null;
        }
    }
}
