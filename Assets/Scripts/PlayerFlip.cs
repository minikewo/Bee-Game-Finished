using UnityEngine;

public class PlayerFlip : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    
    private float horizontalInput;

    private bool facingRight = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
        
    }
    
    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        
        SetupDirectionByComponent();
    }
    private void SetupDirectionByComponent()
    {
        if (horizontalInput < 0)
            spriteRenderer.flipX = true;
        else if (horizontalInput > 0)
            spriteRenderer.flipX = false;
    }
}

