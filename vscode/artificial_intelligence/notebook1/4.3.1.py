import numpy as np
import matplotlib.pyplot as plt
import random

x = range(1,41)

random_numbers = [random.random() for _ in range(40)]

sr_zn = np.mean(random_numbers)
mediana = np.mean(random_numbers)

print(random_numbers)
print("sr_zn: ",sr_zn)
print("mediana: ", mediana)
plt.xlabel("Num of value")
plt.ylabel("Value")
plt.scatter(x,random_numbers)
