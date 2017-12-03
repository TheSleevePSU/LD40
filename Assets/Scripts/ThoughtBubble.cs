using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThoughtBubble : MonoBehaviour {

	public enum Thought { questionMark, exclamationPoint, x }
	public Sprite questionMarkSprite;
	public Sprite exclamationPointSprite;
	public Sprite xSprite;

	SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
		spriteRenderer = (SpriteRenderer) GetComponent(typeof(SpriteRenderer));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void UpdateThought(Thought thought) {
		switch (thought) {
			case Thought.questionMark:
				spriteRenderer.sprite = questionMarkSprite;
				break;
			case Thought.exclamationPoint:
				spriteRenderer.sprite = exclamationPointSprite;
				break;
			case Thought.x:
				spriteRenderer.sprite = xSprite;
				break;
			default:
				spriteRenderer.sprite = questionMarkSprite;
				break;
		}
	}
}
