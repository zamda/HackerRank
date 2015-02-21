# https://www.hackerrank.com/challenges/maxsubarray

def readInput():
    in_array = []
    no_of_test_cases = int(input())
    for i in range(no_of_test_cases):
        input() # skip
        in_array.append(list(map(lambda x: int(x), input().split())))
    return in_array


def solve_cont(arr):
    mem = []
    mem.append(arr[0])
    for i in range(1, len(arr)):
        mem.append(mem[i-1] + arr[i])
    return max(mem)

def solve_non_cont(arr):
    sum = 0
    are_all_negatives = True
    for i in arr:
        if i > 0:
            sum = sum + i
            are_all_negatives = False
    if are_all_negatives:
        sum = max(arr)
    return sum

def run():
    test_cases = readInput()
    for testCase in test_cases:
        output1 = solve_cont(testCase)
        output2 = solve_non_cont(testCase)
        print(output1, output2)

run()