﻿using UnityEngine;
using System.Collections;

public class DeadState : StateBase {
	
	private int stateIndex = 1;
	
	public DeadState (CharacterMain character) : base(character) { }
	
	public override int StateKind { get { return stateIndex; } }
	
	public override void Actualize () { base.Actualize (); }
	
	public override void ExecuteStateActions () {}
	
}