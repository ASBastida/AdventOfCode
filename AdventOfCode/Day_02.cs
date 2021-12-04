namespace AdventOfCode;

public class Day_02 : BaseDay
{
    private readonly IEnumerable<string> _input;
    private readonly IEnumerable<(string direction, int magnitude)> _directions;

    public Day_02()
    {
        _input = File.ReadAllLines(InputFilePath);
        _directions = ProcessInput();
    }

    public override ValueTask<string> Solve_1()
    {
        var depth = 0;
        var distance = 0;

        foreach(var d in _directions)
        {
            if(d.direction == "forward")
            {
                distance += d.magnitude;
            }
            else
            {
                depth += d.direction == "down" ? d.magnitude : -d.magnitude;
            }
        }

        return ValueTask.FromResult((depth*distance).ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        var aim = 0;
        var distance = 0;
        var depth = 0;

        foreach(var d in _directions)
        {
            if(d.direction == "forward")
            {
                distance +=d.magnitude;
                depth += d.magnitude*aim;
            }
            else
            {
                var sign = d.direction == "down" ? 1 : -1;
                aim += sign * d.magnitude;
            }
        }

        return ValueTask.FromResult((depth*distance).ToString());
    }

    private IEnumerable<(string direction, int magnitude)> ProcessInput()
    {
        return _input.Select(x => {
            var parts = x.Split(" ");

            return (parts[0], int.Parse(parts[1]));
        });
    }
}
