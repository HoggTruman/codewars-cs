// https://www.codewars.com/kata/53921994d8f00b93df000bea

namespace WeightOfItsContents;

public static class SolutionClass
{
    public static int ContentWeight(int bottleWeight, string scaleString)
    {
        int scale = int.Parse(scaleString.Split()[0]);
        bool hasLargerContents = scaleString[^6..] == "larger";

        return hasLargerContents? 
            bottleWeight / (scale + 1) * scale:
            bottleWeight / (scale + 1);
    }
}
