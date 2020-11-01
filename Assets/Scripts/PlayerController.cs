using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speedMultiplier = 1f;

    private Rigidbody _rigidbody;
    private float _movementHorizontal, _movementVertical; //aralarındaki virgül daha düzenli olmaları için çünkü aynı anlamı verdik ikisine de
    private void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = transform.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            _rigidbody.AddForce(x: 0, y: 4f, z: 0, ForceMode.Impulse);

        _movementHorizontal = Input.GetAxis("Horizontal") * speedMultiplier; //*5f hızlandırmak için
        _movementVertical = Input.GetAxis("Vertical") * speedMultiplier;
        _rigidbody.AddForce(x: _movementHorizontal, y: 0, z: _movementVertical, ForceMode.Acceleration);
    }
 if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(
                    transform.position.x + touch.deltaPosition.x * speedModifier,
                    transform.position.y,
                    transform.position.z + touch.deltaPosition.y * speedModifier);
            }

        }
    private void OnCollisionEnter(Collision other)
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        //collect and destroy coin
        if (other.transform.CompareTag("Coin"))
            GameObject.Destroy(other.gameObject);
    }
}
