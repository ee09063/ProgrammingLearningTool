using UnityEngine;
using System.Collections;

public class ObstacleChecker
{
	private GameObject[] walls;

	public enum Direction
	{
		FWD_X,
		FWD_Y,
		BWD_X,
		BWD_Y
	}

	public void Initialize()
	{
		if (walls == null)
		{
			walls = GameObject.FindGameObjectsWithTag ("Wall");
		}
	}

	public bool checkWall(Vector3 curr, Vector3 forward)
	{
		BoardPoint curr_p = new BoardPoint(curr.x, curr.y);
		BoardPoint next_p;

		if (forward == Vector3.right)
		{
			next_p = new BoardPoint (curr.x + 1.0f, curr.y);
			return checkWall (curr_p, next_p, Direction.FWD_X);
		}
		else if (forward.Equals (Vector3.left))
		{
			next_p = new BoardPoint (curr.x - 1.0f, curr.y);
			return checkWall (curr_p, next_p, Direction.BWD_X);
		}
		else if (forward.Equals (Vector3.up))
		{
			next_p = new BoardPoint (curr.x, curr.y + 1.0f);
			return checkWall (curr_p, next_p, Direction.FWD_Y);
		}
		else if(forward.Equals(Vector3.down))
		{
			next_p = new BoardPoint (curr.x, curr.y - 1.0f);
			return checkWall (curr_p, next_p, Direction.BWD_Y);
		}
		return false;
	}

    public bool checkWall(BoardPoint curr, BoardPoint next, Direction dir)
	{
		foreach(GameObject wall in walls)
		{
			Vector3 position = wall.transform.position;
			switch (dir)
			{
			case Direction.FWD_X:
				if (position.x > curr.getX () && position.x < next.getX ())
                    return wall.GetComponent<EditModeMarker>().Active;
				break;
			case Direction.FWD_Y:
				if (position.y > curr.getY () && position.y < next.getY ())
                    return wall.GetComponent<EditModeMarker>().Active;
				break;
			case Direction.BWD_X:
				if (position.x < curr.getX () && position.x > next.getX ())
                    return wall.GetComponent<EditModeMarker>().Active;
				break;
			case Direction.BWD_Y:
				if (position.y < curr.getY () && position.y > next.getY ())
                    return wall.GetComponent<EditModeMarker>().Active;
				break;
			}
		}
		return false;
	}


}
