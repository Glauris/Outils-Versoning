using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roll : MonoBehaviour
{
    public Sprite roll;
    public Sprite stand;
    public PlayerMovement plm;

    void Start()
    {
        
    }
    bool isRolling;
    public float speedMultiplier;
    public IEnumerator doRoll()
    {
        isRolling = true;
        GetComponent<SpriteRenderer>().sprite = roll;
        yield return new WaitForSeconds(1f);
        GetComponent<SpriteRenderer>().sprite = stand;
        isRolling = false;
        print("caca");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && !isRolling)
        {
            StartCoroutine(doRoll());  
        }
        if (isRolling)
        {
            transform.Translate(Vector2.right * plm.currentSpeed * speedMultiplier * Time.deltaTime);
        }
    }
}
