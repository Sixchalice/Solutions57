def is_sorted_polyndrom(sqc: str):
    rev_sqc = sqc[::-1]
    mid_index = len(sqc) // 2 + 1
    if sqc != rev_sqc:
        return False

    for i in range(1, mid_index):
        if sqc[i] < sqc[i - 1]:
            return False
    return True


print(is_sorted_polyndrom("abcdzdcba"))
