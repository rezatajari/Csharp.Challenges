# Frequency Distribution Bar Chart

## Concept

Analyzing the frequency of values in a dataset is a key skill in data analysis. Visualizing frequencies using simple bar charts can quickly reveal patterns and trends in data.

This challenge focuses on **dynamic input**, **array usage**, **input validation**, and **basic visualization**.

## The Challenge

Write a program that:

1. Allows the user to enter any number of values between **0 and 10**.
2. Stops accepting input when the user chooses to stop (for example, by entering a special keyword like `"done"`).
3. Keeps track of the **frequency of each number**.
4. Displays a **frequency distribution bar chart** using asterisks (`*`) to represent counts.

### Requirements

* If a number is not entered at all, the corresponding line should **not display any asterisks**.
* Show error messages for:

  * Values outside the range `0–10`
  * Non-numeric input

## Example Output

```
Enter a number between 0 and 10 (or 'done' to finish): 3
Enter a number between 0 and 10 (or 'done' to finish): 7
Enter a number between 0 and 10 (or 'done' to finish): 3
Enter a number between 0 and 10 (or 'done' to finish): done

Frequency Distribution:
0:
1:
2:
3: **
4:
5:
6:
7: *
8:
9:
10:
```

## Input Validation

* Reject any **number outside the 0–10 range**.
* Reject **non-numeric input** (except the stop keyword, e.g., `"done"`).
* Prompt the user to **re-enter** if input is invalid.

## Why This Matters

This exercise teaches you how to:

* Handle **dynamic arrays** and store multiple values.
* Perform **frequency counting**.
* Build **basic visualizations** in the terminal.
* Implement **robust input validation**.

---
<div dir="rtl">

# نمودار میله‌ای توزیع فراوانی

### مفهوم  
تحلیل فراوانی داده‌ها یکی از مهارت‌های مهم در **تحلیل داده** است.  
نمایش فراوانی با استفاده از نمودارهای سادهٔ متنی (مانند *‌ستاره‌ها*) می‌تواند الگوها و روندها را به‌سرعت آشکار کند.

این چالش بر **ورودی پویا، آرایه‌ها، اعتبارسنجی ورودی، و ایجاد یک نمایش بصری ساده** تمرکز دارد.

---

## چالش

**برنامه باید:**

**۱.** از کاربر اجازه دهد هر تعداد عدد بین **۰ تا ۱۰** وارد کند.  
**۲.** با وارد کردن یک کلمهٔ مخصوص (مثلاً `"done"`) ورود داده‌ها متوقف شود.  
**۳.** فراوانی هر عدد را ذخیره کند.  
**۴.** در نهایت یک **نمودار میله‌ای** بسازد که تعداد هر عدد را با علامت `*` نمایش دهد.  

---

## الزامات

- اگر عددی *هیچ‌بار* وارد نشده باشد، در خط مربوط به آن هیچ ستاره‌ای نمایش داده نشود.  
- اگر ورودی نادرست باشد، خطا نمایش داده شده و دوباره ورودی درخواست شود.

### خطاها شامل:
- عدد خارج از بازهٔ **۰ تا ۱۰**
- ورودی غیرعددی (به‌جز کلمهٔ خاتمه مثل `"done"`)

---

## نمونه خروجی
</div>
<div dir="ltr">

Enter a number between 0 and 10 (or 'done' to finish): 3

Enter a number between 0 and 10 (or 'done' to finish): 7

Enter a number between 0 and 10 (or 'done' to finish): 3

Enter a number between 0 and 10 (or 'done' to finish): done

Frequency Distribution:

0:

1:

2:

3: **

4:

5:

6:

7: *

8:

9:

10:

</div>
<div dir="rtl">

## اعتبارسنجی ورودی

- هر عدد خارج از بازهٔ **۰ تا ۱۰** رد شود.  
- ورودی غیرعددی (به‌جز `"done"`) پذیرفته نشود.  
- در صورت خطا، از کاربر درخواست ورودی معتبر شود.

---

## چرا این مهم است؟

این تمرین به شما کمک می‌کند:

- با **آرایه‌های پویا و شمارش فراوانی** کار کنید  
- **نمودارهای متنی ساده** ایجاد کنید  
- **اعتبارسنجی ورودی** را حرفه‌ای پیاده‌سازی کنید  
- داده‌ها را به شکل قابل‌فهم بصری نمایش دهید  

این یک تمرین بسیار عالی برای تقویت مهارت‌های پایهٔ تحلیل داده و ورود اطلاعات است.

</div>


