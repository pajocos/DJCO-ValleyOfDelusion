using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Utils;

public class EnemyBehavior : MonoBehaviour {

    private Rigidbody rgd;
    private int patternIterator = -1;
    private float movementLeft = 0;
    private List<Movement> movementPattern;
    private float lastAng;
	// Use this for initialization
	void Start () {

        movementPattern = new List<Movement>();
        movementPattern.Add(new Movement(5f, false, Vector3.left));
        movementPattern.Add(new Movement(Mathf.PI, true, Vector3.up));
        movementPattern.Add(new Movement(5f, false, Vector3.right));
        movementPattern.Add(new Movement(Mathf.PI, true, Vector3.up));

        rgd = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {




        if (movementLeft > 0) {

           

            if (movementPattern[patternIterator].isRotation()) {


                rgd.AddTorque(movementPattern[patternIterator].getAxis(),ForceMode.VelocityChange);

                float ang;
                Vector3 ve;
                GetComponent<Transform>().rotation.ToAngleAxis(out ang,out ve);
                Debug.Log("ang:" + ang + "last:" + lastAng  + "dif" + (ang- lastAng));

                movementLeft -= Time.deltaTime;
                lastAng = ang;
            } else {

                rgd.velocity = movementPattern[patternIterator].getAxis() * 2;
                movementLeft -= Time.deltaTime;



            }








        } else {

            rgd.velocity = Vector3.zero;
            rgd.angularVelocity = Vector3.zero;




            patternIterator++;
            if (patternIterator >= movementPattern.Count) {
                patternIterator = 0;
            }
            movementLeft = movementPattern[patternIterator].getValue();

            float ang;
            Vector3 ve;
            GetComponent<Transform>().rotation.ToAngleAxis(out ang, out ve);

            lastAng = ang;

        }


    }
}
