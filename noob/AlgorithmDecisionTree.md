# noob - Data Structure Decision Tree

```mermaid
graph TD;
    start{What's the situation}

    %% SORTING
    start-->sort([Sorting data])
    -->isLargeDataSet{Is the dataset large?}-->|no|quickSort(Quick sort)
    isLargeDataSet-->|yes|mergeSort(Merge sort)

    %% SEARCHING
    start-->search([Searching data])
    -->sortedData{Is data sorted?}-->|yes|forPairs([Searching for pairs])-->twoPointer(Two pointer algorithm)

    sortedData-->|no|fixedWindow([Size of window is fixed])-->slidingWindow(Sliding window technique)

    %% GRAPH
    start-->graphTraversal([Graph traversal])
    -->dataShape{Is data deep or broad?}-->|deep|dfs(Depth-first search)
    dataShape-->|broad|bfs(Breadth-first search)

    %% GENERAL
    start-->general([General])
    general-->optimalSubstructure{Will best current choice lead to best outcome?}-->|yes|greedyAlgorithm(Greedy algorithm)
```
