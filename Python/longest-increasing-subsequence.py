# https://www.hackerrank.com/challenges/longest-increasing-subsequent

def read_input():
    in_array = []
    no_of_test_lines = int(input())
    for i in range(no_of_test_lines):
        in_array.append(int(input()))
    return in_array


def solve(arr):
    if len(arr) == 0:
        return 0
    solution = []
    for i in range(len(arr)):
        solution.append(1)
        for j in range(i-1, -1, -1):
            if arr[i] > arr[j]:
                if solution[j] + 1 > solution[i]:
                    solution[i] = solution[j] + 1
    return max(solution)


def run():
    test_case = read_input()
    print(solve(test_case))

run()