using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour

{
    private Rigidbody  thisRigidbody;
    public float jumpPower = 10;
    public float jumpInterval = 0.5f;
    private float jumpCoolDown = 0;


    // Start is called before the first frame update
    void Start()
    {
        thisRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        jumpCoolDown -= Time.deltaTime;
        bool isGameActive = GameManager.Instance.IsGameActive();
        bool canJump = jumpCoolDown <= 0 && isGameActive;

        if (canJump){
            bool jumpInput =Input.GetKey(KeyCode.Space);
            if (jumpInput){
                Jump();
            }     
        }

        thisRigidbody.useGravity = isGameActive;
        
    } 

    private void Jump()
    {
        jumpCoolDown = jumpInterval;

        thisRigidbody.velocity = Vector3.zero;
        thisRigidbody.AddForce(new Vector3(0, jumpPower, 0),ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision other) {
        OnCustomCollisionEnter(other.gameObject);
    }

    void OnTriggerEnter(Collider other) {
        OnCustomCollisionEnter(other.gameObject);
    }

    private void OnCustomCollisionEnter(GameObject other) {
        bool isSensor = other.gameObject.CompareTag("Sensor");
        var gameManager = GameManager.Instance;
        if (isSensor){
            gameManager.score ++;
            Debug.Log("Score =" + gameManager.score);
            
        }
        else {
            gameManager.EndGame();
            StartCoroutine(ReloadScene(2));
        }
    }

     public IEnumerator ReloadScene(float delay) {
            yield return new WaitForSeconds(delay);
            string sceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(sceneName);
        }
}
