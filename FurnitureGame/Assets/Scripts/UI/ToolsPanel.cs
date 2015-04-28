using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ToolsPanel : MonoBehaviour
{
	public RectTransform panel;
	public Image targetImage;
	public Sprite openSprite;
	public Sprite closedSprite;


	private bool isOpen = false;


	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void ButtonTogglePanel (){
		if (this.isOpen) {
			this.isOpen = false;
			this.targetImage.sprite = this.closedSprite;
			StopCoroutine ("OpenPanel");
			StopCoroutine ("ClosePanel");
			StartCoroutine ("ClosePanel");
		} else {
			this.isOpen = true;
			this.targetImage.sprite = this.openSprite;
			StopCoroutine ("OpenPanel");
			StopCoroutine ("ClosePanel");
			StartCoroutine ("OpenPanel");
		}
	}


	IEnumerator OpenPanel (){
		float timer = 0.0f;
		float maxTime = 1.0f;

		if (this.panel != null) {
			while (timer < maxTime) {
				yield return new WaitForEndOfFrame ();
				timer += Time.deltaTime;

				this.panel.rect.Set (
					Mathf.Lerp (this.panel.rect.xMin, -this.panel.rect.width, timer / maxTime),
					this.panel.rect.yMin,
					this.panel.rect.width,
					this.panel.rect.height
				);

				Debug.Log (timer);
			}
		}
	}


	IEnumerator ClosePanel (){
		float timer = 0.0f;
		float maxTime = 1.0f;

		if (this.panel != null) {
			while (timer < maxTime) {
				yield return new WaitForEndOfFrame ();
				timer += Time.deltaTime;

				this.panel.rect.Set (
					Mathf.Lerp (this.panel.rect.xMin, this.panel.rect.width, timer / maxTime),
					this.panel.rect.yMin,
					this.panel.rect.width,
					this.panel.rect.height
				);

				Debug.Log (timer);
			}
		}
	}
}

