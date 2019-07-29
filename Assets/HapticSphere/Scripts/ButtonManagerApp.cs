using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManagerApp : MonoBehaviour {
    
    //Layout
    //Layout by grid's length
    public float ButtonLength;
    private ButtonLayoutManager buttonLayoutManager;

    //Button
    public GameObject[] Button;

	public void setUpButtons(float forwardAngle)
	{
		buttonLayoutManager = new ButtonLayoutManager(this);

		for (int i = 0; i < Button.Length; i++)
		{
			Button[i].GetComponent<ButtonInfo>().setSphereUI(this.gameObject);
		}

		float radius = this.transform.localScale.x / 2.0f;
		buttonLayoutManager.setUp(ButtonLength, radius, forwardAngle);
	}

    public void setButtonSize(int index, Vector2 size)
    {
        ButtonInfo buttonInfo = Button[index].GetComponent<ButtonInfo>();
        buttonInfo.ButtonSize = size;

        buttonLayoutManager.setUpButtonLayout(Button[index]);
    }

    public void setButtonPosition(int index, Vector2 position)
    {
        ButtonInfo buttonInfo = Button[index].GetComponent<ButtonInfo>();
        buttonInfo.PositionOnSphere = position;

        buttonLayoutManager.setUpButtonLayout(Button[index]);
    }
}
