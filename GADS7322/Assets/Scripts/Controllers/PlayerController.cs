using System;
using System.Collections.Generic;
using System.Threading;
using Managers;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Player Components")]
    [SerializeField] private Rigidbody2D playerBody;
    [SerializeField] private PlayerCharacter character;
     private EElement[] AvailableElements;
     
     
    [Header("Player Values")]
    [SerializeField] private float maxMoveSpeed;
    [SerializeField] private float JumpSpeed;
    [SerializeField] private float jumpHeight;
    [SerializeField] private EElement defaultElement;
    
    
    private EElement chosenElement;
    private Queue<EElement> PlayerElements = new Queue<EElement>();
    private Stack<EElement> SwapStack = new Stack<EElement>();

    public EElement ChosenElement => chosenElement;

    private void Start()
    {

        AvailableElements = character.Elements;
        
        foreach (EElement element in AvailableElements)
        {
            PlayerElements.Enqueue(element);
        }

        for(int i=0;i<AvailableElements.Length;i++)//make a character handle sprites and rest of bullshit
        {
            chosenElement = PlayerElements.Dequeue();

            if(chosenElement == defaultElement)
            {
                break;
            }
            
            PlayerElements.Enqueue(chosenElement);
        }
        
        character.SetSprite(chosenElement);
    }

    private void ReverseElementOrder()
    {
        for(int i=0;i<PlayerElements.Count;i++)
        {
            SwapStack.Push(PlayerElements.Dequeue());
        }

        for(int i=0;i<SwapStack.Count;i++)
        {
            PlayerElements.Enqueue(SwapStack.Pop());
        }
    }

    private void UpdateGameManager()
    {
        GameManager.Instance.PlayerSwitchedElement(chosenElement);
    }
    
    
    


    public void MovePlayer(InputAction.CallbackContext contextCallback)//find a way to slow down rather than dead stop
    {
        Vector2 CallbackDirection = contextCallback.ReadValue<Vector2>();

        Vector2 MoveDirection = new Vector2(CallbackDirection.x*maxMoveSpeed,playerBody.linearVelocity.y);
        Vector2 MoveVector = MoveDirection;

        playerBody.linearVelocity = MoveVector;
    }


    public void Jump(InputAction.CallbackContext contextCallback)
    {
        if(!contextCallback.performed)
            return;

        Vector2 JumpDirection = new Vector2(playerBody.linearVelocity.x, jumpHeight*JumpSpeed);

        playerBody.linearVelocity = JumpDirection;
    }

    public void CycleElementForward(InputAction.CallbackContext contextCallback)//peek the queueu if same as player two just enqueu it and pop again
    {
        if(!contextCallback.performed)
            return;

        if(GameManager.Instance.Players[this].chosenElement == PlayerElements.Peek())
        {
            PlayerElements.Enqueue(PlayerElements.Dequeue());
        }
        
        
        PlayerElements.Enqueue(chosenElement);
        chosenElement = PlayerElements.Dequeue();
        UpdateGameManager();
        character.SetSprite(chosenElement);
        Debug.Log(ChosenElement);
    }

    public void CycleElementBackward(InputAction.CallbackContext contextCallback)
    {
        if(!contextCallback.performed)
            return;
        
        ReverseElementOrder();
        
        if(GameManager.Instance.Players[this].chosenElement == PlayerElements.Peek())
        {
            PlayerElements.Enqueue(chosenElement);
            PlayerElements.Enqueue(PlayerElements.Dequeue());
        }
        
        
        PlayerElements.Enqueue(chosenElement);
        chosenElement = PlayerElements.Dequeue();
        ReverseElementOrder();
       UpdateGameManager();
       character.SetSprite(chosenElement);
       Debug.Log(ChosenElement);
    }
    
    
    
}
