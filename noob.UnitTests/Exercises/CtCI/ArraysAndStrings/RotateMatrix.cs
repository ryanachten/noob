using Xunit;

namespace noob.UnitTests.Exercises.ArraysAndStrings;

/// <summary>
/// Given an image represented by an NxN matrix, where each pixel in the image is 4
/// bytes, write a method to rotate the image by 90 degrees. Can you do this in place
/// </summary>
public class RotateMatrix
{
    private readonly byte[][] _image = new byte[][] {
            new byte[] { 01, 02, 03, 04 },
            new byte[] { 05, 06, 07, 08 },
            new byte[] { 09, 10, 11, 12 },
            new byte[] { 13, 14, 15, 16 },
        };

    private readonly byte[][] _expectedResult = new byte[][] {
            new byte[] { 13, 09, 05, 01 },
            new byte[] { 14, 10, 06, 02 },
            new byte[] { 15, 11, 07, 03 },
            new byte[] { 16, 12, 08, 04 },
        };

    [Fact]
    public void WhenRotatingAnImage_ThenImageIsRotated90Degrees()
    {
        // Arrange
        var rotatedImage = new byte[][]
        {
            new byte[_image.Length],
            new byte[_image.Length],
            new byte[_image.Length],
            new byte[_image.Length]
        };

        // Act
        // Assumption: when rotating 90 deg, the first row becomes the first column in the rotated array
        for (int y = 0; y < _image.Length; y++)
        {
            for (int x = 0; x < _image[y].Length; x++)
            {
                rotatedImage[x][_image[y].Length - 1 - y] = _image[y][x];
            }
        }

        // Assert
        Assert.Equal(_expectedResult, rotatedImage);
    }

    [Fact]
    public void WhenRotatingAnImageInPlace_ThenImageIsRotated90Degrees()
    {
        // Arrange
        var image = _image;

        // Act
        // 1 - Reverse columns
        for (int y = 0; y < image.Length; y++)
        {
            for (int x = 0, xEnd = image.Length - 1; x < xEnd; x++, xEnd--)
            {
                // Swap the current cell with the current cell at the end
                (image[xEnd][y], image[x][y]) = (image[x][y], image[xEnd][y]);
            }
        }

        // 2- Transpose matrix
        for (int y = 0; y < image.Length; y++)
        {
            for (int x = y; x < image.Length; x++)
            {
                // Swap cells diagonally
                (image[y][x], image[x][y]) = (image[x][y], image[y][x]);
            }
        }

        // Note: this is a clockwise rotation; to do an anti-clockwise rotation
        // transpose and then reverse columns

        // Assert
        Assert.Equal(_expectedResult, image);
    }
}
