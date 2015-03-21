using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum WinType {Normal, Super,Mega, Lost};

public class PayTableScript : MonoBehaviour {

	public Vector3[] m_winVector;
	public int[] m_multiplierVector;
	public WinType[] m_winTypeVector;
	private ArrayList m_normalWinIndexOfVector;
	private ArrayList m_superWinIndexOfVector;
	private ArrayList m_megaWinIndexOfVector;


	void Awake(){
		m_normalWinIndexOfVector = new ArrayList();
		m_superWinIndexOfVector = new ArrayList();
		m_megaWinIndexOfVector = new ArrayList();

	}

	public void GenerateLists()
	{
		for (int i = 0; i < m_winTypeVector.Length; i++) 
		{
			switch (m_winTypeVector[i])
			{
			case WinType.Normal:
				m_normalWinIndexOfVector.Add(i);
				break;
			case WinType.Mega:
				m_megaWinIndexOfVector.Add(i);
				break;
			case WinType.Super:
				m_superWinIndexOfVector.Add(i);
				break;
			}

		}
	}

    public Dictionary<string, object> Contains(int[] i_spinResult)
    {
        bool won = false;
        Dictionary<string, object> resultDictionary = new Dictionary<string, object>();
        for (int i = 0; i < m_winVector.Length && !won; i++)
        {
            for (int j = 0; j < i_spinResult.Length; j++)
            {
                if (i_spinResult[j] != m_winVector[i][j])
                {
                    break;
                }
                if (j == i_spinResult.Length - 1)
                {
                    won = true;
                    resultDictionary["winMultiplier"] = m_multiplierVector[i];
                    resultDictionary["winVectorIndex"] = i;
                    // More stuff?
                }
            }
        }
        if (!won)
        {
            resultDictionary["winMultiplier"] = 0;
            resultDictionary["winVectorIndex"] = -1;
        }

        return resultDictionary;
    }

	public int GetMultiplier(int i_index){
		return m_multiplierVector [i_index];
	}
	public Vector3 GetVector(int i_index){
		return m_winVector [i_index];
	}
	public WinType GetWinType(int i_index){
		return m_winTypeVector [i_index];
	}

	public ArrayList GetNormalWinList()
	{
		return m_normalWinIndexOfVector;
	}

	public ArrayList GetSuperWinList()
	{
		return m_superWinIndexOfVector;
	}

	public ArrayList GetMegaWinList()
	{
		return m_megaWinIndexOfVector;
	}

}
