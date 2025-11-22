# Name Formatter (Windows Form)

## Concept

This challenge focuses on Windows Forms input handling and string formatting. You’ll build an application that takes multiple user inputs and displays all possible name formats in a ListView when a button is clicked.

## The Challenge

Create a Windows Form application with the following input controls:

- TextBox for First Name  
- TextBox for Middle Name  
- TextBox for Last Name  
- TextBox or ComboBox for Title (Mr., Mrs., Ms., Dr., etc.)

Add a single Button for formatting.

Add a ListView control to display the formatted names.

When the button is clicked, the program should display the following formats:

| Name Format | Example |
|-------------|---------|
| Title First Middle Last | Ms. Kelly Jane Smith |
| First Middle Last | Kelly Jane Smith |
| First Last | Kelly Smith |
| Last, First Middle, Title | Smith, Kelly Jane, Ms. |
| Last, First Middle | Smith, Kelly Jane |
| Last, First | Smith, Kelly |

Ensure the program handles missing input gracefully and updates the ListView correctly.

## Example Input

First: Kelly  
Middle: Jane  
Last: Smith  
Title: Ms.

## Example Output (ListView)

Ms. Kelly Jane Smith  
Kelly Jane Smith  
Kelly Smith  
Smith, Kelly Jane, Ms.  
Smith, Kelly Jane  
Smith, Kelly  

---

<div dir="rtl">

# قالب‌بندی نام (Windows Form)

## مفهوم

این تمرین روی دریافت ورودی در Windows Forms و قالب‌بندی رشته‌ها تمرکز دارد.  
کاربر نام، نام‌میانی، نام خانوادگی و عنوان را وارد می‌کند و برنامه باید همهٔ قالب‌های ممکن را نمایش دهد.

## چالش

برنامه باید:

- چهار ورودی برای نام، نام‌میانی، نام خانوادگی و عنوان داشته باشد  
- یک دکمه برای تولید قالب‌ها  
- یک ListView برای نمایش خروجی  

قالب‌های مورد نیاز:

- عنوان + نام + نام‌میانی + نام خانوادگی  
- نام + نام‌میانی + نام خانوادگی  
- نام + نام خانوادگی  
- نام خانوادگی، نام + نام‌میانی، عنوان  
- نام خانوادگی، نام + نام‌میانی  
- نام خانوادگی، نام  

## نمونه خروجی

Ms. Kelly Jane Smith  
Kelly Jane Smith  
Kelly Smith  
Smith, Kelly Jane, Ms.  
Smith, Kelly Jane  
Smith, Kelly  

</div>
