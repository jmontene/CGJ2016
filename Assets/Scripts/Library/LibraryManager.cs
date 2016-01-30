using UnityEngine;
using System.Collections;

public class LibraryManager : UnitySingleton<LibraryManager> {

	public int Score;


	public override void Awake() {
		base.Awake();
		Score = 2000;
	}
}
