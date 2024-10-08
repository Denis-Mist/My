import numpy as np
import matplotlib.pyplot as plt

def function(x):
    return (np.sqrt(1+np.exp(np.sqrt(x))+np.cos(x)**2)) / np.abs(1-np.sin(x)**3) + np.log(np.abs(2*x))

arr = range(1,11)
arr = arr[:len(arr)//2]
arr2 = []
for i in arr:
    arr2.append(function(i))
print(list(arr))

plt.xlabel("Num of value")
plt.ylabel("Value")
plt.scatter(arr,arr2)