import numpy as np

matrix = np.zeros((8, 8))

for i in range(8):
    for j in range(8):
        if (i + j) % 2 == 0:
            matrix[i, j] = 1

print(matrix)