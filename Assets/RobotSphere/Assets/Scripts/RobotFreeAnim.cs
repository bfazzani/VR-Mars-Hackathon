using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotFreeAnim : MonoBehaviour {

	Vector3 rot = Vector3.zero;
	float rotSpeed = 40f;
	Animator anim;
    public GameObject target;

    private float speed = 4f;

	// Use this for initialization
	void Awake()
	{
		anim = gameObject.GetComponent<Animator>();
		gameObject.transform.eulerAngles = rot;
	}

	// Update is called once per frame
	void Update()
	{
		//CheckKey();
        if(target != null)
        {
            anim.SetBool("Walk_Anim", true);
            rot[1] = Vector3.Angle(transform.forward, target.transform.position - transform.position);
            Vector3 velocity = target.transform.position - transform.position;
            velocity.Normalize();
            transform.Translate(speed * velocity * Time.deltaTime);
        }
        else
        {
            anim.SetBool("Walk_Anim", false);
        }
        //gameObject.transform.eulerAngles = rot;
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            target = null;
        }
    }

    void CheckKey()
	{
        float vert = VRInput.GetAxis(VRButton.RightThumbVertical);
        float horiz = VRInput.GetAxis(VRButton.RightThumbHorizontal);
        //if(Mathf.Abs(vert) >= Mathf.Abs(horiz))
        //{
            //float x = Mathf.Sin(rot[1] * Mathf.Deg2Rad);
            //float z = Mathf.Cos(rot[1] * Mathf.Deg2Rad);

            Vector3 velocity = Vector3.forward * vert;
            if (velocity.magnitude != 0)
            {
                anim.SetBool("Walk_Anim", true);
            }
            else
            {
                anim.SetBool("Walk_Anim", false);
            }
            transform.Translate(velocity * Time.deltaTime);
        //} else
        //{
            //anim.SetBool("Walk_Anim", false);
            rot[1] += rotSpeed * Time.fixedDeltaTime * horiz;
        //}



        

        // Walk
        if (Input.GetKey(KeyCode.W))
		{
			anim.SetBool("Walk_Anim", true);
		}
		else if (Input.GetKeyUp(KeyCode.W))
		{
			anim.SetBool("Walk_Anim", false);
		}

		// Rotate Left
		if (Input.GetKey(KeyCode.A))
		{
			rot[1] -= rotSpeed * Time.fixedDeltaTime;
		}

		// Rotate Right
		if (Input.GetKey(KeyCode.D))
		{
			rot[1] += rotSpeed * Time.fixedDeltaTime;
		}

		// Roll
		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (anim.GetBool("Roll_Anim"))
			{
				anim.SetBool("Roll_Anim", false);
			}
			else
			{
				anim.SetBool("Roll_Anim", true);
			}
		}

		// Close
		if (Input.GetKeyDown(KeyCode.LeftControl))
		{
			if (!anim.GetBool("Open_Anim"))
			{
				anim.SetBool("Open_Anim", true);
			}
			else
			{
				anim.SetBool("Open_Anim", false);
			}
		}
	}

}
