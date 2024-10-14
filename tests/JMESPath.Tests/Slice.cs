// <auto-generated /> 
#nullable enable

using JMESPath;

public class Slice
{

    [Theory]
    [InlineData(
"""
bar[0:10]
""",
"""

""")]
    [InlineData(
"""
foo[0:10:1]
""",
"""
[
  0,
  1,
  2,
  3,
  4,
  5,
  6,
  7,
  8,
  9
]
""")]
    [InlineData(
"""
foo[0:10]
""",
"""
[
  0,
  1,
  2,
  3,
  4,
  5,
  6,
  7,
  8,
  9
]
""")]
    [InlineData(
"""
foo[0:10:]
""",
"""
[
  0,
  1,
  2,
  3,
  4,
  5,
  6,
  7,
  8,
  9
]
""")]
    [InlineData(
"""
foo[0::1]
""",
"""
[
  0,
  1,
  2,
  3,
  4,
  5,
  6,
  7,
  8,
  9
]
""")]
    [InlineData(
"""
foo[0::]
""",
"""
[
  0,
  1,
  2,
  3,
  4,
  5,
  6,
  7,
  8,
  9
]
""")]
    [InlineData(
"""
foo[0:]
""",
"""
[
  0,
  1,
  2,
  3,
  4,
  5,
  6,
  7,
  8,
  9
]
""")]
    [InlineData(
"""
foo[:10:1]
""",
"""
[
  0,
  1,
  2,
  3,
  4,
  5,
  6,
  7,
  8,
  9
]
""")]
    [InlineData(
"""
foo[::1]
""",
"""
[
  0,
  1,
  2,
  3,
  4,
  5,
  6,
  7,
  8,
  9
]
""")]
    [InlineData(
"""
foo[:10:]
""",
"""
[
  0,
  1,
  2,
  3,
  4,
  5,
  6,
  7,
  8,
  9
]
""")]
    [InlineData(
"""
foo[::]
""",
"""
[
  0,
  1,
  2,
  3,
  4,
  5,
  6,
  7,
  8,
  9
]
""")]
    [InlineData(
"""
foo[:]
""",
"""
[
  0,
  1,
  2,
  3,
  4,
  5,
  6,
  7,
  8,
  9
]
""")]
    [InlineData(
"""
foo[1:9]
""",
"""
[
  1,
  2,
  3,
  4,
  5,
  6,
  7,
  8
]
""")]
    [InlineData(
"""
foo[0:10:2]
""",
"""
[
  0,
  2,
  4,
  6,
  8
]
""")]
    [InlineData(
"""
foo[5:]
""",
"""
[
  5,
  6,
  7,
  8,
  9
]
""")]
    [InlineData(
"""
foo[5::2]
""",
"""
[
  5,
  7,
  9
]
""")]
    [InlineData(
"""
foo[::2]
""",
"""
[
  0,
  2,
  4,
  6,
  8
]
""")]
    [InlineData(
"""
foo[::-1]
""",
"""
[
  9,
  8,
  7,
  6,
  5,
  4,
  3,
  2,
  1,
  0
]
""")]
    [InlineData(
"""
foo[1::2]
""",
"""
[
  1,
  3,
  5,
  7,
  9
]
""")]
    [InlineData(
"""
foo[10:0:-1]
""",
"""
[
  9,
  8,
  7,
  6,
  5,
  4,
  3,
  2,
  1
]
""")]
    [InlineData(
"""
foo[10:5:-1]
""",
"""
[
  9,
  8,
  7,
  6
]
""")]
    [InlineData(
"""
foo[8:2:-2]
""",
"""
[
  8,
  6,
  4
]
""")]
    [InlineData(
"""
foo[0:20]
""",
"""
[
  0,
  1,
  2,
  3,
  4,
  5,
  6,
  7,
  8,
  9
]
""")]
    [InlineData(
"""
foo[10:-20:-1]
""",
"""
[
  9,
  8,
  7,
  6,
  5,
  4,
  3,
  2,
  1,
  0
]
""")]
    [InlineData(
"""
foo[10:-20]
""",
"""
[]
""")]
    [InlineData(
"""
foo[-4:-1]
""",
"""
[
  6,
  7,
  8
]
""")]
    [InlineData(
"""
foo[:-5:-1]
""",
"""
[
  9,
  8,
  7,
  6
]
""")]
    [InlineData(
"""
foo[8:2:0]
""",
"""

""")]
    [InlineData(
"""
foo[8:2:0:1]
""",
"""

""")]
    [InlineData(
"""
foo[8:2&]
""",
"""

""")]
    [InlineData(
"""
foo[2:a:3]
""",
"""

""")]
    public void Test_1(string expression, string expectedResult)
    {
        // Arrange 
        string? given =
"""
{
  "foo": [
    0,
    1,
    2,
    3,
    4,
    5,
    6,
    7,
    8,
    9
  ],
  "bar": {
    "baz": 1
  }
}
""";

        // Act 
        string? result = JMESPathSearcher.Search(expression, given);
        
        // Assert
        Assert.Equal(result, expectedResult);
    }

    [Theory]
    [InlineData(
"""
foo[:2].a
""",
"""
[
  1,
  2
]
""")]
    [InlineData(
"""
foo[:2].b
""",
"""
[]
""")]
    [InlineData(
"""
foo[:2].a.b
""",
"""
[]
""")]
    [InlineData(
"""
bar[::-1].a.b
""",
"""
[
  3,
  2,
  1
]
""")]
    [InlineData(
"""
bar[:2].a.b
""",
"""
[
  1,
  2
]
""")]
    [InlineData(
"""
baz[:2].a
""",
"""

""")]
    public void Test_2(string expression, string expectedResult)
    {
        // Arrange 
        string? given =
"""
{
  "foo": [
    {
      "a": 1
    },
    {
      "a": 2
    },
    {
      "a": 3
    }
  ],
  "bar": [
    {
      "a": {
        "b": 1
      }
    },
    {
      "a": {
        "b": 2
      }
    },
    {
      "a": {
        "b": 3
      }
    }
  ],
  "baz": 50
}
""";

        // Act 
        string? result = JMESPathSearcher.Search(expression, given);
        
        // Assert
        Assert.Equal(result, expectedResult);
    }

    [Theory]
    [InlineData(
"""
[:]
""",
"""
[
  {
    "a": 1
  },
  {
    "a": 2
  },
  {
    "a": 3
  }
]
""")]
    [InlineData(
"""
[:2].a
""",
"""
[
  1,
  2
]
""")]
    [InlineData(
"""
[::-1].a
""",
"""
[
  3,
  2,
  1
]
""")]
    [InlineData(
"""
[:2].b
""",
"""
[]
""")]
    public void Test_3(string expression, string expectedResult)
    {
        // Arrange 
        string? given =
"""
[
  {
    "a": 1
  },
  {
    "a": 2
  },
  {
    "a": 3
  }
]
""";

        // Act 
        string? result = JMESPathSearcher.Search(expression, given);
        
        // Assert
        Assert.Equal(result, expectedResult);
    }

}