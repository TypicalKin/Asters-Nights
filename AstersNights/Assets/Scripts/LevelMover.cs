using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMover : MonoBehaviour
{
public LevelLoader levelLoader;

private void OnTriggerEnter(Collider _)
{
  levelLoader.LoadNextLevel();
}
}
