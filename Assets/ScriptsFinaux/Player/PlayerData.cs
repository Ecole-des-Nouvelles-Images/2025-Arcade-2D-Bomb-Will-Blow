using UnityEngine;

namespace ScriptsFinaux.Player
{
    [CreateAssetMenu(fileName = "NewPlayerData", menuName = "Data/PlayerData")]
    public class PlayerData : ScriptableObject
    {
        //Health
        public int HealthMax = 5;
        
        //Movement
        public int MoveSpeed = 1;
        
        //Dash
        public float DashDuration = 0.5f;
        public float DashCd = 5f;
        public Vector2 DashDeathLine = new(0, 5);
        public int DashForce = 50;
        public AnimationCurve DashCurve;

        //Jetpack
        public int JetpackMax;
        public int JetpackForce;
        
        //Shield
        public float ShieldCd = 5;
       
        //Wall
        public float SlideDownForce;
        
        //Win 
        public bool P1Win;
        public bool P2Win;
    }
}