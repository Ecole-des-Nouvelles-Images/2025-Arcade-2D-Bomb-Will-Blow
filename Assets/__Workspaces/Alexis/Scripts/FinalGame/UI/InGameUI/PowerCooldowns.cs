using __Workspaces.Alexis.Scripts.FinalGame.Player;
using UnityEngine;
using UnityEngine.UI;

public class PowerCooldowns : MonoBehaviour
{
    [SerializeField] private Image ShieldImage;
    [SerializeField] private Image DashImage;
    [SerializeField] private Image JetpackCharge;
    
    [SerializeField] private PlayerController Player;

    private void Update()
    {
        ShieldImage.fillAmount = Player.ShieldTimer / Player.PlayerData.ShieldCd;
        if (ShieldImage.fillAmount > 1)
        {
            ShieldImage.fillAmount = 1;
        }
        
        DashImage.fillAmount = Player.DashTimer / Player.PlayerData.DashCd;
        if (DashImage.fillAmount > 1)
        {
            DashImage.fillAmount = 1;
        }

        JetpackCharge.fillAmount = Player.JetpackCurrent / Player.PlayerData.JetpackMax;
        if (Player.JetpackCurrent > Player.PlayerData.JetpackMax)
        {
            Player.JetpackCurrent = Player.PlayerData.JetpackMax;
        }
    }
}
