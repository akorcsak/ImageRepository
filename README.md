# ImageRepository
This application was designed for the Winter 2022 - Shopify Developer Intern Challenge. It is used to store user-uploaded photos in a secure manner.

# Table of Contents
* [Features](#features)
* [Screenshots](#screenshots)
* [Technologies Used](#technologies-used)
* [BackEnd Functionality](#backend-functionality)

# Features
## Login and Register
The user will be directed to the login screen on the first page of the application, where they will input their email and password. Click the "Register here" link under the Log in button if the user does not have an account. When you register, you will be prompted to enter your preferred email address as well as a password. After pressing register, you'll get a notification stating that your account has been successfully created and that your credentials can now be used on the Sign in page.

## Main Page
All of the submitted images will be displayed on the main page once you've entered into the app. At any given moment, up to 6 photos can be displayed with the names of files beneath them. A scroll tool is included to scroll through all of the images if you want to see more. A message saying, "There are currently no photographs uploaded!" will be displayed if this is a fresh new account or if there are no images currently submitted. A log out button is located in the upper right corner, next to which is the name of the current user logged in.

## Upload Photos
To upload photos, select the images you want to upload using the "Select some files" button. Wait for a preview of all the images to display in the box after you've selected them, then press save. The images you've posted will appear on the main page.

## Delete Images
The name of each image entered into the application will be displayed in the Delete Images box, along with a checkbox next to it. The user can choose which images they want to delete. If you choose "Select All," all of the images will be picked. When you touch the delete button, all of the selected file names will be permanently erased from the application. The Delete Images box will be empty if no images have been submitted into the application.

# Screenshots
![image](https://user-images.githubusercontent.com/62719168/148697611-0b5cce81-60cb-44b8-b690-846fc0356ebc.png)
![image](https://user-images.githubusercontent.com/62719168/148697630-4f03f2e4-7993-48af-a7e8-15ca2ba0a98c.png)
![image](https://user-images.githubusercontent.com/62719168/148697749-6cc400d1-8645-4d03-aed3-af284c12273a.png)
![image](https://user-images.githubusercontent.com/62719168/148697718-ee628948-5f6c-4d0a-845c-8e8009e485b2.png)



# Technologies Used
- ASP.NET MVC 5 Framework
- C#
- Javascript
- HTML
- CSS
- SQL
- Deployed using Azure DevOps

# BackEnd Functionality
A SQL database is used to hold account information, including emails and passwords set by all accounts. All users' passwords are encrypted into the database for security reasons. Each user gets their own folder called after their email address, which contains all of their images. When a user logs into the application, the user's folder is automatically generated if it does not already exist.
