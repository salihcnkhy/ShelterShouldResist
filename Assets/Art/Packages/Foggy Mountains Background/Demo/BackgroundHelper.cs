using Game.GameObjects.Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundHelper : MonoBehaviour
{
    [SerializeField]
    private float speed = 0;
    float pos = 0;
    private RawImage image;
    private Rigidbody2D CharacterRb;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<RawImage>();
        CharacterRb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        pos += CharacterRb.velocity.x * Time.deltaTime * speed;

        if (pos > 1.0F)

            pos -= 1.0F;

        image.uvRect = new Rect(pos, 0, 1, 1);
    }
}
