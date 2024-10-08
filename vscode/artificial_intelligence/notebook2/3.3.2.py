import pandas as pd
from sklearn.preprocessing import MinMaxScaler, StandardScaler

url = "https://raw.githubusercontent.com/akmand/datasets/master/iris.csv"
df = pd.read_csv(url)

scaler = MinMaxScaler()
df['sepal_length_cm_scaled'] = scaler.fit_transform(df[['sepal_length_cm']])
print(df['sepal_length_cm_scaled'])

scaler = StandardScaler()
df['sepal_width_cm_scaled'] = scaler.fit_transform(df[['sepal_width_cm']])
print(df['sepal_width_cm_scaled'])