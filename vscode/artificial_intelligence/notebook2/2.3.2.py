import pandas as pd

url = 'https://raw.githubusercontent.com/akmand/datasets/main/airlines.csv'
df = pd.read_csv(url)

print(df)
