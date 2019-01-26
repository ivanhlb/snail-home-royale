using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gobbler
{
	public class PlayerController : MonoBehaviour
	{
		[SerializeField] SpriteRenderer spriteRenderer;
		[SerializeField] SpriteRenderer gobblerShell;
		[SerializeField] Sprite gobblerSprite1;
		[SerializeField] Sprite gobblerSprite2;
		[SerializeField] Sprite gobblerStunnedSprite;

		[SerializeField] Vector3 gobblerShellPos1;
		[SerializeField] Vector3 gobblerShellPos2;
		[SerializeField] Vector3 gobblerShellStunPos;

		[SerializeField] float gobbleDuration = 0.05f;

		Coroutine gobbleAnimationCoroutine;

		bool isStunned = false;

		public void Gobble ()
		{
			if (isStunned)
				return;

			if (gobbleAnimationCoroutine != null)
				StopCoroutine (gobbleAnimationCoroutine);

			gobbleAnimationCoroutine = StartCoroutine (GobbleAnimationCoroutine ());

			//play gobble sound
		}

		IEnumerator GobbleAnimationCoroutine ()
		{
			spriteRenderer.sprite = gobblerSprite2;
			yield return new WaitForSeconds (gobbleDuration);

			if (isStunned)
				yield break;

			spriteRenderer.sprite = gobblerSprite1;
		}

		public void GetStunned ()
		{
			isStunned = true;

			spriteRenderer.sprite = gobblerStunnedSprite;

			//play stun sound
		}

		public void GetUnstunned ()
		{
			isStunned = false;

			spriteRenderer.sprite = gobblerSprite1;
		}

		public void SetShellColour (Color color)
		{
			gobblerShell.color = color;
		}
	}
}