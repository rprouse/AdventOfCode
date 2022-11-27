using System.Collections.Generic;

namespace AdventOfCode.Core.DecisionProblems;

/// <summary>
/// Find all subsets with given sum.
/// </summary>
/// <remarks>From https://www.geeksforgeeks.org/perfect-sum-problem-print-subsets-given-sum/</remarks>
public class SubSetSum
{
    // _dp[i][j] is going to store true if sum j is
    // possible with array elements from 0 to i.
    bool[,] _dp;
    List<int[]> _found = new List<int[]>();

    /// <summary>
    /// Finds all combinations of items in an array that add to sum
    /// </summary>
    /// <param name="arr">The array of possible values</param>
    /// <param name="sum">The target that we want to sum to</param>
    /// <returns>A list of all combinations of arr that add up to sum</returns>
    public List<int[]> FindAllSubsets(int[] arr, int sum)
    {
        int n = arr.Length;
        _found.Clear();

        if (n == 0 || sum < 0)
            return _found;

        // Sum 0 can always be achieved with 0 elements
        _dp = new bool[n, sum + 1];
        for (int i = 0; i < n; ++i)
        {
            _dp[i, 0] = true;
        }

        // Sum arr[0] can be achieved with single element
        if (arr[0] <= sum)
            _dp[0, arr[0]] = true;

        // Fill rest of the entries in _dp[][]
        for (int i = 1; i < n; ++i)
        {
            for (int j = 0; j < sum + 1; ++j)
            {
                if (arr[i] <= j)
                    _dp[i, j] = (_dp[i - 1, j] || _dp[i - 1, j - arr[i]]);
                else
                    _dp[i, j] = _dp[i - 1, j];
            }
        }

        if (_dp[n - 1, sum] == false)
        {
            return _found;
        }

        // Now recursively traverse _dp[][] to find all
        // paths from _dp[n-1][sum]
        List<int> candidates = new List<int>();
        FindSubsetsRec(arr, n - 1, sum, candidates);

        return _found;
    }

    // A recursive function to print all subsets with the
    // help of _dp[][]. candidates stores current subset.
    void FindSubsetsRec(int[] arr, int i, int sum, List<int> candidates)
    {
        // If we reached end and sum is non-zero. We print
        // candidates[] only if arr[0] is equal to sum OR _dp[0][sum]
        // is true.
        if (i == 0 && sum != 0 && _dp[0, sum])
        {
            candidates.Add(arr[i]);
            _found.Add(candidates.ToArray());
            candidates.Clear();
            return;
        }

        // If sum becomes 0
        if (i == 0 && sum == 0)
        {
            _found.Add(candidates.ToArray());
            candidates.Clear();
            return;
        }

        // If given sum can be achieved after ignoring
        // current element.
        if (_dp[i - 1, sum])
        {
            // Create a new list to store path
            List<int> newCandidates = new List<int>();
            newCandidates.AddRange(candidates);
            FindSubsetsRec(arr, i - 1, sum, newCandidates);
        }

        // If given sum can be achieved after considering
        // current element.
        if (sum >= arr[i] && _dp[i - 1, sum - arr[i]])
        {
            candidates.Add(arr[i]);
            FindSubsetsRec(arr, i - 1, sum - arr[i], candidates);
        }
    }
}
