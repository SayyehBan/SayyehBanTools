

    Mathematical Calculations

How to work with the Calculator Class and invoke the Calculator Class

نحوه کار با کلاس محاسبات و فراخوانی کلاس محاسبات

// برداشتن اعداد برای محاسبات

double[] numbers = { 2.6, 7, 8, 9 };

// ایجاد نمونه ای از کلاس محاسبات

Calculator calculator = new Calculator();

// انجام عملیات ضرب

double resultMultiply = calculator.Multiply(numbers);

// انجام عملیات جمع

double resultAdd = calculator.Add(numbers);

// انجام عملیات منفی

double resultSubtract = calculator.Subtract(numbers);

// انجام عملیات تقسیم

double resultDivide = calculator.Divide(numbers);

// انجام عملیات درصد تخفیف

decimal resultDiscount = calculator.Discount(200000, 20);

// انجام عملیات درصد مالیات

decimal resultTaxation = calculator.Taxation(500000, 9);

////////////////////////////////////////////////////////////////

// Getting numbers for calculations

double[] numbers = { 2.6, 7, 8, 9 };

// Creating an instance of the Calculator class

Calculator calculator = new Calculator();

// Performing multiplication operation double resultMultiply = calculator.Multiply(numbers);

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

    Converting numbers into words for displaying amounts

long moneyNumber = 15451225858;

// تبدیل عدد به حروف برحسب واحد پول ایران

string moneyRaghamToHorof = ConvertNumbertToString.ConvertRaghamToHorof(moneyNumber);

// دا کردن سه رقم اعشار اعداد

string moneyRaghamToJodaJoda = ConvertNumbertToString.ConvertRaghamToJodaJoda(moneyNumber);

// تبدیل عدد به حروف برحسب واحد پول ایران

string moneyNumToString = ConvertNumToString.convert(moneyNumber.ToString());

/*

کاربرد زیرمجموعه دستورها در StringExtensions: به ترتیب

StringExtensions.HasValue: بررسی اینکه آیا مقدار وجود داره یا خیر

StringExtensions.ToInt: تبدیل به Int

StringExtensions.ToDecimal: تبدیل به ToDecimal

StringExtensions.ToNumeric (int): دریافت مقدار int و نمایش آن به صورت سه رقم اعشار

StringExtensions.ToNumeric (decimal): دریافت مقدار decimal و نمایش آن به صورت سه رقم اعشار

StringExtensions.ToCurrency (int): دریافت مقدار int و نمایش آن به صورت ارزی

StringExtensions.ToCurrency (decimal): دریافت مقدار decimal و نمایش آن به صورت ارزی

StringExtensions.En2Fa: جایگزین عدد انگلیسی به جای عدد پارسی

StringExtensions.Fa2En: جایگزین عدد پارسی به جای عدد انگلیسی

StringExtensions.FixPersianChars: جایگزین حروف عربی و غیر ایرانی به جای حروف پارسی

StringExtensions.RemovePoint: حذف نقطه یا علامت اعشار از اعداد

StringExtensions.CleanString: انجام چندین عملیات پاکسازی با هم

StringExtensions.NullIfEmpty: جلوگیری از مقدار خالی و ارسال Null به جای مقدار خالی

StringExtensions.HtmlTags: حذف تگ‌های html از متن

StringExtensions.ASCII: حذف مقدار عملکر گردها از متن

*/

string stringExtensions = StringExtensions.CleanString("چطوری خوبی");

long moneyNumber = 15451225858;

// Convert the number to words based on Iranian currency

string moneyRaghamToHorof = ConvertNumbertToString.ConvertRaghamToHorof(moneyNumber);

// Splitting the decimal numbers

string moneyRaghamToJodaJoda = ConvertNumbertToString.ConvertRaghamToJodaJoda(moneyNumber);

// Convert the number to words based on Iranian currency

string moneyNumToString = ConvertNumToString.convert(moneyNumber.ToString());

/* The usage of StringExtensions subset

In order:

StringExtensions.HasValue: Check if a value exists or not

StringExtensions.ToInt: Convert to Int

StringExtensions.ToDecimal: Convert to Decimal

StringExtensions.ToNumeric: Get the int value and display it with split decimal numbers

StringExtensions.ToNumeric: Get the decimal value and display it with split decimal numbers

StringExtensions.ToCurrency: Get the int value and display it as currency

StringExtensions.ToCurrency: Get the decimal value and display it as currency

StringExtensions.En2Fa: Replace Persian numbers with English ones

StringExtensions.Fa2En: Replace English numbers with Persian ones

StringExtensions.FixPersianChars: Replace Persian characters with non-Iranian ones

StringExtensions.RemovePoint: Remove the decimal point or comma from the numbers

StringExtensions.CleanString: Perform several cleaning operations together

StringExtensions.NullIfEmpty: Take care of empty values and send Null instead of an empty value

StringExtensions.HtmlTags: Remove html tags from descriptions

StringExtensions.ASCII: Remove operation characters

*/

string stringExtensions = StringExtensions.CleanString("How are you");

    Analyzing Persian texts: converting non-Persian characters to Persian, converting English numbers into Persian, and vice versa, etc.
    Date operations: converting and calculating time
    Encoding and decoding encoded values
    Generating values, meaning generating numbers, etc.

