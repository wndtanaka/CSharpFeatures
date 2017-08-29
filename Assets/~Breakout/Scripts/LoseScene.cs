using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Breakout
{
    public class LoseScene : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D col)
        {
            if (this.gameObject.tag == "Lose") // check if this gamobject has "Lose" Tag
            {
                SceneManager.LoadScene("LoseScene"); // go to lose scene
            }
        }

    }
}

