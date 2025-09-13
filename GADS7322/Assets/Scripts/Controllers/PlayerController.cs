using Managers;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float MoveSpeed;
    [SerializeField] private EElement[] AvailableElements;

    private EElement chosenElement;
    
    
    
    // test using legacy control scheme and rework to use new scheme
    // don't work too hard on this yet cause kenton tested out making co op stuff so ask him first
    
    
    void Update()
    {

        if(Input.GetKey(KeyCode.A))
        {
            MovePlayer(Vector3.left);
        }
        
        if(Input.GetKey(KeyCode.D))
        {
            MovePlayer(Vector3.right);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            MovePlayer(Vector3.up);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            GameManager.Instance.PlayerSwitchedElement(chosenElement);
        }

        if(Input.GetKeyDown(KeyCode.F))
        {
            chosenElement = AvailableElements[0];
            GameManager.Instance.PlayerSwitchedElement(chosenElement);
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            chosenElement = AvailableElements[1];
            GameManager.Instance.PlayerSwitchedElement(chosenElement);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            chosenElement = AvailableElements[2];
            GameManager.Instance.PlayerSwitchedElement(chosenElement);
        }
        
    }


    private void MovePlayer(Vector3 AMoveDirection)
    {
        Vector3 MoveVector = AMoveDirection * (MoveSpeed * Time.deltaTime);

        gameObject.transform.position += MoveVector;
    }

    private void SwitchElement(EElement AElementToSwitchTo)
    {
        chosenElement = AElementToSwitchTo;
    }
}
