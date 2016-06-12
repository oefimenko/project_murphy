﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ShipState {

	private static ShipState instance;
	private static readonly object locker = new object();

	public Door[] allDoors;
	public IRoom[] allRooms;
	public ICharacter[] allCharacters;
	public ICharacter player;
	public Dictionary<Enums.RoomTypes, IRoom> specRooms;
	private ShipStructure shipStructure;

	private ShipState () { }

	public static ShipState Inst
	{
		get
		{
			lock (locker)
			{
				if (instance == null) instance = new ShipState();
			}
			return instance;
		}
	}

	public void Init ()
	{
		CreateRoomAndDoorsLists ();
		CreateShipStructureGraph ();
	}

	public void CountCharacters ()
	{
		allCharacters = StoreComponent<Character>(GameObject.FindGameObjectsWithTag("Character"));
		player = System.Array.Find(allCharacters, v => v.Type == Enums.CharacterTypes.Murphy);
		if (player != null) GameObject.FindGameObjectWithTag("GameController").GetComponent<Navigation>().Player = player;
	}

	// Returns list of world points for NPC traveling
	public List<Vector3> GetStepsToRoom (IRoom initialRoom, IRoom targetRoom) {
		if (initialRoom == targetRoom) 
			return new List<Vector3>() { };
		else
			return shipStructure.GetStepsToRoom(initialRoom, targetRoom);
	}

	public IRoom RandomNamedRoom ()
	{
		return Helpers.GetRandomArrayValue<IRoom>(specRooms.Values.ToArray());
	}

	public IRoom RandomRoom ()
	{
		return Helpers.GetRandomArrayValue<IRoom>(allRooms);
	}

	public IRoom RoomByPoint(Vector3 point)
	{
		IRoom room = null;
		room = allRooms.Single(v => v.GObject.collider2D.OverlapPoint(point));
		return room;
	}

	// Initialize method for creating ship structure as graph
	private void CreateShipStructureGraph ()
	{
		shipStructure = new ShipStructure(allRooms);
	}

	// Updtates lists of doors and rooms 
	private void CreateRoomAndDoorsLists ()
	{	
		allDoors = StoreComponent<Door>(GameObject.FindGameObjectsWithTag("Door"));
		allRooms = StoreComponent<Room>(GameObject.FindGameObjectsWithTag("Room")) as IRoom[];
		AddSpecRooms();
		for (int i = 0; i < allRooms.Length; i++ ) allRooms[i].Neighbors.Clear();
		for (int i = 0; i < allDoors.Length; i++ ) allDoors[i].ConnectNeighbors();
	}

	private T[] StoreComponent<T> (GameObject[] list) where T : UnityEngine.Component
	{
		T[] componentsList = new T[list.Length];
		for (int i = 0; i < list.Length; i++)
		{
			componentsList[i] = list[i].GetComponent<T>();
		}
		return componentsList;
	}

	private void AddSpecRooms ()
	{
		specRooms = new Dictionary<Enums.RoomTypes, IRoom> ();
		for (int i = 0; i < allRooms.Length; i++)
		{
			if (allRooms[i].Type != Enums.RoomTypes.Nothing) specRooms.Add (allRooms[i].Type, allRooms[i]);
		} 
	}
	
}
