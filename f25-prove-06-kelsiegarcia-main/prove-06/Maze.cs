namespace prove_06;

/// <summary>
/// Defines a maze using a dictionary. The dictionary is provided by the
/// user when the Maze object is created. The dictionary will contain the
/// following mapping:
///
/// (x,y) : [left, right, up, down]
///
/// 'x' and 'y' are integers and represents locations in the maze.
/// 'left', 'right', 'up', and 'down' are boolean are represent valid directions
///
/// If a direction is false, then we can assume there is a wall in that direction.
/// If a direction is true, then we can proceed.  
///
/// If there is a wall, then display "Can't go that way!".  If there is no wall,
/// then the 'currX' and 'currY' values should be changed.
/// </summary>
public class Maze {
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    private Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap) {
        _mazeMap = mazeMap;
    }
    
    /// <summary>
    /// Builds a brand-new Maze with the dictionary initialized for problem 4
    /// </summary>
    public static Maze Build() {
        return new Maze(new() {
            { (1, 1), [false, true, false, true] },
            { (1, 2), [false, true, true, false] },
            { (1, 3), [false, false, false, false] },
            { (1, 4), [false, true, false, true] },
            { (1, 5), [false, false, true, true] },
            { (1, 6), [false, false, true, false] },
            { (2, 1), [true, false, false, true] },
            { (2, 2), [true, false, true, true] },
            { (2, 3), [false, false, true, true] },
            { (2, 4), [true, true, true, false] },
            { (2, 5), [false, false, false, false] },
            { (2, 6), [false, false, false, false] },
            { (3, 1), [false, false, false, false] },
            { (3, 2), [false, false, false, false] },
            { (3, 3), [false, false, false, false] },
            { (3, 4), [true, true, false, true] },
            { (3, 5), [false, false, true, true] },
            { (3, 6), [false, false, true, false] },
            { (4, 1), [false, true, false, false] },
            { (4, 2), [false, false, false, false] },
            { (4, 3), [false, true, false, true] },
            { (4, 4), [true, true, true, false] },
            { (4, 5), [false, false, false, false] },
            { (4, 6), [false, false, false, false] },
            { (5, 1), [true, true, false, true] },
            { (5, 2), [false, false, true, true] },
            { (5, 3), [true, true, true, true] },
            { (5, 4), [true, false, true, true] },
            { (5, 5), [false, false, true, true] },
            { (5, 6), [false, true, true, false] },
            { (6, 1), [true, false, false, false] },
            { (6, 2), [false, false, false, false] },
            { (6, 3), [true, false, false, false] },
            { (6, 4), [false, false, false, false] },
            { (6, 5), [false, false, false, false] },
            { (6, 6), [true, false, false, false] }
        });
    }

    // Todo Problem 4 - ADD YOUR CODE HERE
    /// <summary>
    /// Check to see if you can move left. If you can, then move and return true.
    /// If you can't move, then don't move and return false
    /// </summary>
    /// <returns><c>true</c> if able to move, otherwise <c>false</c></returns>
    public bool MoveLeft()
    {
        Console.WriteLine($"MoveLeft() from ({_currX},{_currY})");

        if (_mazeMap[(_currX, _currY)][0])
        {
            _currX -= 1;
            return true;
        }
        else
        {
            Console.WriteLine("Wall");

            return false;
        }
    }

    /// <summary>
    /// Check to see if you can move right. If you can, then move and return true.
    /// If you can't move, then don't move and return false
    /// </summary>
    /// <returns><c>true</c> if able to move, otherwise <c>false</c></returns>
    public bool MoveRight() {
        Console.WriteLine($"MoveRight() from ({_currX},{_currY})");

        if (_mazeMap[(_currX, _currY)][1])
        {
            _currX += 1;
            return true;
        }
        else
        {
            Console.WriteLine("Wall");
            return false;   
        }
    }

    /// <summary>
    /// Check to see if you can move up. If you can, then move and return true.
    /// If you can't move, then don't move and return false
    /// </summary>
    /// <returns><c>true</c> if able to move, otherwise <c>false</c></returns>
    public bool MoveUp() {
        Console.WriteLine($"MoveUp() from ({_currX},{_currY})");

        if (_mazeMap[(_currX, _currY)][2])
        {
            _currY -= 1;
            return true;
        }
        else
        {
            Console.WriteLine("Wall");
            return false;
        }
    }

    /// <summary>
    /// Check to see if you can move down. If you can, then move and return true.
    /// If you can't move, then don't move and return false
    /// </summary>
    /// <returns><c>true</c> if able to move, otherwise <c>false</c></returns>
    public bool MoveDown() {
        Console.WriteLine($"MoveDown() from ({_currX},{_currY})");

        if (_mazeMap[(_currX, _currY)][3])
        {
            _currY += 1;
            return true;
        }
        else
        {
            Console.WriteLine("Wall");
            return false;
        }
    }

    public (int, int) GetStatus() {
        Console.WriteLine($"Current location (x={_currX}, y={_currY})");
        return (_currX, _currY);
    }
}