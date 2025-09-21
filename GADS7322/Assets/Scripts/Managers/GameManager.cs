using System.Threading;
using UnityEditor;
using UnityEngine;

namespace Managers
{
    public class GameManager:MonoBehaviour //hold a dictionary of players
    {
        public static GameManager Instance;
        
        
        public delegate void ElementSwitchAction(EElement CurrentElement);
    
        public static event ElementSwitchAction OnElementSwitch;

        private void Start()
        {

            if (Instance is null)
            {
                Instance = this;
            }
            else
            {
                Destroy(Instance);
                Instance = this;
            }
        }


        public void PlayerSwitchedElement(EElement CurrentElement)
        {
           OnElementSwitch?.Invoke(CurrentElement); 
        }



    }
}