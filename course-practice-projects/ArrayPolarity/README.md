# Positive & Negative Arrays with Position Sum

## Concept

Working with multiple arrays and dividing data into categories is a fundamental programming skill. By separating positive and negative values into their own arrays, you gain clearer insight into how data is distributed.

This challenge also introduces **random number generation** and **position-based calculations** across arrays.

## The Challenge

Write a program that:

1. Asks the user for an integer **N** (size of arrays).
2. Creates two arrays of size `N`:

   * One for **positive numbers**
   * One for **negative numbers**
   * Both initialized with zeros.
3. Generates **N random integers** (positive or negative).
4. Stores each random number in the appropriate array:

   * Positive numbers go into the **positive array** at the same index.
   * Negative numbers go into the **negative array** at the same index.
   * If a slot has no value of a type, it remains `0`.
5. Calculates the **position sum** array:

   * Add the numbers at the same index of the two arrays.
   * Store the result in a new array.
6. Displays all three arrays:

   * Positive array
   * Negative array
   * Position sum array

## Example Output

```
Input:
N = 5

Random numbers generated: -2, 3, 5, -5, -2

Positive numbers (5 of them): 0, 3, 5, 0, 0
Negative numbers (5 of them): -2, 0, 0, -5, -2
Position sum of numbers: -2, 3, 5, -5, -2
```

## Input Validation

* Reject **non-numeric input** for `N`.
* Reject if `N <= 0`.
* Prompt the user again if input is invalid.

## Why This Matters

This challenge strengthens your ability to:

* Work with **parallel arrays**.
* Use **random number generation**.
* Apply **conditional logic** to store values.
* Perform **position-wise array operations**.

---

<div dir="rtl">

# آرایه‌های مثبت و منفی با جمعِ موقعیتی  

### مفهوم  
کار با چند آرایه و دسته‌بندی داده‌ها یکی از مهارت‌های پایه‌ای برنامه‌نویسی است. با جدا کردن اعداد مثبت و منفی در آرایه‌های جداگانه، بهتر می‌توان نحوه‌ی توزیع داده‌ها را تحلیل کرد.  
این چالش همچنین شامل تولید عدد تصادفی و محاسبات موقعیتی بین چند آرایه است.

---

### چالش  
برنامه‌ای بنویسید که:

1. از کاربر یک عدد صحیح **N** (اندازه آرایه‌ها) دریافت کند.  
2. دو آرایه‌ی به اندازه **N** بسازد:  
   - آرایه‌ی اعداد مثبت  
   - آرایه‌ی اعداد منفی  
   (هر دو در ابتدا با صفر مقداردهی اولیه شوند)  
3. **N عدد تصادفی** مثبت یا منفی تولید کند.  
4. هر عدد را در جایگاه متناظر خودش ذخیره کند:  
   - اگر مثبت بود → در آرایه مثبت  
   - اگر منفی بود → در آرایه منفی  
   - اگر در یک آرایه مقداری وجود نداشته باشد، همان ۰ باقی می‌ماند  
5. آرایه «جمعِ موقعیتی» بسازد:  
   - جمع عناصر با **یک ایندکس مشترک**  
6. هر سه آرایه را نمایش دهد:  
   - آرایه اعداد مثبت  
   - آرایه اعداد منفی  
   - آرایه جمع موقعیتی  

---

### مثال خروجی  
**ورودی:**  
N = 5  

اعداد تصادفی تولیدشده:  
`-2, 3, 5, -5, -2`

**آرایه مثبت‌ها:**  
`0, 3, 5, 0, 0`

**آرایه منفی‌ها:**  
`-2, 0, 0, -5, -2`

**آرایه جمع موقعیتی:**  
`-2, 3, 5, -5, -2`

---

### اعتبارسنجی ورودی  
- رد ورودی‌های غیرعددی  
- رد اگر N ≤ 0  
- درخواست دوباره ورودی در صورت اشتباه بودن  

---

### چرا مهم است؟  
این چالش توانایی شما را در موارد زیر تقویت می‌کند:

- کار با آرایه‌های موازی  
- استفاده از تولید اعداد تصادفی  
- منطق شرطی برای دسته‌بندی داده  
- انجام محاسبات موقعیتی در آرایه‌ها  

</div>

