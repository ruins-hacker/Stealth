using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float hp = 100;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        if(hp <=0)
        {
            return;
        }
        hp -= damage;
        if(hp<=0)
        {
            anim.SetBool("Dead", true);
            StartCoroutine(reloadScene());
        }
    }

    IEnumerator reloadScene()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(0);
        yield return null;
    }
}
