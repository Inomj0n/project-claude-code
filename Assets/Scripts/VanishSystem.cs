using System.Collections;
using System.Drawing;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VanishSystem : MonoBehaviour
{
    private SpriteRenderer sprite;
    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        var color = sprite.color;
        color.a = 1;
        sprite.color = color;
        StartCoroutine("Vanish");
    }

    private IEnumerator Vanish()
    {
        var color = sprite.color;
        while (color.a >= 0)
        {
            color.a -= 0.01f;
            sprite.color = color;
            yield return new WaitForSeconds(0.01f);
        }
        yield break;
    }
}
