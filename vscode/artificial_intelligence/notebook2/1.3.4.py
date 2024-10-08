import numpy as np

size = 5

matrix = np.ones((size, size))
matrix[1:-1, 1:-1] = 0

print(matrix)