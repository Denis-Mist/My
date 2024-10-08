from matplotlib import pyplot as plt

dates = ["01.01", "01.02", "01.03", "01.04", "01.05", "01.06",
         "01.07", "01.08", "01.09", "01.10", "01.11", "01.12"]
apple_prices = [131.96, 121.26, 122.15, 131.46, 124.61, 136.96,
                145.86, 151.83, 141.5, 149.8, 165.3, 177.57]
google_prices = [91.78, 101.84, 103.43, 120.5, 120.57, 125.31,
                 135.22, 145.46, 133.26, 148.27, 142.45, 144.67]
microsoft_prices = [231.96, 232.38, 235.77, 252.17, 249.67, 270.89,
                    284.91, 301.88, 281.92, 331.61, 330.58, 336.32]
fig, graph = plt.subplots(nrows=1, ncols=3, figsize=(24, 8))
graph[0].grid()
graph[1].grid()
graph[2].grid()
graph[0].scatter(dates, apple_prices)
graph[0].set_title("Apple", fontsize=24)
graph[1].scatter(dates, google_prices)
graph[1].set_title("Google", fontsize=24)
graph[2].scatter(dates, microsoft_prices)
graph[2].set_title("Microsoft", fontsize=24)
plt.show()