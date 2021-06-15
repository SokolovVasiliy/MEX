# MEX
MEX search algorithm (Minimum EXclude number) with difficulty O(n).
Chains of ordered numbers are constructed. The first missing number is defined as following the first chain.
### USAGE:
```
// mexN = 0
int mexN = Mex.FindMex(new int[] { 1, 2, 3 }); 
// mexN = 1
int mexN = Mex.FindMex(new int[] { 0, 2, 4, 6 });
// mexN = 2
int mexN = Mex.FindMex(new int[] { 0, 1, 4, 7, 12 });
// mexN = 2
int mexN = Mex.FindMex(new int[] { 0, 12, 4, 7, 1 });
// mexN = 4
int mexN = Mex.FindMex(new int[] { 0, 1, 2, 3 });
// mexN = 24
int mexN = Mex.FindMex(new int[] { 11, 10, 9, 8, 15, 14, 13, 12, 3, 2, 0, 7, 6, 5, 27, 26, 25, 4, 31, 30, 28, 19, 18, 17, 16, 23, 22, 21, 20, 43, 1, 40, 47, 46, 45, 44, 35, 33, 32, 39, 38, 37, 36, 58, 57, 56, 63, 62, 60, 51, 49, 48, 55, 53, 52, 75, 73, 72, 79, 77, 67, 66, 65, 71, 70, 68, 90, 89, 88, 95, 94, 93, 92, 83, 82, 81, 80, 87, 86, 84, 107, 106, 104 });
```
