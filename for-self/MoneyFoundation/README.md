# MoneyFoundation 

A high-performance, domain-driven banking core built with C# and .NET. This project focuses on building a secure and scalable financial system from the ground up.

---

## Challenge 1: The Atomic Foundation (Complete)

**Goal:** Create a bulletproof "Value Object" system for handling money. In this challenge, we ensure that the system prevents mathematical errors, avoids rounding issues, and maintains domain integrity at the lowest level.

### Task 1: Defining the Currency Identity
In a banking system, a currency is not just a label; it is a weight that defines value.
* **Requirement:** Create a `readonly struct` named `Currency`.
* **Properties:** `Name` (string) and `Rate` (decimal).
* **Validation:**
    * The constructor must throw an exception if the `Name` is null or empty.
    * The constructor must throw an exception if the `Rate` is less than or equal to zero.
* **Equality:** Implement equality operators (`==`, `!=`) to ensure currencies are compared by value, not by reference.



### Task 2: Building the Money Container (Value Object)
"Glue" an amount to a currency to create a meaningful financial unit. 
* **Requirement:** Create a `readonly struct` named `Money`.
* **Properties:** `decimal Amount` and `Currency Currency`.
* **Immutability:** Use `get`-only properties. Once a `Money` instance is created, it cannot be modified; it can only produce a new value through operations.
* **Defensive Design:** Guard against the "Default State" (where `Currency` might be null) by adding validation in the property initialization or constructor.

### Task 3: Enforcing Mathematical Safety (Operator Overloading)
Teach the system the "Laws of the Bank" to prevent illegal operations.
* **Addition (+):** Allow adding two `Money` objects **only if** they share the same `Currency`. Throw an `InvalidOperationException` if a mismatch occurs.
* **Subtraction (-):** Allow subtraction with the same currency validation. 
* **Equality (==):** Implement equality so that `100 USD` is exactly equal to another instance of `100 USD`, but never equal to `100 Rial`.



---

## Technical Topics Applied
* **Readonly Structs:** Memory-efficient stack allocation.
* **Immutability:** Ensuring thread-safety and preventing accidental data changes.
* **Operator Overloading:** Providing a clean, expressive math-like API.
* **Semantic Data Modeling:** Linking raw numbers to their domain context (Currency).
* **Defensive Programming:** Using "Fail-Fast" logic to catch errors at the source.

---

## Challenge 2: The Bank Account Entity

### Overview
In this challenge, we transitioned from simple **Value Objects** to a robust **Domain Entity**. The focus was on protecting the "State" of an account and ensuring that every financial movement is traceable and valid.

##  Architectural Decisions

### 1. Entity vs. Value Object
We designed `Account` as a **Class** (Reference Type). 
* **Reasoning:** A bank account has a unique **Identity** (Account Number) that stays the same even if the data (Balance) changes. It must be shared across the system without being copied.

### 2. The "Twin-Storage" Encapsulation
To protect the transaction history, we used the **Private Workhorse / Public Window** pattern:
* **Private:** `List<Transaction> _transactions` allows the `Account` class to record history.
* **Public:** `IReadOnlyList<Transaction> Transactions` allows outside users to view history without the ability to `Add()` or `Clear()` records.



### 3. Fail-Fast Guard Clauses
We implemented strict validation at the "Entry Points" (Constructor and Methods):
* **Null Checks:** Prevent "Zombie Accounts" by ensuring `User` and `Currency` are valid upon creation.
* **Domain Rules:** Prevent currency mismatch and unauthorized overdrafts before the balance is ever touched.

## Components

| Component | Type | Responsibility |
| :--- | :--- | :--- |
| `Account` | **Class** | Manages balance, enforces rules, and owns the history. |
| `Transaction` | **Readonly Struct** | Captures a "Snapshot" of a move (Amount, Type, Time). |
| `TransactionType`| **Enum** | Categorizes moves (Deposit, Withdrawal, Transfer). |

##  Data Integrity Example
```csharp


// Recalculating balance from history to verify state
public Money GetVerifiedBalance()
{
    decimal total = 0;
    foreach(var tx in _transactions)
    {
        if (tx.Type == TransactionType.Deposit) total += tx.Amount.Amount;
        else total -= tx.Amount.Amount;
    }
    return new Money(total, Currency);
}

```
---

## Challenge 3: The Bank Management System

### Overview
In this challenge, we moved from managing a single **Account** to building a **Bank** system. This required handling collections of entities and coordinating interactions between two different objects (Transfers).

## Architectural Decisions

### 1. The Registry (Storage)
We implemented a private collection within the `Bank` class to manage account lifecycles.
* **Encapsulation:** The list of accounts is `private`. The only way to interact with an account is through the Bank's verified methods (`GetAccount`).
* **Identity-Based Lookup:** We used **LINQ** (`FirstOrDefault`) to retrieve accounts by their unique `Number`.

### 2. Transactional Atomicity (The Transfer)
The biggest challenge was ensuring that money doesn't "disappear" during a transfer. We implemented the **Validate-All-Then-Act** pattern:
* **Pre-Execution Guards:** We verify the currency compatibility of the Source, the Destination, AND the Money object before a single cent is withdrawn.
* **Safety:** If the destination account is incompatible, the process throws an exception *before* the source account is debited.



### 3. Factory Pattern
The `Bank` acts as a factory for accounts. Instead of the user manually creating an `Account` object, the `Bank.OpenAccount` method handles:
1. Validation of the User and Currency.
2. Instantiation of the Account.
3. Registration in the internal "Vault."
4. Returning the `AccountNumber` as the unique handle for the user.

## Components

| Component | Responsibility |
| :--- | :--- |
| `Bank` | The Orchestrator. Manages account storage and inter-account transfers. |
| `LINQ` | Used for efficient searching within

---

By completing these 3 challenges, you have successfully covered:
1. Types & Logic: Structs vs. Classes, Operator Overloading.
2. Encapsulation: Private fields, Read-only properties, and Data Hiding.
3. Collections & LINQ: Managing lists and searching data.
4. Exceptions: Guarding against invalid states.

---

# MoneyFoundation

یک هسته بانکی مبتنی بر دامنه با کارایی بالا که با C# و .NET ساخته شده است.  
این پروژه بر طراحی یک سیستم مالی امن، مقیاس‌پذیر و قابل‌اعتماد از پایه تمرکز دارد.

---

## چالش ۱: پایه اتمیک (تکمیل شده)

**هدف:** ایجاد یک سیستم «Value Object» کاملاً ایمن برای مدیریت پول.  
در این چالش تضمین می‌کنیم که سیستم از خطاهای ریاضی جلوگیری کند، مشکلات گرد کردن را حذف کند و یکپارچگی دامنه را در پایین‌ترین سطح حفظ نماید.

---

### وظیفه ۱: تعریف هویت ارز

در یک سیستم بانکی، ارز فقط یک برچسب نیست؛ بلکه وزنی است که ارزش را تعریف می‌کند.

- **الزام:** ایجاد یک `readonly struct` با نام `Currency`
- **ویژگی‌ها:**  
  - `Name` (رشته)  
  - `Rate` (عدد اعشاری)
- **اعتبارسنجی:**  
  - اگر `Name` خالی یا `null` باشد، سازنده باید خطا پرتاب کند  
  - اگر `Rate` کوچکتر یا مساوی صفر باشد، سازنده باید خطا پرتاب کند
- **برابری:**  
  - پیاده‌سازی عملگرهای `==` و `!=` برای مقایسه ارزها بر اساس **مقدار**، نه مرجع

---

### وظیفه ۲: ساخت ظرف پول (Value Object)

اتصال مقدار به ارز برای ایجاد یک واحد مالی معنادار.

- **الزام:** ایجاد یک `readonly struct` با نام `Money`
- **ویژگی‌ها:**  
  - `decimal Amount`  
  - `Currency Currency`
- **تغییرناپذیری:**  
  - استفاده از پراپرتی‌های فقط‌خواندنی  
  - پس از ساخته شدن، شیء `Money` قابل تغییر نیست و فقط می‌تواند مقدار جدید تولید کند
- **طراحی تدافعی:**  
  - جلوگیری از وضعیت پیش‌فرض (جایی که `Currency` ممکن است `null` باشد) با اعتبارسنجی در سازنده یا مقداردهی اولیه

---

### وظیفه ۳: ایمنی ریاضی (بارگذاری عملگرها)

آموزش «قوانین بانک» به سیستم برای جلوگیری از عملیات غیرقانونی.

- **جمع (+):**  
  - فقط در صورتی مجاز است که دو `Money` دارای ارز یکسان باشند  
  - در صورت عدم تطابق ارز، باید `InvalidOperationException` پرتاب شود
- **تفریق (-):**  
  - همان قوانین جمع را دارد
- **برابری (==):**  
  - `100 USD` دقیقاً برابر با `100 USD` دیگر است  
  - اما هرگز برابر با `100 Rial` نیست

---

## مباحث فنی استفاده‌شده

- **Readonly Structs:** تخصیص بهینه حافظه روی Stack  
- **تغییرناپذیری:** افزایش ایمنی در برابر Thread و جلوگیری از تغییرات ناخواسته  
- **بارگذاری عملگرها:** API تمیز و شبیه محاسبات ریاضی  
- **مدل‌سازی معنایی داده:** اتصال اعداد خام به مفهوم دامنه (ارز)  
- **برنامه‌نویسی تدافعی:** تشخیص سریع خطا در منبع

---

## چالش ۲: موجودیت حساب بانکی

### نمای کلی

در این چالش، از **Value Object**‌های ساده به یک **موجودیت دامنه‌ای** قدرتمند منتقل شدیم.  
تمرکز اصلی روی محافظت از وضعیت حساب و معتبر بودن تمام تراکنش‌ها بود.

---

## تصمیمات معماری

### ۱. موجودیت در برابر Value Object

`Account` به‌صورت **Class** (نوع مرجعی) طراحی شد.

- **دلیل:**  
  - حساب بانکی دارای هویت یکتاست (شماره حساب)  
  - حتی با تغییر موجودی، هویت ثابت می‌ماند  
  - باید در کل سیستم به اشتراک گذاشته شود، نه کپی

---

### ۲. کپسوله‌سازی ذخیره‌سازی دوگانه

برای محافظت از تاریخچه تراکنش‌ها از الگوی «موتور خصوصی / پنجره عمومی» استفاده شد:

- **خصوصی:**  
  - `List<Transaction> _transactions` برای ثبت تاریخچه
- **عمومی:**  
  - `IReadOnlyList<Transaction> Transactions` برای مشاهده بدون امکان تغییر

---

### ۳. اعتبارسنجی Fail-Fast

اعتبارسنجی سخت‌گیرانه در نقاط ورودی (سازنده و متدها):

- **بررسی null:** جلوگیری از ایجاد حساب‌های نامعتبر  
- **قوانین دامنه:** جلوگیری از عدم تطابق ارز و برداشت غیرمجاز قبل از تغییر موجودی

---

## اجزا

| جزء | نوع | مسئولیت |
|---|---|---|
| `Account` | کلاس | مدیریت موجودی، اعمال قوانین، مالک تاریخچه |
| `Transaction` | ساختار فقط‌خواندنی | ثبت اسنپ‌شات تراکنش |
| `TransactionType` | enum | نوع تراکنش (واریز، برداشت، انتقال) |

---

## نمونه تضمین یکپارچگی داده

```csharp
// محاسبه مجدد موجودی از روی تاریخچه برای بررسی صحت وضعیت
public Money GetVerifiedBalance()
{
    decimal total = 0;
    foreach(var tx in _transactions)
    {
        if (tx.Type == TransactionType.Deposit)
            total += tx.Amount.Amount;
        else
            total -= tx.Amount.Amount;
    }
    return new Money(total, Currency);
}

```

## چالش ۳: سیستم مدیریت بانک

### نمای کلی

در این مرحله، از مدیریت یک حساب به ساخت یک سیستم بانکی کامل رسیدیم.  
این کار نیازمند مدیریت مجموعه‌ای از موجودیت‌ها و هماهنگی بین آن‌ها بود.

---

## تصمیمات معماری

### ۱. رجیستری (ذخیره‌سازی)

یک مجموعه خصوصی در کلاس `Bank` برای مدیریت چرخه عمر حساب‌ها:

- **کپسوله‌سازی:** لیست حساب‌ها خصوصی است  
- **دسترسی امن:** فقط از طریق متدهای تأییدشده بانک  
- **جستجوی مبتنی بر هویت:** استفاده از LINQ برای یافتن حساب بر اساس شماره  

---

### ۲. اتمی بودن تراکنش‌ها (انتقال وجه)

برای جلوگیری از ناپدید شدن پول از الگوی «اول اعتبارسنجی، بعد اجرا» استفاده شد:

- بررسی سازگاری ارز حساب مبدا، مقصد و مبلغ  
- در صورت ناسازگاری، قبل از برداشت خطا پرتاب می‌شود  

---

### ۳. الگوی Factory

بانک به‌عنوان کارخانه ایجاد حساب عمل می‌کند:

1. اعتبارسنجی کاربر و ارز  
2. ساخت حساب  
3. ثبت در مخزن داخلی  
4. بازگرداندن شماره حساب به‌عنوان شناسه یکتا  

---

## اجزا

| جزء | مسئولیت |
|---|---|
| `Bank` | هماهنگ‌کننده و مدیر حساب‌ها |
| `LINQ` | جستجوی سریع در مجموعه‌ها |

---

## دستاوردهای نهایی

با تکمیل این سه چالش، موارد زیر به‌صورت عملی پوشش داده شده‌اند:

- **انواع داده و منطق:** Struct در برابر Class، بارگذاری عملگرها  
- **کپسوله‌سازی:** فیلدهای خصوصی و پراپرتی‌های فقط‌خواندنی  
- **مجموعه‌ها و LINQ:** مدیریت و جستجوی داده  
- **استثناها:** جلوگیری از وضعیت‌های نامعتبر  
