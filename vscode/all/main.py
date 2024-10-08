import string
from collections import Counter
import math

def calculate_information_entropy(frequency_dict, total_symbols):
    probabilities = [count / total_symbols for count in frequency_dict.values()]
    information_entropy = -sum(p * math.log2(p) for p in probabilities if p > 0)
    return information_entropy

def calculate_code_length_and_redundancy(information_entropy, total_symbols):
    code_length = math.ceil(math.log2(total_symbols))
    redundancy = code_length - information_entropy
    return code_length, redundancy

def shannon_fano_coding(frequency_dict):
    sorted_frequency = sorted(frequency_dict.items(), key=lambda x: x[1], reverse=True)

    def recursive_split(symbols):
        if len(symbols) == 1:
            return {symbols[0][0]: ''}

        total_frequency = sum(freq for _, freq in symbols)
        cumulative_frequency = 0
        split_point = 0

        for i, (char, freq) in enumerate(symbols):
            cumulative_frequency += freq
            if cumulative_frequency >= total_frequency / 2:
                split_point = i + 1
                break

        left = symbols[:split_point]
        right = symbols[split_point:]

        left_code = recursive_split(left)
        right_code = recursive_split(right)

        for char in left_code:
            left_code[char] = '0' + left_code[char]
        for char in right_code:
            right_code[char] = '1' + right_code[char]

        return {**left_code, **right_code}

    return recursive_split(sorted_frequency)

def encode_text_with_code_table(text, code_table):
    return ''.join(code_table[char] for char in text)

def decode_text_with_code_table(encoded_text, code_table):
    reverse_code_table = {v: k for k, v in code_table.items()}
    current_code = ''
    decoded_text = ''

    for bit in encoded_text:
        current_code += bit
        if current_code in reverse_code_table:
            decoded_text += reverse_code_table[current_code]
            current_code = ''

    return decoded_text

def calculate_average_code_length(code_table, frequency_dict, total_symbols):
    return sum(len(code_table[char]) * freq / total_symbols for char, freq in frequency_dict.items())

input_text = "ААААААБББВСЕ"

single_symbol_frequency = Counter(input_text)
double_symbol_frequency = Counter(input_text[i:i+2] for i in range(0, len(input_text) - 1, 2))

single_symbol_information = calculate_information_entropy(single_symbol_frequency, sum(single_symbol_frequency.values()))
double_symbol_information = calculate_information_entropy(double_symbol_frequency, sum(double_symbol_frequency.values()))

print(f"Информация для одиночных символов: {single_symbol_information}")
print(f"Информация для пар символов: {double_symbol_information}")

total_single_symbols = len(single_symbol_frequency)
total_double_symbols = len(double_symbol_frequency)

single_symbol_code_length, single_symbol_redundancy = calculate_code_length_and_redundancy(single_symbol_information, total_single_symbols)
double_symbol_code_length, double_symbol_redundancy = calculate_code_length_and_redundancy(double_symbol_information, total_double_symbols)

print(f"Длина кода для одиночных символов: {single_symbol_code_length}")
print(f"Избыточность для одиночных символов: {single_symbol_redundancy}")
print(f"Длина кода для пар символов: {double_symbol_code_length}")
print(f"Избыточность для пар символов: {double_symbol_redundancy}")

single_symbol_code_table = shannon_fano_coding(single_symbol_frequency)
double_symbol_code_table = shannon_fano_coding(double_symbol_frequency)
print(f"\nТаблица кодов Шеннона-Фано для одиночных символов: {single_symbol_code_table}")
print(f"\nТаблица кодов Шеннона-Фано для пар символов: {double_symbol_code_table}")

encoded_single_symbol_text = encode_text_with_code_table(input_text, single_symbol_code_table)
encoded_double_symbol_text = encode_text_with_code_table([input_text[i:i+2] for i in range(0, len(input_text) - 1, 2)], double_symbol_code_table)
print(f"Закодированный текст (одиночные символы): {encoded_single_symbol_text}")
print(f"Закодированный текст (пары символов): {encoded_double_symbol_text}")

decoded_single_symbol_text = decode_text_with_code_table(encoded_single_symbol_text, single_symbol_code_table)
print(f"Декодированный текст (одиночные символы): {decoded_single_symbol_text}")