### Tortoise vs. Hare Race (Detailed Version)

**Concept:**
This challenge simulates a race between a Tortoise and a Hare on a 70-unit track. It emphasizes **loops, randomness, state tracking, and conditional logic**. The race extends the classic story by including **probabilistic moves**, so each competitor behaves unpredictably according to defined probabilities.

**Movement Rules:**

**Tortoise:**

| Move Type | Probability | Actual Move |
| --------- | ----------- | ----------- |
| Fast Plod | 50%         | +3 squares  |
| Slip      | 20%         | -6 squares  |
| Slow Plod | 30%         | +1 square   |

**Hare:**

| Move Type  | Probability | Actual Move |
| ---------- | ----------- | ----------- |
| Sleep      | 20%         | 0 squares   |
| Big Hop    | 20%         | +9 squares  |
| Big Slip   | 10%         | -12 squares |
| Small Hop  | 30%         | +1 square   |
| Small Slip | 20%         | -2 squares  |

**Objective:**

1. Simulate movement based on the probabilities.
2. Update each racer’s position.
3. Display a visual representation of the track after each move.
5. Continue until one or both reach the finish line.
6. Declare the winner or a tie.

**Why It Matters:**

* Practice **looping and sequential steps**.
* Learn **weighted randomness** to model variability.
* Track **state variables** for multiple entities.
* Implement **conditional logic** for collisions and finish line detection.
* Create **dynamic console visualization**.

**Example Output:**

```
Track:  T................................H....................
Track:  ..T..............................H...................
H wins!
```

---
### مسابقه لاک‌پشت و خرگوش (نسخهٔ کامل)

## مفهوم
این چالش یک مسابقهٔ ش模‌سازی‌شده بین **لاک‌پشت** و **خرگوش** در مسیر ۷۰ واحدی است.  
تمرکز آن بر **حلقه‌ها، تصادفی‌سازی، پیگیری وضعیت و منطق شرطی** است.  
رفتار هرکدام بر اساس **احتمالات تعریف‌شده** و به‌صورت غیرقابل‌پیش‌بینی انجام می‌شود.

---

## قوانین حرکت

### لاک‌پشت

| نوع حرکت     | احتمال | جابه‌جایی واقعی |
|--------------|--------|------------------|
| حرکت سریع    | ۵۰٪    | ۳ خانه جلو      |
| لیز خوردن    | ۲۰٪    | ۶ خانه عقب      |
| حرکت آهسته   | ۳۰٪    | ۱ خانه جلو      |

---

### خرگوش

| نوع حرکت       | احتمال | جابه‌جایی واقعی |
|----------------|--------|------------------|
| خواب           | ۲۰٪    | بدون حرکت        |
| پرش بزرگ       | ۲۰٪    | ۹ خانه جلو       |
| لیز خوردن بزرگ | ۱۰٪    | ۱۲ خانه عقب      |
| پرش کوچک       | ۳۰٪    | ۱ خانه جلو       |
| لیز خوردن کوچک | ۲۰٪    | ۲ خانه عقب       |

---

## هدف مسابقه

<p dir="rtl">

۱. حرکت دادن دو شرکت‌کننده بر اساس احتمال‌های داده‌شده.  
۲. به‌روزرسانی موقعیت هر شرکت‌کننده پس از هر نوبت.  
۳. نمایش تصویری مسیر مسابقه پس از هر حرکت.  
۴. ادامهٔ مسابقه تا زمانی که یکی یا هر دو به خط پایان برسند.  
۵. اعلام برنده یا تساوی.

</p>

---

## چرا مهم است؟

- تمرین کار با **حلقه‌ها و مراحل پی‌درپی**  
- یادگیری **تصادفی‌سازی وزن‌دار**  
- تمرین **پیگیری وضعیت چند موجودیت**  
- اعمال **منطق شرطی** برای برخوردها و خط پایان  
- ایجاد **نمایش پویا** در محیط متنی  

---

## نمونه خروجی
```
Track:  T................................H....................
Track:  ..T..............................H...................
H wins!
```
