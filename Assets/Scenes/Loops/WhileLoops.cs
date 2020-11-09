using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Shapes;

public class WhileLoops : MonoBehaviour
{
    [Header("Helper Properties")]
    public GameObject Bullet; //bullet ojbect
    public GameObject Burst; //burst effect
    public GameObject shipPart;
    public Text delayText; //text to display
    public Vector3 delayTextOffset; //position offset of text
    public GameObject crossHair;
    public GameObject crossHair2;
    public GameObject crossHair3;
    public GameObject sightLine;

    [Header("Shooting Properties")]
    public float delayConst; //delay each shot by this amount
    public bool lockDown;

    // Start is called before the first frame update
    void Start()
    {
    }

    IEnumerator delayShoot()
    {
        while (lockDown == true) //while lockdown is true we loop
        {
           
            yield return new WaitForSeconds(delayConst);//delay for a set amount of time
            Shoot(); //shoot our bullet 
        } //loop back to the top
    }

    public void ShootBullet()
    {
        if (!lockDown)
        {
            lockDown = true;
            StartCoroutine("delayShoot"); //start coroutine for shooting
        }
    }

    public void Shoot()
    {
        Instantiate(Bullet, this.transform.position + (Vector3.right * .75f), Quaternion.identity); //create a bullet
        Destroy(Instantiate(Burst, this.transform.position + (Vector3.right * .75f), Quaternion.Euler(new Vector3(0, 0, -90))), 1); //create the particle effect
        shipPart.transform.localScale = Vector3.one * .65f;
        Camera.main.GetComponent<Cam>().Shake(.15f, .07f);
        crossHair.transform.localScale = Vector3.one * .65f;
        crossHair.transform.Rotate(Vector3.forward, 360*Mathf.Deg2Rad);

        crossHair.GetComponent<Disc>().Color = Color.white;
        crossHair2.GetComponent<Line>().Color = Color.white;
        crossHair3.GetComponent<Line>().Color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        shipPart.transform.localScale = Vector3.Lerp(shipPart.transform.localScale, Vector3.one, Time.deltaTime * 5);
        crossHair.transform.localScale = Vector3.Lerp(crossHair.transform.localScale, Vector3.one, Time.deltaTime * 20);
        crossHair.GetComponent<Disc>().Color = Color.Lerp(crossHair.GetComponent<Disc>().Color, Color.red, Time.deltaTime * 5);
        crossHair2.GetComponent<Line>().Color = Color.Lerp(crossHair2.GetComponent<Line>().Color, Color.red, Time.deltaTime * 5);
        crossHair3.GetComponent<Line>().Color = Color.Lerp(crossHair3.GetComponent<Line>().Color, Color.red, Time.deltaTime * 5);

        delayText.transform.position = this.transform.position + delayTextOffset; //set text position
        if (lockDown) delayText.text = "Locked On!";
        else delayText.text = "";

        if (Physics2D.CircleCast(new Vector2(transform.position.x, transform.position.y) + Vector2.right, .65f, Vector2.right)) //check if crosshairs are in sight
        {
            ShootBullet(); //start function for shooting
            
            sightLine.GetComponent<Line>().DashOffset -= Time.deltaTime*5; //animate sightline
        }
        else //if no crosshairs in sight set lockdown to false
        {
            lockDown = false;
        }
    }
}
