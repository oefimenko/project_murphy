﻿using UnityEngine;
using System.Collections;

public class EatState : StateBase {
	
	private int stateIndex = 9;
	
	public EatState (CharacterMain character) : base(character) { }
	
	public override int StateKind { get { return stateIndex; } }
	
	public override void Actualize () { 
		base.Actualize (); 
		NavigateTo(ShipState.Inst.specRooms[Room.RoomTypes.Dinnery]);
	}
	
	public override void ExecuteStateActions () 
	{
		if (character.Movement.IsMoving() == false)
		{
			character.Stats.Fatigue += character.Stats.FatigueIncrease;
			character.View.SetSubState(1);
		}
		if (character.Stats.Fatigue >= character.Stats.MaxFatigue)
			character.PurgeActions();
	}
}

