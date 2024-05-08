import math


def num_len(num: int) -> int:
    return int(math.log(num, 10)) + 1


print(num_len(123653))
