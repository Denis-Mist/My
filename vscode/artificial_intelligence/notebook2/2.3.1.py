import numpy as np
import pandas as pd

def euclidean_distance(a, b):
    diff = a - b
    diff_squared = diff ** 2
    sum_squared_diff = diff_squared.sum()
    return np.sqrt(sum_squared_diff)

a = pd.Series([1, 2, 3])
b = pd.Series([4, 5, 6])


distance = euclidean_distance(a, b)
print(distance)