using UnityEngine;
using System.Collections;

public class ObstacleChecker
{
    private GameObject[] _walls;

	public enum Direction
	{
		FWD_X,
		FWD_Z,
		BWD_X,
		BWD_Z
	}

	public void Initialize()
	{
	    _walls = GameObject.FindGameObjectsWithTag ("Wall");
	}

	public bool checkWall(Vector3 curr, Vector3 forward)
	{
		BoardPoint curr_p = new BoardPoint(curr.x, curr.z);
		BoardPoint next_p;

        if (forward.x > 0.1f)
		{
    		next_p = new BoardPoint (curr.x + 1.0f, curr.z);
            Debug.Log("CHECKING RIGHT " + next_p.getX() + " " + next_p.getZ());
			return checkWall (curr_p, next_p, Direction.FWD_X);
		}
        else if (forward.x < -0.1f)
        {
			next_p = new BoardPoint (curr.x - 1.0f, curr.z);
            Debug.Log("CHECKING LEFT " + next_p.getX() + " " + next_p.getZ());
			return checkWall (curr_p, next_p, Direction.BWD_X);
		}
        else if (forward.z > 0.1f)
		{
			next_p = new BoardPoint (curr.x, curr.z + 1.0f);
            Debug.Log("CHECKING UP " + next_p.getX() + " " + next_p.getZ());
			return checkWall (curr_p, next_p, Direction.FWD_Z);
		}
        else if(forward.z < -0.1f)
		{
			next_p = new BoardPoint (curr.x, curr.z - 1.0f);
            Debug.Log("CHECKING DOWN " + next_p.getX() + " " + next_p.getZ());
			return checkWall (curr_p, next_p, Direction.BWD_Z);
		}
        Debug.LogError("SHOULD NOT BE POSSIBLE");
		return false;
	}

    public bool checkWall(BoardPoint curr, BoardPoint next, Direction dir)
	{
		foreach(GameObject wall in _walls)
		{
			Vector3 position = wall.transform.position;
			switch (dir)
			{
                case Direction.FWD_X:
                    if (position.x > curr.getX() && position.x < next.getX() && Mathf.Abs(position.z - curr.getZ()) < 0.05)
                    {
                        Debug.Log("FOUND WALL IN FWD_X " + position);
                        return wall.GetComponent<Marker>().Active;
                    }
				break;
                case Direction.FWD_Z:
                    if (position.z > curr.getZ() && position.z < next.getZ() && Mathf.Abs(position.x - curr.getX()) < 0.05)
                    {
                        Debug.Log("FOUND WALL IN FWD_Z " + position);
                        return wall.GetComponent<Marker>().Active;
                    }
				break;
                case Direction.BWD_X:
                    if (position.x < curr.getX() && position.x > next.getX() && Mathf.Abs(position.z - curr.getZ()) < 0.05)
                    {
                        Debug.Log("FOUND WALL IN BWD_X " + position);
                        return wall.GetComponent<Marker>().Active;
                    }
				break;
                case Direction.BWD_Z:
                    if (position.z < curr.getZ() && position.z > next.getZ() && Mathf.Abs(position.x - curr.getX()) < 0.05)
                    {
                        Debug.Log("FOUND WALL IN BWD_Z " + position);
                        return wall.GetComponent<Marker>().Active;
                    }
				break;
			}
		}
        Debug.Log("FOUND NO WALL");
		return false;
	}


}
