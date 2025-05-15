# SayyehBanTools 🌟

## Description
SayyehBanTools is a powerful extension to enhance this package. You can also contribute to improving this package and make it stronger together.

## Installation
To install SayyehBanTools, follow these steps:

1. Clone the repository:
```
git clone https://github.com/SayyehBan/SayyehBanTools.git
```
2. Build the project in your preferred IDE.
3. Reference the SayyehBanTools assembly in your project.

## Usage
Here are some examples of how to use the SayyehBanTools library:

**Mathematical Calculations**

```csharp
// Getting numbers for calculations
double[] numbers = { 2.6, 7, 8, 9 };

// Creating an instance of the Calculator class
Calculator calculator = new Calculator();

// Performing multiplication operation
double resultMultiply = calculator.Multiply(numbers);

// Performing addition operation
double resultAdd = calculator.Add(numbers);

// Performing subtraction operation
double resultSubtract = calculator.Subtract(numbers);

// Performing division operation
double resultDivide = calculator.Divide(numbers);

// Performing discount percentage operation
decimal resultDiscount = calculator.Discount(200000, 20);

// Performing taxation percentage operation
decimal resultTaxation = calculator.Taxation(500000, 9);
```

**Converting numbers into words for displaying amounts**

```csharp
long moneyNumber = 15451225858;

// Convert the number to words based on Iranian currency
string moneyRaghamToHorof = ConvertNumbertToString.ConvertRaghamToHorof(moneyNumber);

// Splitting the decimal numbers
string moneyRaghamToJodaJoda = ConvertNumbertToString.ConvertRaghamToJodaJoda(moneyNumber);

// Convert the number to words based on Iranian currency
string moneyNumToString = ConvertNumToString.convert(moneyNumber.ToString());
```

**StringExtensions Usage**

The usage of StringExtensions subset:

1. `StringExtensions.HasValue`: Check if a value exists or not
2. `StringExtensions.ToInt`: Convert to Int
3. `StringExtensions.ToDecimal`: Convert to Decimal
4. `StringExtensions.ToNumeric`: Get the int/decimal value and display it with split decimal numbers
5. `StringExtensions.ToCurrency`: Get the int/decimal value and display it as currency
6. `StringExtensions.En2Fa`: Replace Persian numbers with English ones
7. `StringExtensions.Fa2En`: Replace English numbers with Persian ones
8. `StringExtensions.FixPersianChars`: Replace Persian characters with non-Iranian ones
9. `StringExtensions.RemovePoint`: Remove the decimal point or comma from the numbers
10. `StringExtensions.CleanString`: Perform several cleaning operations together
11. `StringExtensions.NullIfEmpty`: Take care of empty values and send Null instead of an empty value
12. `StringExtensions.HtmlTags`: Remove HTML tags from descriptions
13. `StringExtensions.ASCII`: Remove operation characters

## API
The SayyehBanTools library provides the following main components:

- `Calculator` class for performing mathematical operations
- `ConvertNumbertToString` and `ConvertNumToString` classes for converting numbers to words
- `StringExtensions` class for various string manipulation operations

## Contributing
We welcome contributions to the SayyehBanTools project. If you would like to contribute, please follow these steps:

1. Fork the repository.
2. Create a new branch for your feature or bug fix.
3. Implement your changes and add tests if applicable.
4. Submit a pull request with a detailed description of your changes.

## License
SayyehBanTools is licensed under the [MIT License](LICENSE).

## Testing
To run the tests for the SayyehBanTools library, follow these steps:

1. Ensure you have the necessary testing frameworks installed in your development environment.
2. Navigate to the test project directory.
3. Run the test suite using your preferred testing tool or command-line interface.