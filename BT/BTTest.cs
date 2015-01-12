using UnityEngine;
using System.Collections;
using SlgGame.AI;

public class BTTest : MonoBehaviour
{
		private BevSelector m_AI;
		// Use this for initialization
		void Start ()
		{
				m_AI = new BevSelector ();
				/*BevAction up = new BevAction (MoveUp);
				up.Condition = new BevCondition (OnUp);
				BevAction down = new BevAction (MoveDown);
				down.Condition = new BevCondition (OnDown);
				BevAction left = new BevAction (MoveLeft);
				left.Condition = new BevCondition (OnLeft);
				BevAction right = new BevAction (MoveRight);
				right.Condition = new BevCondition (OnRight);
				*/
				BevAction other = new BevAction (MoveUp);
				m_AI.AddChild (other);
				other.Condition = new BevCondition (OnRight) & OnLeft;
		}

		void OnGUI ()
		{

		}

		public void Action ()
		{
				Debug.Log ("Action");
		}
		// Update is called once per frame
		void Update ()
		{
				m_AI.Tick ();
		}

		public bool OnUp ()
		{
				return Input.GetKey (KeyCode.W);
		}

		public bool OnDown ()
		{
				return Input.GetKey (KeyCode.S);
		}

		public bool OnLeft ()
		{
				return Input.GetKey (KeyCode.A);
		}

		public bool OnRight ()
		{
				return Input.GetKey (KeyCode.D);
		}

		public void MoveLeft ()
		{
				transform.Translate (Vector3.left);
		}

		public void MoveRight ()
		{
				transform.Translate (Vector3.right);
		}

		public void MoveUp ()
		{
				transform.Translate (Vector3.up);
		}

		public void MoveDown ()
		{
				transform.Translate (Vector3.down);
		}
}
