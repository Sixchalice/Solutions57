import matplotlib.pyplot as plt
from scipy.stats import pearsonr as pearsonr


print("Input numbers: (-1 to stop)")
num: float = float(input())
lst: list = list()
pos_counter: int = 0
n_sum: int = 0
while num != -1:
    if num > 0:
        pos_counter += 1
    lst.append(num)
    n_sum += num
    num = float(input())

avg: float = n_sum / len(lst)
print("Average: ", avg)
print("Amount of positives: ", pos_counter)

sorted_list: list = sorted(lst)
print("Sorted list: ", sorted_list)

x_list: list = [x for x in range(1, len(lst) + 1)]
plt.plot(x_list, lst, 'or')
plt.ylabel('Number')
plt.xlabel('Order')
plt.grid()
r = pearsonr(x_list, lst)
print("Pearson correlation coefficient: ", r.statistic)

plt.show()
