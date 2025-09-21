using System;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;

namespace Managers
{
    public class GameManager:MonoBehaviour //hold a dictionary of players? or just hold the player elements
    {
        [SerializeField] private PlayerController[] playersInScene = new PlayerController[2]; 

        private Dictionary<PlayerController, PlayerController> players =
            new Dictionary<PlayerController, PlayerController>();

        public IReadOnlyDictionary<PlayerController, PlayerController> Players => players;
        
        
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
            
            players.Add(playersInScene[0],playersInScene[1]);
            players.Add(playersInScene[1],playersInScene[0]);
        }


        public void PlayerSwitchedElement(EElement CurrentElement)
        {
           OnElementSwitch?.Invoke(CurrentElement); 
        }


        private void OnValidate()
        {
            if(playersInScene.Length > 2)
            {
              Array.Resize(ref playersInScene,2);
              Debug.Log("Too many players resized array");
            }
        }
    }
}