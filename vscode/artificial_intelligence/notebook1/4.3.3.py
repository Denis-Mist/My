import numpy as np
from scipy.integrate import simps
import matplotlib.pyplot as plt

def f(x):
    return np.abs(np.cos(x * np.exp(np.cos(x) + np.log(x + 1))))


x = range(0,11)

y = [f(i) for i in x]

plt.plot(x, y)
plt.fill_between(x, 0, y, alpha=0.3)
plt.xlabel('x')
plt.ylabel('y')
plt.grid(True)
plt.show()

area = np.trapz(y, x)
print("The area underneath the curve is:", area)