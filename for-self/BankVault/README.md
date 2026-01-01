# The Bank Vault (Encapsulation)

## Challenge Overview

This mini-project teaches the principle of **encapsulation** in C#.
You will implement a `BankAccount` class that represents a strict bank vault where the balance is fully protected.

The goal is to ensure the balance can only be changed through controlled methods, mimicking a real-world banking system.

---

## Learning Objectives

* Understand the difference between **private fields** and public methods
* Apply **business rules** when designing a class
* Practice **defensive programming** to prevent invalid operations
* Reinforce **object-oriented thinking** and design-first mindset

---

## Story

Imagine a bank account as a strict vault:

* The account’s money is **private** and cannot be accessed directly
* Only the account itself can change the balance
* All updates happen through **methods** such as AddMoney and RemoveMoney
* The balance **cannot go negative**, but it **can reach zero**
* External code can only interact through these controlled methods

This design models a real-world bank system, rather than a simple data container.

---

## Rules

* Store the balance in a **private field**
* The constructor must initialize the balance safely
* Implement methods to add and remove money following business rules
* Do not expose the balance as a public field
* Use **professional naming conventions**:

  * `_camelCase` for private fields
  * `PascalCase` for methods and public members

---

## Example Scenario

* Initialize the account with a starting balance
* Add a positive amount to increase the balance
* Remove an amount, ensuring the balance never goes below zero
* Attempting to remove more than the balance should be safely prevented

---

## Completion Checklist

* The balance cannot become negative
* The money field is fully private
* All changes go through controlled methods
* The constructor enforces the same rules as the methods
* Naming conventions are professional and consistent

---

## Reflection

Encapsulation solves the problem of uncontrolled access:

* Protects sensitive data from external interference
* Ensures all business rules are enforced in one place
* Allows future features, such as logging or permission checks, without changing external code

---

# گاوصندوق بانکی (Encapsulation)

## مرور چالش
این مینی‌پروژه اصل **کپسوله‌سازی (Encapsulation)** را در زبان **C#** آموزش می‌دهد.  
در این تمرین، شما یک کلاس `BankAccount` پیاده‌سازی می‌کنید که مانند یک **گاوصندوق بانکی سخت‌گیر** عمل می‌کند؛ جایی که موجودی حساب کاملاً محافظت‌شده است.

هدف این است که موجودی حساب **فقط از طریق متدهای کنترل‌شده** تغییر کند، درست مثل یک سیستم بانکی واقعی.

---

## اهداف آموزشی
- درک تفاوت بین **فیلدهای private** و متدهای public  
- اعمال **قوانین تجاری (Business Rules)** هنگام طراحی کلاس  
- تمرین **برنامه‌نویسی دفاعی (Defensive Programming)** برای جلوگیری از عملیات نامعتبر  
- تقویت تفکر **شیء‌گرا** و طراحی مبتنی بر اصول درست  

---

## داستان
یک حساب بانکی را مانند یک گاوصندوق بسیار سخت‌گیر تصور کنید:

- پول حساب **خصوصی (private)** است و دسترسی مستقیم ندارد  
- فقط خود حساب می‌تواند موجودی را تغییر دهد  
- تمام تغییرات از طریق **متدها** انجام می‌شود (مثل `AddMoney` و `RemoveMoney`)  
- موجودی حساب **هرگز منفی نمی‌شود**، اما می‌تواند به **صفر** برسد  
- کدهای خارجی فقط از طریق این متدهای کنترل‌شده می‌توانند با حساب تعامل داشته باشند  

این طراحی بیشتر شبیه یک سیستم بانکی واقعی است، نه فقط یک ظرف ساده برای نگه‌داشتن داده.

---

## قوانین
- موجودی حساب را در یک **فیلد private** ذخیره کنید  
- سازنده (Constructor) باید موجودی اولیه را به‌صورت امن مقداردهی کند  
- متدهایی برای اضافه‌کردن و کم‌کردن پول مطابق قوانین تجاری پیاده‌سازی کنید  
- موجودی حساب نباید به‌صورت public در دسترس باشد  
- از **قوانین نام‌گذاری حرفه‌ای** استفاده کنید:
  - `_camelCase` برای فیلدهای private  
  - `PascalCase` برای متدها و اعضای public  

---

## سناریوی نمونه
- حساب را با یک موجودی اولیه ایجاد کنید  
- یک مقدار مثبت به حساب اضافه کنید تا موجودی افزایش یابد  
- مقداری از حساب برداشت کنید، بدون اینکه موجودی منفی شود  
- تلاش برای برداشت بیش از موجودی باید به‌صورت امن متوقف شود  

---

## چک‌لیست تکمیل
- موجودی حساب هرگز منفی نمی‌شود  
- فیلد مربوط به پول کاملاً private است  
- تمام تغییرات فقط از طریق متدهای کنترل‌شده انجام می‌شود  
- سازنده همان قوانین متدها را اعمال می‌کند  
- نام‌گذاری‌ها حرفه‌ای، خوانا و یکپارچه هستند  

---

## تأمل پایانی
کپسوله‌سازی مشکل دسترسی کنترل‌نشده را حل می‌کند:

- از داده‌های حساس در برابر تغییرات ناخواسته محافظت می‌کند  
- تضمین می‌کند که تمام قوانین تجاری در یک نقطه اعمال شوند  
- امکان افزودن قابلیت‌های آینده (مثل لاگ‌گیری یا بررسی سطح دسترسی) را بدون تغییر کدهای خارجی فراهم می‌کند  

