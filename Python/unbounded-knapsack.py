# https://www.hackerrank.com/challenges/unbounded-knapsack

def readInput():
    in_array = []
    no_of_test_cases = int(input())
    for i in range(no_of_test_cases):
        target = int(input().split()[1])  # get expected sum
        in_array.append((target, set(map(lambda x: int(x), input().split()))))
    return in_array

def solve(test_case):
    expectedSum = test_case[0]
    values = test_case[1]
    solution = [0]
    for i in range(expectedSum+1):
        if i in values:
            solution.append(i)
        else:
            for j in range(len(solution) - 1, -1, -1):
                if i - solution[j] in values:
                    solution.append(i)
                    break
    return max(solution)

def run():
    test_cases = readInput()
    for testCase in test_cases:
        print(solve(testCase))

run()