using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{

	Rigidbody myRigidBody;
    public Animator animator;
    public float direction;
    public float Force = 1.0F;

    // Start is called before the first frame update
    void Start()
    {
		myRigidBody = GetComponent<Rigidbody> ();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0.0f, Input.GetAxisRaw("Vertical"));

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.z);
        animator.SetFloat("Magnitude", movement.magnitude);
        transform.position = transform.position + movement * Time.deltaTime;
        
        // direction = Mathf.Atan2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * (180 / Mathf.PI);
        direction = Mathf.Atan2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * (180 / Mathf.PI);
        if (direction != 0) {
            animator.SetFloat("Direction", direction/180); // Values are in degrees from -180 to 180, but the Animator expects -1 to 1.
        }
        
    }

    
	public void DamagePlayer(){
        Debug.Log("Damaged player");
		animator.SetBool ("Dead", true);
		// animator.transform.parent = null;
		// this.enabled = false;
		myRigidBody.isKinematic = true;
		GameManager.RegisterPlayerDeath ();
		// gameObject.GetComponent<Collider> ().enabled = false;
		GameCamera.ToggleShake (0.3f);
		// Vector3 pos = animator.transform.position;
		// pos.y = 0.2f;
		// animator.transform.position = pos;
	}
    
}
