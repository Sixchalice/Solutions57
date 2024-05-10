from mpmath import mp


def reverse_n_pi_digits(n: int) -> str:
    mp.dps = n + 1
    # n + 1 so pi isn't rounded
    spi: str = format(mp.pi)
    return (spi[0:n + 1])[::-1]


print(reverse_n_pi_digits(5))
