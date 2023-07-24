# ResDiaryCodingChallenge
Single method for subdividing a list. Created as a coding assessment for ResDiary

## How to run
First, clone the repo into a local directory. Ensure you have dotnet installed and added to your PATH

To run the Utils project, which will show an example running of the Subvidide method, open a terminal and run
```dotnet run --project Utils```

To run the tests for the Subdivide, run the command
```dotnet test```

## Design Notes
- Should the function only operate on arrays or lists as well? What form should result be returned in?
  - It was decided that the method should accept any Enumerable, and use a generic Type parameter, in order to be kept generic and re-usable
  - It was considered that the result could be returned as a 2D array, rather than as lists, as it is much more efficient in terms of memory usage. However, this was decided against as using Lists allowed for a more readable LINQ-style solution, and it was assumed that efficiency was not the priority
- How does Subdivide work?
  - Using LINQ-style expressions, it performs the following steps:
    - Maps the elements so that each one is paired with its index, as this would be needed for grouping them
    - Groups each element by `index / subarraySize`, causing them to bunch into groups of the appropriate size
    - Map the groups, discarding the index for each element in each group, and converting the groups into Lists
    - Collapsing the result into a List
- For the tests, should Constraint-style or classic-style assertions be used?
  - Constraint-style assertions were considered because they are recommended as a warning by the compiler. However, in this situation they do not provide any more detailed messages on test-failure, and I personally find classic style more readable. In a real environment, this should be something decided on by the team together.
