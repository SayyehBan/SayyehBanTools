<html>
<head>
	<title></title>
</head>
<body>
<p><strong>Mathematical Calculations</strong></p>

<p>How to work with the Calculator Class and invoke the Calculator Class</p>

<p dir="rtl">نحوه کار با کلاس محاسبات و فراخوانی کلاس محاسبات</p>

<p>// برداشتن اعداد برای محاسبات</p>

<p>double[] numbers = { 2.6, 7, 8, 9 };</p>

<p>// ایجاد نمونه ای از کلاس محاسبات</p>

<p>Calculator calculator = new Calculator();</p>

<p>// انجام عملیات ضرب</p>

<p>double resultMultiply = calculator.Multiply(numbers);</p>

<p>// انجام عملیات جمع</p>

<p>double resultAdd = calculator.Add(numbers);</p>

<p>// انجام عملیات منفی</p>

<p>double resultSubtract = calculator.Subtract(numbers);</p>

<p>// انجام عملیات تقسیم</p>

<p>double resultDivide = calculator.Divide(numbers);</p>

<p>// انجام عملیات درصد تخفیف</p>

<p>decimal resultDiscount = calculator.Discount(200000, 20);</p>

<p>// انجام عملیات درصد مالیات</p>

<p>decimal resultTaxation = calculator.Taxation(500000, 9);</p>

<p>////////////////////////////////////////////////////////////////</p>

<p>// Getting numbers for calculations</p>

<p>double[] numbers = { 2.6, 7, 8, 9 };</p>

<p>// Creating an instance of the Calculator class</p>

<p>Calculator calculator = new Calculator();</p>

<p>// Performing multiplication operation double resultMultiply = calculator.Multiply(numbers);</p>

<p>// Performing addition operation</p>

<p>double resultAdd = calculator.Add(numbers);</p>

<p>// Performing subtraction operation</p>

<p>double resultSubtract = calculator.Subtract(numbers);</p>

<p>// Performing division operation</p>

<p>double resultDivide = calculator.Divide(numbers);</p>

<p>// Performing discount percentage operation</p>

<p>decimal resultDiscount = calculator.Discount(200000, 20);</p>

<p>// Performing taxation percentage operation</p>

<p>decimal resultTaxation = calculator.Taxation(500000, 9);</p>

<p>&nbsp;&nbsp;&nbsp; Converting numbers into words for displaying amounts</p>

<p>long moneyNumber = 15451225858;</p>

<p>// تبدیل عدد به حروف برحسب واحد پول ایران</p>

<p>string moneyRaghamToHorof = ConvertNumbertToString.ConvertRaghamToHorof(moneyNumber);</p>

<p>// دا کردن سه رقم اعشار اعداد</p>

<p>string moneyRaghamToJodaJoda = ConvertNumbertToString.ConvertRaghamToJodaJoda(moneyNumber);</p>

<p>// تبدیل عدد به حروف برحسب واحد پول ایران</p>

<p>string moneyNumToString = ConvertNumToString.convert(moneyNumber.ToString());</p>

<p>/*</p>

<p>کاربرد زیرمجموعه دستورها در StringExtensions: به ترتیب</p>

<p>StringExtensions.HasValue: بررسی اینکه آیا مقدار وجود داره یا خیر</p>

<p>StringExtensions.ToInt: تبدیل به Int</p>

<p>StringExtensions.ToDecimal: تبدیل به ToDecimal</p>

<p>StringExtensions.ToNumeric (int): دریافت مقدار int و نمایش آن به صورت سه رقم اعشار</p>

<p>StringExtensions.ToNumeric (decimal): دریافت مقدار decimal و نمایش آن به صورت سه رقم اعشار</p>

<p>StringExtensions.ToCurrency (int): دریافت مقدار int و نمایش آن به صورت ارزی</p>

<p>StringExtensions.ToCurrency (decimal): دریافت مقدار decimal و نمایش آن به صورت ارزی</p>

<p>StringExtensions.En2Fa: جایگزین عدد انگلیسی به جای عدد پارسی</p>

<p>StringExtensions.Fa2En: جایگزین عدد پارسی به جای عدد انگلیسی</p>

<p>StringExtensions.FixPersianChars: جایگزین حروف عربی و غیر ایرانی به جای حروف پارسی</p>

<p>StringExtensions.RemovePoint: حذف نقطه یا علامت اعشار از اعداد</p>

<p>StringExtensions.CleanString: انجام چندین عملیات پاکسازی با هم</p>

<p>StringExtensions.NullIfEmpty: جلوگیری از مقدار خالی و ارسال Null به جای مقدار خالی</p>

<p>StringExtensions.HtmlTags: حذف تگ&zwnj;های html از متن</p>

<p>StringExtensions.ASCII: حذف مقدار عملکر گردها از متن</p>

<p>*/</p>

<p>string stringExtensions = StringExtensions.CleanString(&quot;چطوری خوبی&quot;);</p>

<p>long moneyNumber = 15451225858;</p>

<p>// Convert the number to words based on Iranian currency</p>

<p>string moneyRaghamToHorof = ConvertNumbertToString.ConvertRaghamToHorof(moneyNumber);</p>

<p>// Splitting the decimal numbers</p>

<p>string moneyRaghamToJodaJoda = ConvertNumbertToString.ConvertRaghamToJodaJoda(moneyNumber);</p>

<p>// Convert the number to words based on Iranian currency</p>

<p>string moneyNumToString = ConvertNumToString.convert(moneyNumber.ToString());</p>

<p>/* The usage of StringExtensions subset</p>

<p>In order:</p>

<p>StringExtensions.HasValue: Check if a value exists or not</p>

<p>StringExtensions.ToInt: Convert to Int</p>

<p>StringExtensions.ToDecimal: Convert to Decimal</p>

<p>StringExtensions.ToNumeric: Get the int value and display it with split decimal numbers</p>

<p>StringExtensions.ToNumeric: Get the decimal value and display it with split decimal numbers</p>

<p>StringExtensions.ToCurrency: Get the int value and display it as currency</p>

<p>StringExtensions.ToCurrency: Get the decimal value and display it as currency</p>

<p>StringExtensions.En2Fa: Replace Persian numbers with English ones</p>

<p>StringExtensions.Fa2En: Replace English numbers with Persian ones</p>

<p>StringExtensions.FixPersianChars: Replace Persian characters with non-Iranian ones</p>

<p>StringExtensions.RemovePoint: Remove the decimal point or comma from the numbers</p>

<p>StringExtensions.CleanString: Perform several cleaning operations together</p>

<p>StringExtensions.NullIfEmpty: Take care of empty values and send Null instead of an empty value</p>

<p>StringExtensions.HtmlTags: Remove html tags from descriptions</p>

<p>StringExtensions.ASCII: Remove operation characters</p>

<p>*/</p>

<p>string stringExtensions = StringExtensions.CleanString(&quot;How are you&quot;);</p>

<p><strong>&nbsp;&nbsp;&nbsp; Analyzing Persian texts: converting non-Persian characters to Persian, converting English numbers into Persian, and vice versa, etc.<br />
&nbsp;&nbsp;&nbsp; Date operations: converting and calculating time<br />
&nbsp;&nbsp;&nbsp; Encoding and decoding encoded values<br />
&nbsp;&nbsp;&nbsp; Generating values, meaning generating numbers, etc.</strong></p>
</body>
</html>
