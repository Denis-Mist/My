import matplotlib.pyplot as plt
from mpl_toolkits.mplot3d import Axes3D
import math

def calculate_distance(point1, point2):
    x1, y1, z1 = point1
    x2, y2, z2 = point2
    return math.sqrt((x1 - x2)**2 + (y1 - y2)**2 + (z1 - z2)**2)

fig = plt.figure()
ax = fig.add_subplot(111, projection='3d')

points = [(1, 2, 3), (4, 5, 6), (7, 8, 9), (10, 11, 12)]
labels = ['A', 'B', 'C', 'D']

for point, label in zip(points, labels):
    ax.scatter(point[0], point[1], point[2], label=label)

ax.set_xlabel('X')
ax.set_ylabel('Y')
ax.set_zlabel('Z')

distances = {}
for i in range(len(points)):
    for j in range(i+1, len(points)):
        point1 = points[i]
        point2 = points[j]
        distance = calculate_distance(point1, point2)
        distances[f"{labels[i]}-{labels[j]}"] = distance

print("Distances between points:")
for key, value in distances.items():
    print(f"{key}: {value:.2f}")

plt.legend()
plt.show()