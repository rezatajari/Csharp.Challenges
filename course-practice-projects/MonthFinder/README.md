# Month Finder

## Concept

We use months constantly — for birthdays, schedules, events, and planning.  
However, computers do not understand month names like *“January”* or *“April”* directly.  
Instead, they work with numeric values such as `1` or `4`.

This challenge focuses on creating a model that connects **month numbers** to meaningful details:

- The **name** of the month (e.g., `1 → January`)
- The **number of days** in that month (e.g., `April → 30`)

For simplicity, treat **February** as having **28 days**.

---

## The Challenge

1. Create a `Month` class that includes:
   - A data member to store the month number  
   - A method to return the **name** of the month  
   - A method to return the **number of days** in that month  
   - An overridden `ToString()` that displays complete month details  

2. Create a second class (or main program) that:
   - Asks the user to enter a month number  
   - Displays the **month name** and **number of days**  
   - Shows an error message if the month number is not within `1–12`  

---

## Why This Matters

This challenge helps you:

- Represent **real-world concepts** (months) using classes  
- Use methods to generate meaningful information from data  
- Handle **invalid input** safely and correctly  
- Understand how programs can model real-life systems  

Think of this assignment as building a tiny **calendar helper** that bridges how humans think about months and how computers process them.

---

<div dir="rtl">

# یافتن ماه

## مفهوم

ما هر روز از ماه‌ها استفاده می‌کنیم—برای تولدها، برنامه‌ریزی، قرارها و مدیریت زمان.  
اما کامپیوترها نام ماه‌ها را نمی‌فهمند؛ آن‌ها فقط با عدد کار می‌کنند، مثل `1` یا `4`.

هدف این تمرین ساخت مدلی است که **عدد ماه** را به اطلاعات واقعی تبدیل کند:

- **نام ماه** (مثلاً `1 → January`)  
- **تعداد روزهای ماه** (مثلاً `April → 30`)  

برای سادگی، ماه **فوریه همیشه ۲۸ روزه** در نظر گرفته می‌شود.

---

## چالش

۱. یک کلاس به نام `Month` بسازید که شامل موارد زیر باشد:

- یک متغیر برای نگه‌داشتن عدد ماه  
- یک متد برای برگرداندن **نام ماه**  
- یک متد برای برگرداندن **تعداد روزهای ماه**  
- متد بازنویسی‌شدهٔ `ToString()` برای نمایش اطلاعات کامل ماه  

۲. یک کلاس دوم یا برنامهٔ اصلی بنویسید که:

- از کاربر یک عدد ماه دریافت کند  
- نام ماه و تعداد روزهای آن را نمایش دهد  
- اگر عدد واردشده خارج از بازهٔ `1 تا 12` بود، پیام خطا نشان دهد  

---

## چرا این مهم است؟

این تمرین به شما کمک می‌کند:

- مفاهیم واقعی (مثل ماه‌ها) را با استفاده از **کلاس‌ها و اشیا** مدل‌سازی کنید  
- با استفاده از متدها **اطلاعات مفید** تولید کنید  
- ورودی‌های **نامعتبر** را به‌درستی مدیریت کنید  
- بفهمید که برنامه‌ها چطور می‌توانند مانند یک **تقویم کوچک** عمل کنند  

</div>
