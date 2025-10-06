using System.Collections.Generic;
using Xunit;

namespace noob.UnitTests.Exercises.NeetCode;

public class TaskScheduler()
{
    public static TheoryData<char[], int, int> Tasks() => new()
    {
        {
            ['A','A','A','B','C'], 3, 9
        },
        {
            ['X','X','Y','Y'], 2, 5
        }
    };

    [Theory]
    [MemberData(nameof(Tasks))]
    public void GivenListOfTasks_WhenFindingSchedule_ThenNumberOfRequiredIntervalsIsReturned(char[] tasks, int n, int expectedResult)
    {
        var result = LeastInterval(tasks, n);

        Assert.Equal(expectedResult, result);
    }

    private static int LeastInterval(char[] tasks, int n)
    {
        var taskFrequencies = new int[26];

        // Get task frequency, using char code to map frequency
        foreach (var task in tasks)
        {
            taskFrequencies[task - 'A']++;
        }

        // Create max heap to store the priority of the tasks
        // we want to process those with the highest priority first
        var heap = new PriorityQueue<int, int>(Comparer<int>.Create((x, y) => y.CompareTo(x)));
        for (int i = 0; i < taskFrequencies.Length; i++)
        {
            var freq = taskFrequencies[i];
            if (freq > 0) heap.Enqueue(i, freq);
        }

        // Create a queue to store when a value can be processed next
        var queue = new Queue<ScheduledTask>();

        var intervals = 0;
        while (heap.Count > 0 || queue.Count > 0)
        {

            // Check if there's a value which can be added to the heap
            // We want to ensure that the next allowable interval of a task has transpired
            if (queue.Count > 0)
            {
                var scheduledTask = queue.Peek();
                if (scheduledTask.NextInterval <= intervals)
                {
                    heap.Enqueue(scheduledTask.TaskIndex, scheduledTask.RemainingCount);
                    queue.Dequeue();
                }
            }

            // Check if theres a value which can be processed from the heap
            // We add tasks back on the heap with an associated next allowable interval
            if (heap.Count > 0)
            {
                heap.TryDequeue(out var task, out var count);
                var remainingCount = count - 1;
                if (remainingCount > 0)
                {
                    queue.Enqueue(new ScheduledTask()
                    {
                        TaskIndex = task,
                        RemainingCount = remainingCount,
                        NextInterval = intervals + n + 1
                    });
                }
            }

            intervals++;
        }

        return intervals;
    }

    private record ScheduledTask
    {
        public required int TaskIndex;
        public required int RemainingCount;
        public required int NextInterval;
    }
}

