def pythagorean_triplet_by_sum(sum: int):
    if sum % 2 == 0:  # Sum can't be odd
        for a in range(1, int(sum / 2)):
            for b in range(a + 1, sum):
                c = sum - a - b
                if a * a + b * b == c * c:
                    print(a, b, c)


pythagorean_triplet_by_sum(24)
