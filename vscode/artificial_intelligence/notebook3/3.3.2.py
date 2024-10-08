from sklearn.feature_extraction import DictVectorizer
data_dict = [{"карий": 1,
              "зеленый": 2},
             {"голубой": 4,
              "серый": 2, },
             {"голубой": 4,
              "зеленый": 2},
            {
                "фиолетовый": 1,
                "желтый": 3
            }]
vector = DictVectorizer(sparse=False)
features = vector.fit_transform(data_dict)
print(features)