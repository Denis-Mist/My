l = [i for i in range(10)]
l1 = []
l2 = []
l0 = []
for x in l:
    if x % 2 == 0:
        l2.append(x)
    else:
        l1.append(x)
l2 = l2[::-1]
for i in range(len(l1)):
    l0.append(l2[i])
    l0.append(l1[i])
print(l0)