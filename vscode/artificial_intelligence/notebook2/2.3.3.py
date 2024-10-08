import pandas as pd

url = 'https://raw.githubusercontent.com/akmand/datasets/main/airlines.csv'
df = pd.read_csv(url)

print(df.head(2))
print(df.tail(3))
print(df.shape)
print(df.describe())
print(df.iloc[1:4])
print(df[df['Airline'] == 'US'].head(2))
