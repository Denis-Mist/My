import numpy as np

def calculator():
    print("1. Addition")
    print("2. Subtraction")
    print("3. Multiplication")
    print("4. Division")
    print("5. e^(x+y)")
    print("6. sin(x+y)")
    print("7. cos(x+y)")
    print("8. x^y")

    choice = int(input("Enter your choice (1-8): "))

    x = float(input("Enter the first number: "))
    y = float(input("Enter the second number: "))

    if choice == 1:
        result = np.add(x, y)
        print("Result: ", result)
    elif choice == 2:
        result = np.subtract(x, y)
        print("Result: ", result)
    elif choice == 3:
        result = np.multiply(x, y)
        print("Result: ", result)
    elif choice == 4:
        if y != 0:
            result = np.divide(x, y)
            print("Result: ", result)
        else:
            print("Error: Division by zero is not allowed")
    elif choice == 5:
        result = np.exp(x + y)
        print("Result: ", result)
    elif choice == 6:
        result = np.sin(x + y)
        print("Result: ", result)
    elif choice == 7:
        result = np.cos(x + y)
        print("Result: ", result)
    elif choice == 8:
        result = np.power(x, y)
        print("Result: ", result)
    else:
        print("Invalid choice")

calculator()