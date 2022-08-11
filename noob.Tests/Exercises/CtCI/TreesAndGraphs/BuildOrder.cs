using noob.Models.Graphs.Directed;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace noob.UnitTests.Exercises.TreesAndGraphs;

/// <summary>
/// You are given a list of projects and a list of dependencies (which is a list of pairs of
/// projects, where the second project is dependent on the first project). All of a project's dependencies
/// must be built before the project is. Find a build order that will allow the projects to be built.If there
/// is no valid build order, return an error.
/// </summary>
public class BuildOrder
{
    public static IEnumerable<object[]> PossibleBuildOrders() => new List<object[]>
    {
        new object[]
        {
            new []{ 'a', 'b', 'c', 'd', 'e', 'f' },
            new []{ ('a', 'd'), ('f', 'b'), ('b', 'd'), ('f', 'a'), ('d', 'c') },
        }
    };

    [Theory]
    [MemberData(nameof(PossibleBuildOrders))]
    public void WhenDeterminingPossibleBuildOrders_ThenDependenciesAreResolvedProperly(char[] projects, (char, char)[] dependencies)
    {
        // Act
        var buildOrder = GenerateBuildOrderFromDependencies(projects, dependencies);

        // Assert
        Assert.Equal(buildOrder?.Length, projects.Length);
        for (int i = 0; i < buildOrder?.Length; i++)
        {
            var project = buildOrder[i];
            var builtProjects = buildOrder[..i];
            var unmetDependencies = dependencies.Where(x => x.Item1 == project && !builtProjects.Contains(x.Item2)).ToList();
            Assert.Empty(unmetDependencies);
        }
    }

    [Fact]
    public void WhenProvidedACyclicDependency_ThenAnExceptionIsThrown()
    {
        // Arrange
        var projects = new[] { 'a', 'b', 'c', 'd', 'e', 'f' };
        // cyclic dependency: a <-> d
        var dependencies = new[] { ('a', 'd'), ('f', 'b'), ('b', 'd'), ('f', 'a'), ('d', 'a') };

        // Assert
        var ex = Assert.Throws<Exception>(() => GenerateBuildOrderFromDependencies(projects, dependencies));
        Assert.Equal("Circular dependency detected: (d, a)", ex.Message);
    }

    [Fact]
    public void WhenUnableToDetermineBuildOrder_ThenAnExceptionIsThrown()
    {
        // Arrange
        var projects = new[] { 'a', 'b', 'c', 'd', 'e', 'f' };
        // cyclic dependency: a -> d -> b -> a
        var dependencies = new[] { ('a', 'd'), ('d', 'b'), ('b', 'a'), ('f', 'a'), ('d', 'c') };

        // Assert
        var ex = Assert.Throws<Exception>(() => GenerateBuildOrderFromDependencies(projects, dependencies));
        Assert.Equal("A build order couldn't be determined. Check your dependencies to ensure there are no circular references", ex.Message);
    }

    private static char[]? GenerateBuildOrderFromDependencies(char[] projects, (char, char)[] dependencies)
    {
        var dependencyGraph = CreateDependencyGraph(dependencies);
        var buildOrder = CreateBuildOrder(projects, dependencyGraph);

        return buildOrder.ToArray();
    }

    private static DirectedGraph<char, string> CreateDependencyGraph((char, char)[] dependencies)
    {
        var dependencyGraph = new DirectedGraph<char, string>();
        foreach (var dependency in dependencies)
        {
            if (dependencyGraph.TryGetEdge(dependency.Item2, dependency.Item1, out string _))
            {
                throw new Exception($"Circular dependency detected: {dependency}");
            }
            dependencyGraph.AddEdge(dependency.Item1, dependency.Item2, dependency.ToString());
        }

        return dependencyGraph;
    }

    private static IEnumerable<char> CreateBuildOrder(char[] projects, DirectedGraph<char, string> dependencyGraph, int maxAttempts = 10)
    {
        var buildOrder = new List<char>();
        var projectsToAdd = projects.ToList();

        var index = 0;
        var attemptIndex = 1;

        while (buildOrder.Count != projects.Length)
        {
            var project = projectsToAdd[index];
            var projectDependencies = dependencyGraph.OutgoingEdges().Where(x => x.Source == project);

            // If there are no dependencies, we can add the project to the build order
            if (!projectDependencies.Any())
            {
                buildOrder.Add(project);
                projectsToAdd.Remove(project);
            }

            // If build order contains all project dependencies
            else if (projectDependencies.All(x => buildOrder.Contains(x.Destination)))
            {
                buildOrder.Add(project);
                projectsToAdd.Remove(project);
            }

            if (index + 1 >= projectsToAdd.Count)
            {
                index = 0;
                attemptIndex++;

                // This may not be the best way to determine this
                if(attemptIndex > maxAttempts)
                {
                    throw new Exception("A build order couldn't be determined. Check your dependencies to ensure there are no circular references");
                }
            }
            else
            {
                index++;
            }
        }

        return buildOrder;
    }
}
