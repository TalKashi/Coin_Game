using UnityEngine;
using System.Collections;

public class Coin
{
    int m_value;
    Player m_player;

    public Coin(int i_value, Player i_player)
    {
        m_value = i_value;
        m_player = i_player;
    }

    public void OnClickEvent()
    {
        m_player.AddMoney(m_value);
    }

    public void SetNewValue(int i_newValue)
    {
        m_value = i_newValue;
    }
}
