using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockHandler : MonoBehaviour {

    public Color myColor;

    private AmmoHandler ammo;
    private SpawnController sc;
    private SpriteHandler sh;

    private int randomColor = 0;
    private int randomCandy = 0;

    private Animator myAnim;
    private CircleCollider2D myCircle;

    public static bool playBlockSound;

    void Start()
    {
        sc = FindObjectOfType<SpawnController>();
        ammo = FindObjectOfType<AmmoHandler>();
        sh = FindObjectOfType<SpriteHandler>();
        myAnim = GetComponent<Animator>();
        myCircle = GetComponent<CircleCollider2D>();

        randomCandy = Random.Range(0, sh.candyList.Length);
        randomColor = Random.Range(0, 8);

        myColor = ammo.ammoColors[randomColor];
        GetComponent<SpriteRenderer>().sprite = sh.candyList[randomCandy].candy[randomColor];
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Shot") && myColor == other.gameObject.GetComponent<ShotHandler>().myColor)
        {
            Destroy(other.gameObject);
            ComboFill.fillMe = true;
            BlockDaeth();
        }
        else if (other.gameObject.CompareTag("Shot"))
        {
            Destroy(other.gameObject);
            ComboFill.missedShot = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SPChild") && GetComponent<BlockImmune>().Immune == false)
        {
            BlockDaeth();
        }
    }

    void BlockDaeth()
    {
        sc.newBlock.Remove(this.gameObject);
        UpdateScore.score++;
        GooglePlay.UnlockAchievement(GPGSIds.achievement_beginner_candy_crusher);
        myAnim.enabled = true;
        myCircle.enabled = false;
        myAnim.SetTrigger("Color" + randomColor);
        StartCoroutine(DeathDelay());
        playBlockSound = true;
    }

    //Do this to give time for the explosion animation to play.
    IEnumerator DeathDelay()
    {
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }
}
