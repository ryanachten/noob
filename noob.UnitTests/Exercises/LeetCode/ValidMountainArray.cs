using Xunit;

namespace noob.UnitTests.Exercises.LeetCode;

public class ValidMountainArrayTest
{
    private enum State
    {
        UNKNOWN,
        PLATEAU,
        ASCENT,
        DESCENT
    }

    public static bool ValidMountainArray(int[] arr)
    {
        if (arr.Length < 3) return false;

        var currentState = State.UNKNOWN;

        for (int i = 1; i < arr.Length; i++)
        {
            var newState = GetState(arr, i);
            if (!ValidateState(currentState, newState)) return false;

            currentState = newState;
        }

        if (currentState != State.DESCENT) return false;

        return true;
    }

    private static State GetState(int[] arr, int i)
    {
        if (arr[i - 1] == arr[i]) return State.PLATEAU;
        if (arr[i - 1] < arr[i]) return State.ASCENT;
        if (arr[i - 1] > arr[i]) return State.DESCENT;

        return State.UNKNOWN;
    }

    private static bool ValidateState(State currentState, State newState)
    {
        if (newState == State.PLATEAU) return false;
        if (currentState == State.UNKNOWN && newState == State.DESCENT) return false;
        if (currentState == State.DESCENT && newState == State.ASCENT) return false;

        return true;
    }

    public static TheoryData<int[], bool> Arrays =>
    new()
    {
        { [ 1 ], false },
        { [ 1, 1 ], false },
        { [ 1, 1, 1 ], false },
        { [ 1, 1, 2 ], false },
        { [ 2, 1, 2 ], false },
        { [ 1, 2, 3 ], false },
        { [ 1, 2, 2 ], false },
        { [ 3, 2, 1 ], false },
        { [ 3, 2, 2 ], false },
        { [ 1, 2, 1 ], true },
    };

    [Theory]
    [MemberData(nameof(Arrays))]
    public void GivenArray_WhenValidatingMountain_ThenMountainIsCorrectlyDetermined(int[] digits, bool expectedResult)
    {
        var result = ValidMountainArray(digits);
        Assert.Equal(expectedResult, result);
    }
}