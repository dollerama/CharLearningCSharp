using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForLoops : MonoBehaviour
{
    [Header("Helper Properties")]
    public GameObject Bullet; //bullet ojbect
    public GameObject Burst; //burst effect
    public GameObject shipPart;
    public Text delayText; //text to display
    public Vector3 delayTextOffset; //position offset of text

    [Header("Shooting Properties")]
    public bool isShooting; //is player shooting bullets
    public int currentBulletCount; //current number of bullets shot
    public int bulletTotal; //total amount of bullets to shoot
    public float delayConst; //delay each shot by this amount

    // Start is called before the first frame update
    void Start()
    { 
    }

    IEnumerator delayShoot()
    {
        isShooting = true; //start by indicating that we are shooting currently
        currentBulletCount = 1; //set count to 0
        yield return new WaitForEndOfFrame(); //wait a frame
        for (int count = 0; count < bulletTotal; count++) //starting at 0 count up to our total bullet variable and increase our count by only 1 step each time
        {
            Shoot(); //shoot our bullet  
            currentBulletCount = count+1; //keep track of our count so we can reference it later
            yield return new WaitForSeconds(delayConst);//delay for a set amount of time
        } //loop back to the top
        isShooting = false; //once we're done we want to indicate that we arent shooting anymore
    }

    public void ShootBullet()
    {
        StartCoroutine("delayShoot"); //start coroutine for shooting
    }

    public void Shoot()
    {
        Instantiate(Bullet, this.transform.position + (Vector3.right * .75f), Quaternion.identity); //create a bullet
        Destroy(Instantiate(Burst, this.transform.position+(Vector3.right*.75f), Quaternion.Euler(new Vector3(0, 0, -90))), 1); //create the particle effect
        shipPart.transform.localScale = Vector3.one * .65f;
        Camera.main.GetComponent<Cam>().Shake(.15f, .07f);
    }

    // Update is called once per frame
    void Update()
    {
        shipPart.transform.localScale = Vector3.Lerp(shipPart.transform.localScale, Vector3.one, Time.deltaTime * 5);

        delayText.transform.position = this.transform.position+delayTextOffset; //set text position
        delayText.text = currentBulletCount + "/" + bulletTotal; //set text string so we can see the info
        if(!isShooting) currentBulletCount = bulletTotal; //if not shooting then set current bullet count to the total
        if (Input.anyKeyDown && !isShooting) //press a key while not shooting
        {
            ShootBullet(); //start function for shooting
        }
    }
}
