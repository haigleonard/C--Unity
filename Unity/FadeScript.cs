using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class FadeScript : MonoBehaviour {

    private float timer = 2.5f;
    private float timer2 = 2.5f;
    public Renderer rend;
    
    //0 - fade in, 1 - fade out
    private int fade = 0;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material.color = new Color(0, 0, 0, 1);

        //StartCoroutine("WaitSceneEnd");
    }

    /*IEnumerator WaitSceneEnd()
    {
        yield return new WaitForSeconds(85);
        fade = 1;
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene("endScene");
    }*/

    void Update()
    {
        if(fade == 0)
        {
            timer = timer - Time.deltaTime;

            if (timer >= 0)
            {
                Color temp = new Color(0, 0, 0, rend.material.color.a - 0.007f);
                rend.material.color = temp;
            }

            if (timer <= 0)
            {
                timer = 0;
            }
        }
        else
        {
            timer2 = timer2 - Time.deltaTime;

            if (timer2 >= 0)
            {
                Color temp = new Color(0, 0, 0, rend.material.color.a + 0.007f);
                rend.material.color = temp;
            }

            if (timer2 <= 0)
            {
                timer2 = 0;
            }
        }
    }
}
