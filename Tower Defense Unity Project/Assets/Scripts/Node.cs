using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

	public Color hoverColor;
	public Color notEnoughMoneyColor;
    public Vector3 positionOffset;

	public GameObject turretTemplate;

	[HideInInspector]
	public GameObject turret;

	private void Start()
	{
		turret = null;
		positionOffset = new Vector3(0f, 0f, 0f);
	}
	private void Update()
	{
		
	}
	public Vector3 GetBuildPosition ()
	{
		return transform.position + positionOffset;
	}

	void OnMouseDown ()
	{
		if (turret != null)
		{
			DestroyTurret();
		}
		else
		{
			BuildTurret(turretTemplate);
		}

	}

	void BuildTurret (GameObject __turret)
	{
        if (turretTemplate == null)
        {
            Debug.LogError("Error! Turret template is not assigned!");
            return;
        }

        turret = Instantiate(__turret, GetBuildPosition(),Quaternion.identity);
		
		Debug.Log("Turret build successfully!");
	}


	public void DestroyTurret ()
	{
        if (turret == null)
        {
            Debug.LogError("Error! No turret to destroy!");
            return;
        }
        Destroy(turret);
        turret = null;

        Debug.Log("Turret destroyed successfully!");
    }



}
