from math import log2, ceil

with open('C:/Users/Денис/Desktop/vscode/discr/input.txt') as file:
    input_string = file.read()

# Initialize dictionaries to store single and double character combinations
single_char_combinations = {}
double_char_combinations = {}

# Count the frequency of each single and double character combination
for index, char in enumerate(input_string):
    single_char_combinations.setdefault(char, 0)
    single_char_combinations[char] += 1

    if index != len(input_string) - 1:
        double_char_combinations.setdefault(char + input_string[index + 1], 0)
        double_char_combinations[char + input_string[index + 1]] += 1
    else:
        double_char_combinations.setdefault(char + input_string[0], 0)
        double_char_combinations[char + input_string[0]] += 1

# Calculate the frequency of each single and double character combination
single_char_frequencies = {}
double_char_frequencies = {}

for key, value in single_char_combinations.items():
    single_char_frequencies[key] = value / len(input_string)

for key, value in double_char_combinations.items():
    double_char_frequencies[key] = value / len(input_string)

sorted_single_char_frequencies = {}
sorted_double_char_frequencies = {}

for key in sorted(single_char_frequencies, key=single_char_frequencies.get, reverse=True):
    sorted_single_char_frequencies[key] = single_char_frequencies[key]

for key in sorted(double_char_frequencies, key=double_char_frequencies.get, reverse=True):
    sorted_double_char_frequencies[key] = double_char_frequencies[key]

print(sorted_single_char_frequencies)
print(sorted_double_char_frequencies, "\n")

# Calculate entropy
entropy_single = 0
for frequency in sorted_single_char_frequencies.values():
    entropy_single -= frequency * log2(frequency)

entropy_double = 0
for frequency in sorted_double_char_frequencies.values():
    entropy_double -= frequency * log2(frequency)

print(f"Entropy per single character: {round(entropy_single, 3)}")
print(f"Entropy per double character: {round(entropy_double, 3)}\n")

code_length_single = log2(len(sorted_single_char_frequencies))
print(f"Code length for uniform single character coding: {ceil(code_length_single)}")

redundancy_single = 1 - entropy_single / code_length_single
print(f"Redundancy for uniform single character coding: {round(redundancy_single, 3)}\n")


class CharacterNode:
    code = ""
    left_child = None
    right_child = None

    def __init__(self, frequency, char=""):
        self.char = char
        self.frequency = frequency

    def set_children(self, left_child, right_child):
        self.left_child = left_child
        self.right_child = right_child


def create_tree(list_of_characters):
    characters = []
    for char, frequency in list_of_characters:
        characters.append(CharacterNode(frequency, char))

    while len(characters) != 1:
        char_2 = characters.pop()
        char_1 = characters.pop()

        characters.append(CharacterNode(char_1.frequency + char_2.frequency))
        characters[-1].set_children(char_1, char_2)
        characters.sort(key=lambda char: char.frequency, reverse=True)

    return characters


def set_codes(character_node, symbol=""):
    if character_node.char != "":
        character_node.code = symbol
        return
    else:
        set_codes(character_node.left_child, symbol + "0")
        set_codes(character_node.right_child, symbol + "1")


# Huffman coding for single character combinations
cipher_single = {}
def fill_cipher_dict_single(character_node):
    if character_node.char != "":
        cipher_single[character_node.char] = character_node.code
    else:
        fill_cipher_dict_single(character_node.left_child)
        fill_cipher_dict_single(character_node.right_child)


tree_single = create_tree(list(sorted_single_char_frequencies.items()))

set_codes(tree_single[0])
fill_cipher_dict_single(tree_single[0])
print(cipher_single)

average_code_length_single = 0
for char, frequency in sorted_single_char_frequencies.items():
    average_code_length_single += frequency * len(cipher_single[char])

print(f"Average code length for single character: {round(average_code_length_single, 2)}")
print(f"Compression efficiency for single character: {round(entropy_single / average_code_length_single, 2)}\n")

# Huffman coding for double character combinations
cipher_double = {}
def fill_cipher_dict_double(character_node):
    if character_node.char != "":
        cipher_double[character_node.char] = character_node.code
    else:
        fill_cipher_dict_double(character_node.left_child)
        fill_cipher_dict_double(character_node.right_child)


tree_double = create_tree(list(sorted_double_char_frequencies.items()))

set_codes(tree_double[0])
fill_cipher_dict_double(tree_double[0])
print(cipher_double)

average_code_length_double = 0
for char, frequency in sorted_double_char_frequencies.items():
    average_code_length_double += frequency * len(cipher_double[char])

print(f"Average code length for double character: {round(average_code_length_double, 2)}")
print(f"Compression efficiency for double character: {round(entropy_double / average_code_length_double, 2)}\n")


def write_to_file(text, cipher):
    encoded_text = ""
    decoded_text = ""

    key = ""
    for char in text:
        key += char
        if key in cipher:
            encoded_text += cipher[key]
            key = ""

    current_code = ""
    for el in encoded_text:
        current_code += el
        for char, code in cipher.items():
            if code == current_code:
                decoded_text += char
                current_code = ""
                break

    with open("output.txt", "a") as file:
        file.write(text + "\n")
        file.write(encoded_text + "\n")
        file.write(decoded_text + "\n\n")

    return encoded_text


def decode_single(encoded_text, cipher):
    decoded_text = ""
    current_code = ""
    for el in encoded_text:
        current_code += el
        for char, code in cipher.items():
            if code == current_code:
                decoded_text += char
                current_code = ""
                break
    return decoded_text


encoded_text_single = write_to_file(input_string, cipher_single)
decoded_text_single = decode_single(encoded_text_single, cipher_single)
print(f"Decoded text for single character: {decoded_text_single}")
























# encoded_text_double = write_to_file(input_string, cipher_double)
# decoded_text_double = decode_single(encoded_text_double, cipher_double)
# print(f"Decoded text for double character: {decoded_text_double}")